using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Persistence.EntityConfigurations
{
	public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
		public InvoiceConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            //Table name
            builder.ToTable("Invoices");

            //key
            builder.HasKey(e => e.Id);

            //Required Fields
            builder.Property(p => p.DueDate).IsRequired();
            builder.Property(p => p.InvoiceDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Amount).IsRequired();



        }
    }
}

