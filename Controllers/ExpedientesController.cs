using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Data;
using ColegioSanJose.Models;

namespace Desafio_2___DAS___Colegio_San_Jose.Controllers
{
    public class ExpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expedientes.Include(e => e.Alumno).Include(e => e.Materia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expedientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(m => m.ExpedienteId == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // GET: Expedientes/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos.Select(a => new { a.AlumnoId, NombreCompleto = a.Nombres + " " + a.Apellidos }), "AlumnoId", "NombreCompleto");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NombreMateria");
            return View();
        }

        // POST: Expedientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpedienteId,AlumnoId,MateriaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            var duplicado = await _context.Expedientes
               .AnyAsync(e => e.AlumnoId == expediente.AlumnoId
               && e.MateriaId == expediente.MateriaId);

            if (duplicado)
            {
                ModelState.AddModelError("", "Este alumno ya tiene registrada esa materia.");
                ViewData["AlumnoId"] = new SelectList(_context.Alumnos.Select(a => new { a.AlumnoId, NombreCompleto = a.Nombres + " " + a.Apellidos }), "AlumnoId", "NombreCompleto", expediente.AlumnoId);
                ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NombreMateria", expediente.MateriaId);
                return View(expediente);
            }
            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                TempData["Exito"] = "Registro creado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos.Select(a => new { a.AlumnoId, NombreCompleto = a.Nombres + " " + a.Apellidos }), "AlumnoId", "NombreCompleto");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NombreMateria", expediente.MateriaId);
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos.Select(a => new { a.AlumnoId, NombreCompleto = a.Nombres + " " + a.Apellidos }), "AlumnoId", "NombreCompleto");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NombreMateria", expediente.MateriaId);
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpedienteId,AlumnoId,MateriaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            if (id != expediente.ExpedienteId)
            {
                return NotFound();
            }

            var duplicado = await _context.Expedientes
                .AnyAsync(e => e.AlumnoId == expediente.AlumnoId
                           && e.MateriaId == expediente.MateriaId
                           && e.ExpedienteId != expediente.ExpedienteId);

            if (duplicado)
            {
                ModelState.AddModelError("", "Este alumno ya tiene registrada esa materia.");
                ViewData["AlumnoId"] = new SelectList(_context.Alumnos.Select(a => new { a.AlumnoId, NombreCompleto = a.Nombres + " " + a.Apellidos }), "AlumnoId", "NombreCompleto", expediente.AlumnoId);
                ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NombreMateria", expediente.MateriaId);
                return View(expediente);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.ExpedienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Exito"] = "Registro actualizado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos.Select(a => new { a.AlumnoId, NombreCompleto = a.Nombres + " " + a.Apellidos }), "AlumnoId", "NombreCompleto");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NombreMateria", expediente.MateriaId);
            return View(expediente);
        }

        // GET: Expedientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(m => m.ExpedienteId == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente != null)
            {
                _context.Expedientes.Remove(expediente);
            }

            await _context.SaveChangesAsync();
            TempData["Exito"] = "Registro eliminado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.ExpedienteId == id);
        }

        // GET: Expedientes/Promedios
        public async Task<IActionResult> Promedios()
        {
            var expedientes = await _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .ToListAsync();

            var promedios = expedientes
                .GroupBy(e => new { e.AlumnoId, e.Alumno.Nombres, e.Alumno.Apellidos })
                .Select(g => new PromedioAlumnos
                {
                    AlumnoId = g.Key.AlumnoId,
                    Nombres = g.Key.Nombres,
                    Apellidos = g.Key.Apellidos,
                    Grado = g.First().Alumno.Grado,
                    Promedio = g.Average(e => e.NotaFinal),
                    TotalMaterias = g.Count(),
                    Expedientes = g.ToList()
                })
                .ToList();

            ViewBag.NombresAlumnos = promedios.Select(p => p.Nombres + " " + p.Apellidos).ToList();
            ViewBag.PromediosNotas = promedios.Select(p => p.Promedio).ToList();
            ViewBag.Aprobados = promedios.Count(p => p.Promedio >= 7);
            ViewBag.Reprobados = promedios.Count(p => p.Promedio < 7);

            var mejoresPorGrado = promedios
                .GroupBy(p => p.Grado)
                .SelectMany(g => g.OrderByDescending(p => p.Promedio).Take(3)
                    .Select((p, i) => new PromedioAlumnos
                    {
                        Grado = p.Grado,
                        Nombres = p.Nombres,
                        Apellidos = p.Apellidos,
                        Promedio = p.Promedio,
                        AlumnoId = p.AlumnoId,
                        TotalMaterias = p.TotalMaterias
                    }))
                .OrderBy(p => {
                    var orden = new List<string> { "Primer", "Segundo", "Tercer", "Cuarto", "Quinto", "Sexto", "Séptimo", "Octavo", "Noveno", "Bachillerato" };
                    var idx = orden.FindIndex(o => p.Grado.Contains(o));
                    return idx == -1 ? 99 : idx;
                })
                .ToList();

            ViewBag.GradosLabels = mejoresPorGrado.Select(p => p.Grado).ToList();
            ViewBag.MejoresNombres = mejoresPorGrado.Select(p => p.Nombres + " " + p.Apellidos).ToList();
            ViewBag.MejoresPromedios = mejoresPorGrado.Select(p => p.Promedio).ToList();

            return View(promedios);
        }
    }
}