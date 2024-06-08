using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;

namespace MerceariaAPI.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public TipoProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /TipoProduto/List
        public async Task<IActionResult> List()
        {
            var tipoProdutos = await _context.TipoProdutos.ToListAsync();
            return View("/Views/TipoProduto/List.cshtml", tipoProdutos);
        }

        // GET: /TipoProduto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TipoProduto/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View("/Views/TipoProduto/Create.cshtml", tipoProduto);
        }

        // GET: /TipoProduto/Edit/5
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

        // POST: /TipoProduto/Edit/5
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
            return View("/Views/TipoProduto/List.cshtml");
        }

        // GET: /TipoProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View("/Views/TipoProduto/Delete.cshtml", tipoProduto);
        }

        // POST: /TipoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
#pragma warning disable CS8604 // Possible null reference argument.
            _context.TipoProdutos.Remove(tipoProduto);
#pragma warning restore CS8604 // Possible null reference argument.
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.Id == id);
        }
    }
}
