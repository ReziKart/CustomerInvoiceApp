using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Domain.Invoices;
using UniTaskAssignment.Persistence.EntityConfigurations;

namespace UniTaskAssignment.Persistence.Data
{
    public class InvoiceDbContext : DbContext, IInvoiceDbContext, IUnitOfWork
    {
        public const string DefaultSchema = "Invoicing";

        private IDbContextTransaction? _currentTransaction;
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {
        }


        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        }

        public async Task BeginTransactionAsync()
        {
            _currentTransaction ??= await Database.BeginTransactionAsync();
        }

        public async Task RetryOnExceptionAsync(Func<Task> func)
        {
            await Database.CreateExecutionStrategy().ExecuteAsync(func);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

    }

}

