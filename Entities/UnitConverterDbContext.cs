using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UnitConverterAppAPI.Entities
{
    public class UnitConverterDbContext : DbContext
    {
        private readonly string _conntectionString = "Server=.;Database=UnitConverterDb;Trusted_Connection=True";

        public DbSet<Conversion> Conversions { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Conversion>()
            //    .Property(x => x.OriginalUnitId)
            //    .IsRequired();
            //modelBuilder.Entity<Conversion>()
            //    .Property(x => x.TargetUnitId)
            //    .IsRequired();


            //modelBuilder.Entity<Unit>()
            //    .Property(x => x.Factor)
            //    .IsRequired();

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_conntectionString);
        }
    }
}
