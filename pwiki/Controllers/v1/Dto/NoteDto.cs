using System.Collections.Generic;

namespace pwiki.Controllers.v1.Dto
{
    public class NoteDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
