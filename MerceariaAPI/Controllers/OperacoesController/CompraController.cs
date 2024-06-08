using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;

namespace MerceariaAPI.Controllers
{
    public class CompraController : Controller
    {
        private readonly AppDbContext _context;

        public CompraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Compra/List
        public async Task<IActionResult> List()
        {
            var compras = await _context.Compras.ToListAsync();
            return View("/Views/Compra/List.cshtml", compras);
        }

        // GET: /Compra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: /Compra/Create
        public IActionResult Create()
        {
            ViewBag.Produtos = _context.Produtos.ToList(); // Carrega a lista de produtos disponíveis
            return View("/Views/Compra/Create.cshtml");
        }

        // POST: /Compra/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("DataCompra, Lote, DataFabricacao, DataValidade, Fabricante, Vendedor, Transportadora, PrecoCompra, PrecoVenda")] Compra compra, int[] produtosSelecionados)
        {
            if (ModelState.IsValid)
            {
                // Adicione a lógica para salvar a compra e os produtos selecionados aqui
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            ViewBag.Produtos = _context.Produtos.ToList(); // Carrega novamente a lista de produtos disponíveis em caso de falha de validação
            return View("/Views/Compra/Create.cshtml", compra);
        }

        // GET: /Compra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View("/Views/Compra/Edit.cshtml", compra);
        }

        // POST: /Compra/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CompraId, DataCompra, Lote, DataFabricacao, DataValidade, Fabricante, Vendedor, Transportadora, PrecoCompra, PrecoVenda")] Compra compra)
        {
            if (id != compra.CompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.CompraId))
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
            return View("/Views/Compra/Edit.cshtml", compra);
        }

        // GET: /Compra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: /Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            #pragma warning disable CS8604 // Possible null reference argument.
            _context.Compras.Remove(compra);
            #pragma warning restore CS8604 // Possible null reference argument.
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.CompraId == id);
        }
    }
}
