using Microsoft.EntityFrameworkCore;
using pwiki.domain.Models;

namespace pwiki.domain
{
    public class PwikiDbContext : DbContext
    {
        public PwikiDbContext(DbContextOptions<PwikiDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
