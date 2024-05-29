using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerceariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstoqueController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoque()
        {
            return await _context.Estoque.ToListAsync();
        }

        // GET: api/Estoque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetEstoque(int id)
        {
            var estoque = await _context.Estoque.FindAsync(id);

            if (estoque == null)
            {
                return NotFound();
            }

            return estoque;
        }

        // PUT: api/Estoque/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int id, Estoque estoque)
        {
            if (id != estoque.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(estoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id))
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

        // POST: api/Estoque
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostEstoque(Estoque estoque)
        {
            _context.Estoque.Add(estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoque", new { id = estoque.ProdutoId }, estoque);
        }

        // DELETE: api/Estoque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstoque(int id)
        {
            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }

            _context.Estoque.Remove(estoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoque.Any(e => e.ProdutoId == id);
        }
    }
}
