using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media2.API.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap(modelBuilder.Entity<Product>());
        }

        public class UserMap
        {
            public UserMap(EntityTypeBuilder<Product> entityBuilder)
            {
                entityBuilder.ToTable("Product");
                entityBuilder.Property(s => s.COD).HasMaxLength(15).IsRequired();
                entityBuilder.Property(s => s.Name).HasMaxLength(30).IsRequired();
                entityBuilder.Property(s => s.Price).HasMaxLength(10).IsRequired();
                entityBuilder.Property(s => s.Description).HasMaxLength(200).IsRequired();
            }
        }
    }
}
