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
    public class EncomendasController : Controller
    {
        private readonly LivrariaContext _context;

        public EncomendasController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: Encomendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Encomendas.ToListAsync());
        }

        // GET: Encomendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendas = await _context.Encomendas
                .FirstOrDefaultAsync(m => m.IDEncomenda == id);
            if (encomendas == null)
            {
                return NotFound();
            }

            return View(encomendas);
        }

        // GET: Encomendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEncomenda,Data,NIFCliente")] Encomendas encomendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encomendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encomendas);
        }

        // GET: Encomendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendas = await _context.Encomendas.FindAsync(id);
            if (encomendas == null)
            {
                return NotFound();
            }
            return View(encomendas);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDEncomenda,Data,NIFCliente")] Encomendas encomendas)
        {
            if (id != encomendas.IDEncomenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomendasExists(encomendas.IDEncomenda))
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
            return View(encomendas);
        }

        // GET: Encomendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendas = await _context.Encomendas
                .FirstOrDefaultAsync(m => m.IDEncomenda == id);
            if (encomendas == null)
            {
                return NotFound();
            }

            return View(encomendas);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomendas = await _context.Encomendas.FindAsync(id);
            _context.Encomendas.Remove(encomendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncomendasExists(int id)
        {
            return _context.Encomendas.Any(e => e.IDEncomenda == id);
        }
    }
}
