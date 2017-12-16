using pwiki.domain.Interfaces;
using System.Collections.Generic;

namespace pwiki.domain.Models
{
    public class Note: IHasId
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<NoteTag> Tags { get; set; }
    }
}
