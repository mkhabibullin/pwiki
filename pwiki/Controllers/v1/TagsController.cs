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
    public class TagsController : Controller
    {
        private readonly PwikiDbContext _context;

        public TagsController(PwikiDbContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<TagDto> GetTags(string filter)
        {
            var normalizedFilter = filter?.Trim().ToLowerInvariant();
            return _context.Tags
                .Include(t => t.Notes)
                .Where(t => string.IsNullOrEmpty(normalizedFilter) || t.Name.ToLower().Contains(normalizedFilter))
                .Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    NotesCount = t.Notes.Count
                });
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = await _context.Tags.SingleOrDefaultAsync(m => m.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag([FromRoute] int id, [FromBody] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tag.Id)
            {
                return BadRequest();
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
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

        // POST: api/Tags
        [HttpPost]
        public async Task<IActionResult> PostTag([FromBody] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTag", new { id = tag.Id }, tag);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = await _context.Tags.SingleOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return Ok(tag);
        }

        private bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}