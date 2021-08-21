using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoMVC.Data;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class DocenteController : Controller
    {
        private readonly Contexto _context;

        public DocenteController(Contexto context)
        {
            _context = context;
        }

        // GET: Docente
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Docentes.Include(d => d.Curso);
            return View(await contexto.ToListAsync());
        }

        // GET: Docente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docentes
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.DocenteID == id);
            if (docente == null)
            {
                return NotFound();
            }

            return View(docente);
        }

        // GET: Docente/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID");
            return View();
        }

        // POST: Docente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocenteID,DocenteDNI,CursoID,Nombre,Apellidos")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", docente.CursoID);
            return View(docente);
        }

        // GET: Docente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docentes.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", docente.CursoID);
            return View(docente);
        }

        // POST: Docente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocenteID,DocenteDNI,CursoID,Nombre,Apellidos")] Docente docente)
        {
            if (id != docente.DocenteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocenteExists(docente.DocenteID))
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
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", docente.CursoID);
            return View(docente);
        }

        // GET: Docente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docentes
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.DocenteID == id);
            if (docente == null)
            {
                return NotFound();
            }

            return View(docente);
        }

        // POST: Docente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);
            _context.Docentes.Remove(docente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocenteExists(int id)
        {
            return _context.Docentes.Any(e => e.DocenteID == id);
        }
    }
}
