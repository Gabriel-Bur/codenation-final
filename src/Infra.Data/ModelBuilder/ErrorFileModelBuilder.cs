using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ModelBuilder
{
    public class ErrorFileModelBuilder : IEntityTypeConfiguration<ErrorFile>
    {
        public void Configure(EntityTypeBuilder<ErrorFile> builder)
        {
                       
            //Title
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            //Details
            builder.Property(x => x.Data)
                .HasColumnName("data")
                .HasMaxLength(5000) // in kb 
                .IsRequired();

        }
    }
}
