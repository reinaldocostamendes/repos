using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livraria.Data;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class AutoresLivrosController : Controller
    {
        private readonly LivrariaContext _context;

        public AutoresLivrosController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: AutoresLivros
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutoresLivros.ToListAsync());
        }

        // GET: AutoresLivros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresLivros = await _context.AutoresLivros
                .FirstOrDefaultAsync(m => m.IDAutorLivro == id);
            if (autoresLivros == null)
            {
                return NotFound();
            }

            return View(autoresLivros);
        }

        // GET: AutoresLivros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoresLivros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDAutorLivro,Autor,Livro")] AutoresLivros autoresLivros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoresLivros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoresLivros);
        }

        // GET: AutoresLivros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresLivros = await _context.AutoresLivros.FindAsync(id);
            if (autoresLivros == null)
            {
                return NotFound();
            }
            return View(autoresLivros);
        }

        // POST: AutoresLivros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDAutorLivro,Autor,Livro")] AutoresLivros autoresLivros)
        {
            if (id != autoresLivros.IDAutorLivro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoresLivros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoresLivrosExists(autoresLivros.IDAutorLivro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autoresLivros);
        }

        // GET: AutoresLivros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresLivros = await _context.AutoresLivros
                .FirstOrDefaultAsync(m => m.IDAutorLivro == id);
            if (autoresLivros == null)
            {
                return NotFound();
            }

            return View(autoresLivros);
        }

        // POST: AutoresLivros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoresLivros = await _context.AutoresLivros.FindAsync(id);
            _context.AutoresLivros.Remove(autoresLivros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoresLivrosExists(int id)
        {
            return _context.AutoresLivros.Any(e => e.IDAutorLivro == id);
        }
    }
}
