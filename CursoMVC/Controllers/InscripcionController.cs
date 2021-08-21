﻿using System;
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
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Inscripciones.Include(i => i.Alumno).Include(i => i.Curso);
            return View(await contexto.ToListAsync());
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
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "Apellidos");
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo");
            return View();
        }

        // POST: Inscripcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscripcionID,CursoID,AlumnoID,Nota")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "Apellidos", inscripcion.AlumnoID);
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo", inscripcion.CursoID);
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
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "Apellidos", inscripcion.AlumnoID);
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "Titulo", inscripcion.CursoID);
            return View(inscripcion);
        }

        // POST: Inscripcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscripcionID,CursoID,AlumnoID,Nota")] Inscripcion inscripcion)
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
            ViewData["AlumnoID"] = new SelectList(_context.Alumnos, "AlumnoID", "Apellidos", inscripcion.AlumnoID);
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", inscripcion.CursoID);
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