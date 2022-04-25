using CarStock.Entity;
using CarStock.Entity.EfMapping;
using Microsoft.EntityFrameworkCore;

namespace BaseSolution.Project.DataAccess.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarMap());
        }
    }
}