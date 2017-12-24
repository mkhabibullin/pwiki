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

        public DbSet<Tag> Tags { get; set; }

        public DbSet<NoteTag> NoteTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NoteTag>()
                .HasKey(t => new { t.NoteId, t.TagId });
        }
    }
}
