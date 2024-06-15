using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MerceariaAPI.Controllers
{
    [Route("Produto")]
  
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            _logger.LogInformation("User {Username} accessed List action.", User.Identity.Name);

            try
            {
                var produtos = await _context.Produtos.ToListAsync();
                return View("Views/Produto/List.cshtml", produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving produtos.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /Produto/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("Views/Produto/Create.cshtml");
        }

        // POST: /Produto/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind("Id,Nome,TipoProdutoId,Descricao")] Produto Produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View("Views/Produto/Create.cshtml", Produto);
        }

        // GET: Produto/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View("Views/Produto/Edit.cshtml", produto);
        }

        // POST: Produto/Edit/5
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View("Views/Produto/List.cshtml");
        }

        // GET: Produto/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View("Views/Produto/Delete.cshtml", produto);
        }

        // POST: Produto/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}

