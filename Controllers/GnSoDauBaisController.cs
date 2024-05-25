using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLY_HOCSINH.Models;

namespace QLY_HOCSINH.Controllers
{
    public class GnSoDauBaisController : Controller
    {
        private readonly QlyHocSinhContext _context;

        public GnSoDauBaisController(QlyHocSinhContext context)
        {
            _context = context;
        }

        // GET: GnSoDauBais
        public async Task<IActionResult> Index()
        {
            var qlyHocSinhContext = _context.GnSoDauBais.Include(g => g.Lop);
            return View(await qlyHocSinhContext.ToListAsync());
        }

        // GET: GnSoDauBais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gnSoDauBai = await _context.GnSoDauBais
                .Include(g => g.Lop)
                .FirstOrDefaultAsync(m => m.GnId == id);
            if (gnSoDauBai == null)
            {
                return NotFound();
            }

            return View(gnSoDauBai);
        }

        // GET: GnSoDauBais/Create
        public IActionResult Create()
        {
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId");
            return View();
        }

        // POST: GnSoDauBais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ngay,LopId,Noidung,GnId")] GnSoDauBai gnSoDauBai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gnSoDauBai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", gnSoDauBai.LopId);
            return View(gnSoDauBai);
        }

        // GET: GnSoDauBais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gnSoDauBai = await _context.GnSoDauBais.FindAsync(id);
            if (gnSoDauBai == null)
            {
                return NotFound();
            }
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", gnSoDauBai.LopId);
            return View(gnSoDauBai);
        }

        // POST: GnSoDauBais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ngay,LopId,Noidung,GnId")] GnSoDauBai gnSoDauBai)
        {
            if (id != gnSoDauBai.GnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gnSoDauBai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GnSoDauBaiExists(gnSoDauBai.GnId))
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
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", gnSoDauBai.LopId);
            return View(gnSoDauBai);
        }

        // GET: GnSoDauBais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gnSoDauBai = await _context.GnSoDauBais
                .Include(g => g.Lop)
                .FirstOrDefaultAsync(m => m.GnId == id);
            if (gnSoDauBai == null)
            {
                return NotFound();
            }

            return View(gnSoDauBai);
        }

        // POST: GnSoDauBais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gnSoDauBai = await _context.GnSoDauBais.FindAsync(id);
            if (gnSoDauBai != null)
            {
                _context.GnSoDauBais.Remove(gnSoDauBai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GnSoDauBaiExists(int id)
        {
            return _context.GnSoDauBais.Any(e => e.GnId == id);
        }
    }
}
