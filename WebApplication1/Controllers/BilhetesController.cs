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
    public class BilhetesController : Controller
    {
        private readonly WebApplication1Context _context;

        public BilhetesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Bilhetes
        public async Task<IActionResult> Index()
        {
            var webApplication1Context = _context.Bilhete.Include(b => b.Cliente).Include(b => b.Desconto).Include(b => b.Filme);
            return View(await webApplication1Context.ToListAsync());
        }

        // GET: Bilhetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bilhete == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete
                .Include(b => b.Cliente)
                .Include(b => b.Desconto)
                .Include(b => b.Filme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // GET: Bilhetes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Nome");
            ViewData["DescontoId"] = new SelectList(_context.Set<Desconto>(), "Id", "Descricao");
            ViewData["FilmeId"] = new SelectList(_context.Set<Filme>(), "Id", "Genero");
            return View();
        }

        // POST: Bilhetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Stock,DataRegisto,FilmeId,DescontoId,ClienteId")] Bilhete bilhete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilhete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Nome", bilhete.ClienteId);
            ViewData["DescontoId"] = new SelectList(_context.Set<Desconto>(), "Id", "Descricao", bilhete.DescontoId);
            ViewData["FilmeId"] = new SelectList(_context.Set<Filme>(), "Id", "Genero", bilhete.FilmeId);
            return View(bilhete);
        }

        // GET: Bilhetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bilhete == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete.FindAsync(id);
            if (bilhete == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Nome", bilhete.ClienteId);
            ViewData["DescontoId"] = new SelectList(_context.Set<Desconto>(), "Id", "Descricao", bilhete.DescontoId);
            ViewData["FilmeId"] = new SelectList(_context.Set<Filme>(), "Id", "Genero", bilhete.FilmeId);
            return View(bilhete);
        }

        // POST: Bilhetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Stock,DataRegisto,FilmeId,DescontoId,ClienteId")] Bilhete bilhete)
        {
            if (id != bilhete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilhete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilheteExists(bilhete.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Nome", bilhete.ClienteId);
            ViewData["DescontoId"] = new SelectList(_context.Set<Desconto>(), "Id", "Descricao", bilhete.DescontoId);
            ViewData["FilmeId"] = new SelectList(_context.Set<Filme>(), "Id", "Genero", bilhete.FilmeId);
            return View(bilhete);
        }

        // GET: Bilhetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bilhete == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhete
                .Include(b => b.Cliente)
                .Include(b => b.Desconto)
                .Include(b => b.Filme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // POST: Bilhetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bilhete == null)
            {
                return Problem("Entity set 'WebApplication1Context.Bilhete'  is null.");
            }
            var bilhete = await _context.Bilhete.FindAsync(id);
            if (bilhete != null)
            {
                _context.Bilhete.Remove(bilhete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilheteExists(int id)
        {
          return _context.Bilhete.Any(e => e.Id == id);
        }
    }
}
