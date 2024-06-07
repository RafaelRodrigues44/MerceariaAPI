using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Data;
using MerceariaAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MerceariaAPI.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public TipoProdutoController(AppDbContext context, ILogger<TipoProdutoController> logger)
        {
            _context = context;
        }

        // GET: TipoProduto/List
        public async Task<IActionResult> List()
        {
            var tipoProdutos = await _context.TipoProdutos.ToListAsync();
            return View("/Views/TipoProduto/List.cshtml", tipoProdutos);
        }

        // GET: TipoProduto/Create
        public IActionResult Create()
        {
            return View("/Views/TipoProduto/Create.cshtml");
        }

        // POST: TipoProduto/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View("/Views/TipoProduto/List.cshtml", tipoProduto);
        }

        // EDIT: TipoProdutoMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }
            return View("/Views/TipoProduto/Edit.cshtml", tipoProduto);
        }

        // POST: TipoProduto/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoProduto tipoProduto)
        {
            if (id != tipoProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdutoExists(tipoProduto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View("/Views/TipoProduto/Edit.cshtml", tipoProduto);
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.Id == id);
        }

        // DELETE: TipoProduto/Delete/(id)
        [HttpDelete]
        public async Task<IActionResult> DeleteTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            _context.TipoProdutos.Remove(tipoProduto);
            await _context.SaveChangesAsync();
            return View("/Views/TipoProduto/List.cshtml", tipoProduto);

        }
    }
}
