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
    public class AlumnoController : Controller
    {
        private readonly Contexto _context;

        public AlumnoController(Contexto context)
        {
            _context = context;
        }

        // GET: Alumno
        public async Task<IActionResult> Index(string busquedaAlumnoDNI,string busquedaAlumno )
        {
            var v_alumnos = from a in _context.Alumnos
                            select a;
            //v_alumnos = _context.Alumnos.Include(p => p.Apellidos);
            if (!String.IsNullOrEmpty(busquedaAlumnoDNI))
            {
                v_alumnos = v_alumnos.Where(s => s.AlumnoDNI.Contains(busquedaAlumnoDNI));
            }
            if (!String.IsNullOrEmpty(busquedaAlumno))
            {
                v_alumnos = v_alumnos.Where(s => s.AlumnoApellidos.Contains(busquedaAlumno));
            }
            return View(await v_alumnos.ToListAsync());

        }

        // GET: Alumno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.AlumnoID == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoID,AlumnoDNI,AlumnoApellidos,AlumnoNombre")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                var alumn = await _context.Alumnos
                    .FirstOrDefaultAsync(m => m.AlumnoDNI == alumno.AlumnoDNI);
                if(alumn == null)
                {
                    _context.Add(alumno);
                    await _context.SaveChangesAsync();
                    ViewData["result"] = "";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["result"] = "Ya existe DNI";
                }
               
            }
            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlumnoID,AlumnoDNI,AlumnoApellidos,AlumnoNombre")] Alumno alumno)
        {
            if (id != alumno.AlumnoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.AlumnoID))
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
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.AlumnoID == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.AlumnoID == id);
        }
    }
}
