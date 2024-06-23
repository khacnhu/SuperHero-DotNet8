using Microsoft.EntityFrameworkCore;
using SuperHero_DotNet8.Entities;

namespace SuperHero_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
