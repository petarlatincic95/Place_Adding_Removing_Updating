using Microsoft.EntityFrameworkCore;
using Place_Adding_Removing_Updating.Data.Model;

namespace Place_Adding_Removing_Updating.Data
{
    public class dbContext : DbContext
    {

        public dbContext(DbContextOptions<dbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

           builder.Entity<Country>().HasIndex(u => u.Name).IsUnique();
           builder.Entity<Place>().HasIndex(u => u.ZipCode).IsUnique();
         

            



        }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Place> Places { get; set; }
        

    }
}
