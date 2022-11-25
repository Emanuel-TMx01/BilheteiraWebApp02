using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class DescontosController : Controller
    {
        private readonly WebApplication1Context _context;

        public DescontosController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Descontos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Desconto.ToListAsync());
        }

        // GET: Descontos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Desconto == null)
            {
                return NotFound();
            }

            var desconto = await _context.Desconto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desconto == null)
            {
                return NotFound();
            }

            return View(desconto);
        }

        // GET: Descontos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Descontos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Preco")] Desconto desconto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desconto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desconto);
        }

        // GET: Descontos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Desconto == null)
            {
                return NotFound();
            }

            var desconto = await _context.Desconto.FindAsync(id);
            if (desconto == null)
            {
                return NotFound();
            }
            return View(desconto);
        }

        // POST: Descontos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Preco")] Desconto desconto)
        {
            if (id != desconto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desconto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescontoExists(desconto.Id))
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
            return View(desconto);
        }

        // GET: Descontos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Desconto == null)
            {
                return NotFound();
            }

            var desconto = await _context.Desconto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desconto == null)
            {
                return NotFound();
            }

            return View(desconto);
        }

        // POST: Descontos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Desconto == null)
            {
                return Problem("Entity set 'WebApplication1Context.Desconto'  is null.");
            }
            var desconto = await _context.Desconto.FindAsync(id);
            if (desconto != null)
            {
                _context.Desconto.Remove(desconto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescontoExists(int id)
        {
          return _context.Desconto.Any(e => e.Id == id);
        }
    }
}
