using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FAUNA.Data;
using API_FAUNA.Models;

namespace API_FAUNA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspeciesController : ControllerBase
    {
        private readonly FaunaContext _context;

        public EspeciesController(FaunaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especie>>> GetEspecies()
        {
            return await _context.Especies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Especie>> GetEspecie(int id)
        {
            var especie = await _context.Especies.FindAsync(id);

            if (especie == null)
            {
                return NotFound();
            }

            return especie;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecie(int id, Especie especie)
        {
            if (id != especie.Id)
            {
                return BadRequest();
            }

            _context.Entry(especie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecieExists(id))
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

        // POST: api/Especies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especie>> PostEspecie(Especie especie)
        {
            _context.Especies.Add(especie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecie", new { id = especie.Id }, especie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecie(int id)
        {
            var especie = await _context.Especies.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }

            _context.Especies.Remove(especie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecieExists(int id)
        {
            return _context.Especies.Any(e => e.Id == id);
        }
    }
}
