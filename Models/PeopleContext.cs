using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "People");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}