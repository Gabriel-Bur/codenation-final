using Domain.Core.Entity;
using Infra.Data.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Error> Errors { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserModelBuilder());
            modelBuilder.ApplyConfiguration(new ErrorModelBuilder());

            base.OnModelCreating(modelBuilder);
        }

    }
}
