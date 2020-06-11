using Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.ModelBuilder
{
    public class UserModelBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //name
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();


            //email
            builder.HasIndex(x => x.Email).IsUnique(true);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(60)
                .IsRequired();


            //password
            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
