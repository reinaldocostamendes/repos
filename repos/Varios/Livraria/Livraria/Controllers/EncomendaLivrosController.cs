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
    public class EncomendaLivrosController : Controller
    {
        private readonly LivrariaContext _context;

        public EncomendaLivrosController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: EncomendaLivros
        public async Task<IActionResult> Index()
        {
            return View(await _context.EncomendaLivros.ToListAsync());
        }

        // GET: EncomendaLivros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendaLivros = await _context.EncomendaLivros
                .FirstOrDefaultAsync(m => m.IDEncomendaLivro == id);
            if (encomendaLivros == null)
            {
                return NotFound();
            }

            return View(encomendaLivros);
        }

        // GET: EncomendaLivros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EncomendaLivros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEncomendaLivro,Encomenda,Livro,Quantidade")] EncomendaLivros encomendaLivros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encomendaLivros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encomendaLivros);
        }

        // GET: EncomendaLivros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendaLivros = await _context.EncomendaLivros.FindAsync(id);
            if (encomendaLivros == null)
            {
                return NotFound();
            }
            return View(encomendaLivros);
        }

        // POST: EncomendaLivros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDEncomendaLivro,Encomenda,Livro,Quantidade")] EncomendaLivros encomendaLivros)
        {
            if (id != encomendaLivros.IDEncomendaLivro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomendaLivros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomendaLivrosExists(encomendaLivros.IDEncomendaLivro))
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
            return View(encomendaLivros);
        }

        // GET: EncomendaLivros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendaLivros = await _context.EncomendaLivros
                .FirstOrDefaultAsync(m => m.IDEncomendaLivro == id);
            if (encomendaLivros == null)
            {
                return NotFound();
            }

            return View(encomendaLivros);
        }

        // POST: EncomendaLivros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomendaLivros = await _context.EncomendaLivros.FindAsync(id);
            _context.EncomendaLivros.Remove(encomendaLivros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncomendaLivrosExists(int id)
        {
            return _context.EncomendaLivros.Any(e => e.IDEncomendaLivro == id);
        }
    }
}
