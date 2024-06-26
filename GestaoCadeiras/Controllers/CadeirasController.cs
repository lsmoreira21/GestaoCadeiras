using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoCadeiras.API.Data;
using GestaoCadeiras.Core.Models;
using Microsoft.Extensions.Configuration;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Requests.Cadeira;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GestaoCadeiras.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadeirasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CadeirasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cadeiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadeira>>> GetCadeiras()
        {
            return await _context.Cadeiras.ToListAsync();
        }        

        // GET: api/Cadeiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadeira>> GetCadeira(int id)
        {
            var cadeira = await _context.Cadeiras.FindAsync(id);

            if (cadeira == null)
            {
                return NotFound();
            }

            return cadeira;
        }

        // PUT: api/Cadeiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadeira(int id, Cadeira cadeira)
        {
            if (id != cadeira.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadeira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadeiraExists(id))
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

        // POST: api/Cadeiras        
        [HttpPost]
        public async Task<ActionResult<Cadeira>> PostCadeira(Cadeira cadeira)
        {
            _context.Cadeiras.Add(cadeira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadeira", new { id = cadeira.Id }, cadeira);
        }

        // DELETE: api/Cadeiras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadeira(Guid id)
        {
            var cadeira = await _context.Cadeiras.FindAsync(id);
            if (cadeira == null)
            {
                return NotFound();
            }

            _context.Cadeiras.Remove(cadeira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadeiraExists(int id)
        {
            return _context.Cadeiras.Any(e => e.Id == id);
        }
    }
}
