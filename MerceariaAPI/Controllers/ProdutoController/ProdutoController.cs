using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Models;

namespace MerceariaAPI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Produto/List
        public async Task<IActionResult> List()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return View("/Views/Produto/List.cshtml", produtos);
        }

        //GET: /Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: /Produtos/Create
        public IActionResult Create()
        {
            return View("/Views/Produto/Create.cshtml");
        }

        // POST: /Produtos/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome, TipoProdutoId, Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(produto);
                    await _context.SaveChangesAsync(); 
                    return RedirectToAction(nameof(List));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", "Erro ao salvar o produto. Por favor, tente novamente.");
                    return View("/Views/Produto/Create.cshtml", produto);
                }
            }
            return View("/Views/Produto/Create.cshtml", produto);
        }

        // GET: /Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View("/Views/Produto/Edit.cshtml", produto);
        }

        // POST: /Produtos/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, TipoProdutoId, Descricao")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
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
            }
            return View("/Views/Produto/Edit.cshtml", produto);
        }


        // GET: /Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: /Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
#pragma warning disable CS8604 // Possible null reference argument.
            _context.Produtos.Remove(produto);
#pragma warning restore CS8604 // Possible null reference argument.
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
