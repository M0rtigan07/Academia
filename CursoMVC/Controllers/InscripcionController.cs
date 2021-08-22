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
    public class InscripcionController : Controller
    {
        private readonly Contexto _context;

        public InscripcionController(Contexto context)
        {
            _context = context;
        }

        // GET: Inscripcion
        public async Task<IActionResult> Index(string busquedaNota, string busquedaPorAlumno, string busquedaPorCurso)
        {
            var v_inscripciones = from m in _context.Inscripciones
                                  select m;
            v_inscripciones = _context.Inscripciones.Include(i => i.Alumno).Include(i => i.Curso).Include(i => i.Nota);
            if(!String.IsNullOrEmpty(busquedaNota))
            {
                v_inscripciones = v_inscripciones.Where(n => n.Nota.calificacion.Contains(busquedaNota));
            }
            if(!String.IsNullOrEmpty(busquedaPorAlumno))
            {
                v_inscripciones = v_inscripciones.Where(a => a.Alumno.AlumnoDNI.Contains(busquedaPorAlumno));
            }
            if(!String.IsNullOrEmpty(busquedaPorCurso))
            {
                v_inscripciones = v_inscripciones.Where(c => c.Curso.Titulo.Contains(busquedaPorCurso));
            }
            return View(await v_inscripciones.ToListAsync());
        }

        // GET: Inscripcion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones
                .Include(i => i.Alumno)
                .Include(i => i.Curso)
                .Include(i => i.Nota)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripcion/Create
        public IActionResult Create()
        {
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoDNI","AlumnoNombre", "AlumnoApellidos");
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo");
            ViewData["NotaID"] = new SelectList(_context.Notas, "NotaID", "calificacion");
            return View();
        }

        // POST: Inscripcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscripcionID,FechaDeInscripcion,CursoID,AlumnoID,NotaID,AlumnoApellidos,AlumnoNombre,calificacion")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoDNI", inscripcion.AlumnoID);
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo", inscripcion.CursoID);
            ViewData["NotaID"] = new SelectList(_context.Notas, "NotaID", "calificacion", inscripcion.NotaID);
            return View(inscripcion);
        }

        // GET: Inscripcion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoDNI",  inscripcion.AlumnoID);
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo", inscripcion.CursoID);
            ViewData["NotaID"] = new SelectList(_context.Notas, "NotaID", "calificacion", inscripcion.NotaID);
            return View(inscripcion);
        }

        // POST: Inscripcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscripcionID,FechaDeInscripcion,CursoID,AlumnoID,NotaID,AlumnoApellidos,AlumnoNombre,calificacion")] Inscripcion inscripcion)
        {
            if (id != inscripcion.InscripcionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.InscripcionID))
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
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "AlumnoDNI", inscripcion.AlumnoID);
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo", inscripcion.CursoID);
            ViewData["NotaID"] = new SelectList(_context.Notas, "NotaID", "calificacion", inscripcion.NotaID);
            return View(inscripcion);
        }

        // GET: Inscripcion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones
                .Include(i => i.Alumno)
                .Include(i => i.Curso)
                .Include(i => i.Nota)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
            return _context.Inscripciones.Any(e => e.InscripcionID == id);
        }
    }
}
