using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MerceariaAPI.Controllers
{
    [Route("TipoProduto")]
    [Authorize]
    public class TipoProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public TipoProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /TipoProduto/List
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var tipoProdutos = await _context.TipoProdutos.ToListAsync();
            return View("List", tipoProdutos); // View está na pasta Views/TipoProduto/List.cshtml
        }

        // GET: /TipoProduto/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // View está na pasta Views/TipoProduto/Create.cshtml
        }

        // POST: /TipoProduto/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List)); // Redireciona para a action List após a criação
            }
            return View("Create", tipoProduto); // Retorna a view de criação com o modelo em caso de erro
        }

        // GET: /TipoProduto/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }
            return View("Edit", tipoProduto); // View está na pasta Views/TipoProduto/Edit.cshtml
        }

        // POST: /TipoProduto/Edit/5
        [HttpPost("Edit/{id}")]
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
                return RedirectToAction(nameof(List)); // Redireciona para a action List após a edição
            }
            return View("Edit", tipoProduto); // Retorna a view de edição com o modelo em caso de erro
        }

        // GET: /TipoProduto/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View("Delete", tipoProduto); // View está na pasta Views/TipoProduto/Delete.cshtml
        }

        // POST: /TipoProduto/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            _context.TipoProdutos.Remove(tipoProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List)); // Redireciona para a action List após a exclusão
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.Id == id);
        }
    }
}
