using Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ModelBuilder
{
    public class ErrorModelBuilder : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {

            builder.Property(x => x.Stage)
                .HasConversion<int>();

            builder.Property(x => x.Level)
                .HasConversion<int>();
        }
    }
}
