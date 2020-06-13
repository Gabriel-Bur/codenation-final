using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ModelBuilder
{
    public class ErrorFileModelBuilder : IEntityTypeConfiguration<ErrorFile>
    {
        public void Configure(EntityTypeBuilder<ErrorFile> builder)
        {
                       
            //Name
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            //Data
            builder.Property(x => x.Data)
                .HasColumnName("data")
                .HasColumnType("binary(1024)") //in kb
                .IsRequired();

        }
    }
}
