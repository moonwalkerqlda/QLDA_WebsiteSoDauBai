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
    public class XepLopController : Controller
    {
        private readonly QlyHocSinhContext _context;

        public XepLopController(QlyHocSinhContext context)
        {
            _context = context;
        }

        // GET: XepLop
        public async Task<IActionResult> Index()
        {
            var qlyHocSinhContext = _context.XepLops.Include(x => x.Hs).Include(x => x.Lop);
            return View(await qlyHocSinhContext.ToListAsync());
        }

        // GET: XepLop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xepLop = await _context.XepLops
                .Include(x => x.Hs)
                .Include(x => x.Lop)
                .FirstOrDefaultAsync(m => m.XeplopId == id);
            if (xepLop == null)
            {
                return NotFound();
            }

            return View(xepLop);
        }

        // GET: XepLop/Create
        public IActionResult Create()
        {
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId");
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId");
            return View();
        }

        // POST: XepLop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LopId,HsId,XeplopId")] XepLop xepLop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xepLop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId", xepLop.HsId);
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", xepLop.LopId);
            return View(xepLop);
        }

        // GET: XepLop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xepLop = await _context.XepLops.FindAsync(id);
            if (xepLop == null)
            {
                return NotFound();
            }
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId", xepLop.HsId);
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", xepLop.LopId);
            return View(xepLop);
        }

        // POST: XepLop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LopId,HsId,XeplopId")] XepLop xepLop)
        {
            if (id != xepLop.XeplopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xepLop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XepLopExists(xepLop.XeplopId))
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
            ViewData["HsId"] = new SelectList(_context.HocSinhs, "HsId", "HsId", xepLop.HsId);
            ViewData["LopId"] = new SelectList(_context.LopHocs, "LopId", "LopId", xepLop.LopId);
            return View(xepLop);
        }

        // GET: XepLop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xepLop = await _context.XepLops
                .Include(x => x.Hs)
                .Include(x => x.Lop)
                .FirstOrDefaultAsync(m => m.XeplopId == id);
            if (xepLop == null)
            {
                return NotFound();
            }

            return View(xepLop);
        }

        // POST: XepLop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xepLop = await _context.XepLops.FindAsync(id);
            if (xepLop != null)
            {
                _context.XepLops.Remove(xepLop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XepLopExists(int id)
        {
            return _context.XepLops.Any(e => e.XeplopId == id);
        }
    }
}
