using System;
namespace UniTaskAssignment.Application.Interfaces
{
    public interface IInvoiceDbContext
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
        Task RetryOnExceptionAsync(Func<Task> func);
    }


}

