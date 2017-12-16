using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pwiki.Controllers.v1.Dto;
using pwiki.domain;
using pwiki.domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pwiki.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NotesController : Controller
    {
        private readonly PwikiDbContext _context;

        public NotesController(PwikiDbContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            return _context.Notes;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody]AddNoteDto note)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IList<NoteTag> tags = new List<NoteTag>();

            if (note.Tags.Any())
            {
                foreach(var t in note.Tags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Name.Equals(t, System.StringComparison.InvariantCultureIgnoreCase));
                    if(tag == null)
                    {
                        tag = new Tag { Name = t };
                    }
                    tags.Add(new NoteTag { Tag = tag });
                }
            }

            var newNote = new Note
            {
                Text = note.Text,
                Tags = tags
            };

            _context.Add(newNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = newNote.Id }, note);
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var note = await _context.Notes.SingleOrDefaultAsync(m => m.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote([FromRoute] int id, [FromBody] Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != note.Id)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var note = await _context.Notes.SingleOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok(note);
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}