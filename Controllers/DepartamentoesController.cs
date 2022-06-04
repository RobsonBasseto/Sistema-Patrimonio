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
    public class DepartamentoesController : Controller
    {
        private readonly Context _context;

        public DepartamentoesController(Context context)
        {
            _context = context;
        }

        // GET: Departamentoes
        public async Task<IActionResult> Index()
        {
            List<DtoDepartamento> lista = (from d in _context.Departamentos
                                           join l in _context.Locais on d.idlocal equals l.idlocal
                                           select new DtoDepartamento
                                           {
                                               iddepartamento = d.iddepartamento,
                                               descricaodepartamento = d.descricaodepartamento,
                                               nomedepartamento = d.nomedepartamento,
                                               nomelocal = l.nomelocal
                                           }).ToList();

            return View(lista);
                          
        }

        // GET: Departamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.iddepartamento == id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }

            return View(dbDepartamento);
        }

        // GET: Departamentoes/Create
        public IActionResult Create()
        {
            // ViewBag.local = (from c in _context.Locais
            //                 select c.nomelocal).Distinct();

            ViewBag.Local2 = new SelectList(_context.Locais, "idlocal", "nomelocal");

            return View();
        }

        // POST: Departamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iddepartamento,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbDepartamento);
        }

        // GET: Departamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.Departamentos.FindAsync(id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }
            return View(dbDepartamento);
        }

        // POST: Departamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iddepartamento,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (id != dbDepartamento.iddepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbDepartamentoExists(dbDepartamento.iddepartamento))
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
            return View(dbDepartamento);
        }

        // GET: Departamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.iddepartamento == id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }

            return View(dbDepartamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departamentos == null)
            {
                return Problem("Entity set 'Context.Departamentos'  is null.");
            }
            var dbDepartamento = await _context.Departamentos.FindAsync(id);
            if (dbDepartamento != null)
            {
                _context.Departamentos.Remove(dbDepartamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbDepartamentoExists(int id)
        {
          return (_context.Departamentos?.Any(e => e.iddepartamento == id)).GetValueOrDefault();
        }
    }
}
