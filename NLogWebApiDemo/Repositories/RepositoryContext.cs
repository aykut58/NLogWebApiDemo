using Microsoft.EntityFrameworkCore;
using NLogWebApiDemo.Models;
using NLogWebApiDemo.Repositories.Config;

namespace NLogWebApiDemo.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
