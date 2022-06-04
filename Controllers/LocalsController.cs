using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Patrimonio.Models;

namespace Sistema_Patrimonio.Controllers
{
    public class LocalsController : Controller
    {
        private readonly Context _context;

        public LocalsController(Context context)
        {
            _context = context;
        }

        // GET: Locals
        public async Task<IActionResult> Index()
        {
              return _context.Locais != null ? 
                          View(await _context.Locais.ToListAsync()) :
                          Problem("Entity set 'Context.Locais'  is null.");
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locais == null)
            {
                return NotFound();
            }

            var dbLocal = await _context.Locais
                .FirstOrDefaultAsync(m => m.idlocal == id);
            if (dbLocal == null)
            {
                return NotFound();
            }

            return View(dbLocal);
        }

        // GET: Locals/Create
        public IActionResult Create()
        {
            
            
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idlocal,nomelocal,descricaolocal")] DbLocal dbLocal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbLocal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbLocal);
        }

        // GET: Locals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locais == null)
            {
                return NotFound();
            }

            var dbLocal = await _context.Locais.FindAsync(id);
            if (dbLocal == null)
            {
                return NotFound();
            }
            return View(dbLocal);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idlocal,nomelocal,descricaolocal")] DbLocal dbLocal)
        {
            if (id != dbLocal.idlocal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbLocal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbLocalExists(dbLocal.idlocal))
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
            return View(dbLocal);
        }

        // GET: Locals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locais == null)
            {
                return NotFound();
            }

            var dbLocal = await _context.Locais
                .FirstOrDefaultAsync(m => m.idlocal == id);
            if (dbLocal == null)
            {
                return NotFound();
            }

            return View(dbLocal);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locais == null)
            {
                return Problem("Entity set 'Context.Locais'  is null.");
            }
            var dbLocal = await _context.Locais.FindAsync(id);
            if (dbLocal != null)
            {
                _context.Locais.Remove(dbLocal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbLocalExists(int id)
        {
          return (_context.Locais?.Any(e => e.idlocal == id)).GetValueOrDefault();
        }
    }
}
