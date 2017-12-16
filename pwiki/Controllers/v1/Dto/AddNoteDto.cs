using System.Collections.Generic;

namespace pwiki.Controllers.v1.Dto
{
    public class AddNoteDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public IList<string> Tags { get; set; }
    }
}
