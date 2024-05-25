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
    public class DiemDanhController : Controller
    {
        private readonly QlyHocSinhContext _context;

        public DiemDanhController(QlyHocSinhContext context)
        {
            _context = context;
        }

        // GET: DiemDanh
        public async Task<IActionResult> Index()
        {
            var qlyHocSinhContext = _context.DiemDanh.Include(d => d.Hs).Include(d => d.Lop);
            return View(await qlyHocSinhContext.ToListAsync());
        }

        // GET: DiemDanh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemDanh = await _context.DiemDanh
                .Include(d => d.Hs)
                .Include(d => d.Lop)
                .FirstOrDefaultAsync(m => m.DiemDanhId == id);
            if (diemDanh == null)
            {
                return NotFound();
            }

            return View(diemDanh);
        }

        // GET: DiemDanh/Create
        public IActionResult Create()
        {
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId");
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId");
            return View();
        }

        // POST: DiemDanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiemDanhId,LopId,Ngay,HsId,TrangThai")] DiemDanh diemDanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemDanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId", diemDanh.HsId);
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", diemDanh.LopId);
            return View(diemDanh);
        }

        // GET: DiemDanh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemDanh = await _context.DiemDanh.FindAsync(id);
            if (diemDanh == null)
            {
                return NotFound();
            }
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId", diemDanh.HsId);
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", diemDanh.LopId);
            return View(diemDanh);
        }

        // POST: DiemDanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiemDanhId,LopId,Ngay,HsId,TrangThai")] DiemDanh diemDanh)
        {
            if (id != diemDanh.DiemDanhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemDanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemDanhExists(diemDanh.DiemDanhId))
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
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId", diemDanh.HsId);
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", diemDanh.LopId);
            return View(diemDanh);
        }

        // GET: DiemDanh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemDanh = await _context.DiemDanh
                .Include(d => d.Hs)
                .Include(d => d.Lop)
                .FirstOrDefaultAsync(m => m.DiemDanhId == id);
            if (diemDanh == null)
            {
                return NotFound();
            }

            return View(diemDanh);
        }

        // POST: DiemDanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diemDanh = await _context.DiemDanh.FindAsync(id);
            if (diemDanh != null)
            {
                _context.DiemDanh.Remove(diemDanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemDanhExists(int id)
        {
            return _context.DiemDanh.Any(e => e.DiemDanhId == id);
        }
    }
}
