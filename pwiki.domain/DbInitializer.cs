using System.Linq;
using pwiki.domain.Models;

namespace pwiki.domain
{
    public static class DbInitializer
    {
        public static void Initialize(PwikiDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Notes.Any())
            {
                return;   // DB has been seeded
            }

            context.Notes.AddRange(
                new Note { Text = "Test msg 1" },
                new Note { Text = "Test msg 2" }
            );

            context.SaveChanges();
        }
    }
}
