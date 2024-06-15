using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Data;
using MerceariaAPI.Areas.Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    public class TypeUserController : Controller
    {
        private readonly AppDbContext _context;

        public TypeUserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /TypeUser/List
        [Authorize]
        public async Task<IActionResult> List()
        {
            var typeUsers = await _context.TypeUsers.ToListAsync();
            return View("/Views/TypeUser/List.cshtml", typeUsers);
        }

        // GET: /TypeUser/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TypeUser/Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TypeUser typeUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View("/Views/TypeUser/Create.cshtml", typeUser);
        }

        // GET: /TipoProduto/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUsers.FindAsync(id);
            if (typeUser == null)
            {
                return NotFound();
            }
            return View("/Views/TypeUser/Edit.cshtml", typeUser);
        }

        // POST: /TipoProduto/Edit/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TypeUser typeUser)
        {
            if (id != typeUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeUserExists(typeUser.Id))
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
            return View("/Views/TypeUser/List.cshtml");
        }

        // GET: /TypeUser/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUsers.FindAsync(id);
            if (typeUser == null)
            {
                return NotFound();
            }

            return View("/Views/TypeUser/Delete.cshtml", typeUser);
        }

        // POST: /TypeUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeUser = await _context.TypeUsers.FindAsync(id);
            #pragma warning disable CS8604 
            _context.TypeUsers.Remove(typeUser);
            #pragma warning restore CS8604 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool TypeUserExists(int id)
        {
            return _context.TypeUsers.Any(e => e.Id == id);
        }
    }
}
