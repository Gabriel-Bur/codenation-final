using Domain.Core.Entity;
using Domain.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ModelBuilder
{
    public class ErrorModelBuilder : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {

            //Title
            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            //Details
            builder.Property(x => x.Details)
                .HasColumnName("details")
                .HasMaxLength(600)
                .IsRequired();

            //Level
            builder.Property(x => x.Type)
                .HasColumnName("level")
                .HasConversion<int>()
                .IsRequired();


            //File
            builder.HasMany(f => f.Files)
                .WithOne(e => e.Error)
                .HasForeignKey(e => e.ErrorId);

        }
    }
}
