using Domain.Core.Entity;
using Domain.Entity;
using Infra.Data.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<ErrorFile> ErrorFiles { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserModelBuilder());
            modelBuilder.ApplyConfiguration(new ErrorModelBuilder());
            modelBuilder.ApplyConfiguration(new ErrorFileModelBuilder());

            base.OnModelCreating(modelBuilder);
        }

    }
}
