using pwiki.domain.Interfaces;
using System.Collections.Generic;

namespace pwiki.domain.Models
{
    public class Tag: IHasId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<NoteTag> Notes { get; set; }
    }
}
