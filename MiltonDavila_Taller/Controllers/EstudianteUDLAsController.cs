using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiltonDavila_Taller.Data;
using MiltonDavila_Taller.Models;

namespace MiltonDavila_Taller.Controllers
{
    public class EstudianteUDLAsController : Controller
    {
        private readonly MiltonDavila_TallerContext _context;

        public EstudianteUDLAsController(MiltonDavila_TallerContext context)
        {
            _context = context;
        }

        // GET: EstudianteUDLAs
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstudianteUDLA.ToListAsync());
        }

        // GET: EstudianteUDLAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteUDLA = await _context.EstudianteUDLA
                .FirstOrDefaultAsync(m => m.BannerID == id);
            if (estudianteUDLA == null)
            {
                return NotFound();
            }

            return View(estudianteUDLA);
        }

        // GET: EstudianteUDLAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstudianteUDLAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BannerID,NombreEstudiante,FechadeNacimiento")] EstudianteUDLA estudianteUDLA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteUDLA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudianteUDLA);
        }

        // GET: EstudianteUDLAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteUDLA = await _context.EstudianteUDLA.FindAsync(id);
            if (estudianteUDLA == null)
            {
                return NotFound();
            }
            return View(estudianteUDLA);
        }

        // POST: EstudianteUDLAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BannerID,NombreEstudiante,FechadeNacimiento")] EstudianteUDLA estudianteUDLA)
        {
            if (id != estudianteUDLA.BannerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteUDLA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteUDLAExists(estudianteUDLA.BannerID))
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
            return View(estudianteUDLA);
        }

        // GET: EstudianteUDLAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteUDLA = await _context.EstudianteUDLA
                .FirstOrDefaultAsync(m => m.BannerID == id);
            if (estudianteUDLA == null)
            {
                return NotFound();
            }

            return View(estudianteUDLA);
        }

        // POST: EstudianteUDLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteUDLA = await _context.EstudianteUDLA.FindAsync(id);
            if (estudianteUDLA != null)
            {
                _context.EstudianteUDLA.Remove(estudianteUDLA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteUDLAExists(int id)
        {
            return _context.EstudianteUDLA.Any(e => e.BannerID == id);
        }
    }
}
