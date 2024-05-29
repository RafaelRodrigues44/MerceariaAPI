using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;

namespace MerceariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProduto>>> GetTipoProdutos()
        {
            return await _context.TipoProdutos.ToListAsync();
        }

        // GET: api/TipoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProduto>> GetTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);

            if (tipoProduto == null)
            {
                return NotFound();
            }

            return tipoProduto;
        }

        // PUT: api/TipoProdutos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProduto(int id, TipoProduto tipoProduto)
        {
            if (id != tipoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProdutoExists(id))
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

        // POST: api/TipoProdutos
        [HttpPost]
        public async Task<ActionResult<TipoProduto>> PostTipoProduto(TipoProduto tipoProduto)
        {
            _context.TipoProdutos.Add(tipoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoProduto), new { id = tipoProduto.Id }, tipoProduto);
        }

        // DELETE: api/TipoProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            _context.TipoProdutos.Remove(tipoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.Id == id);
        }
    }
}
