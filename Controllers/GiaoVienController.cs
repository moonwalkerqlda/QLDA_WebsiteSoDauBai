using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLY_HOCSINH.Models;

namespace QLY_HOCSINH.Controllers
{
    public class GiaoVienController : Controller
    {
        private readonly QlyHocSinhContext _context;
        public GiaoVienController(QlyHocSinhContext context)
        {
            _context = context;
        }
        // GET: GiaoVien/DangKy
        public IActionResult DangKy()
        {
            return View();
        }

        // POST: GiaoVien/DangKy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy(GiaoVien model)
        {
            if (ModelState.IsValid)
            {
                _context.GiaoViens.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("DangNhap");
            }
            return View(model);
        }

        // GET: GiaoVien/DangNhap
        public IActionResult DangNhap()
        {
            return View();
        }

        // POST: GiaoVien/DangNhap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangNhap(string taiKhoan, string matKhau)
        {
            var giaoVien = await _context.GiaoViens
                .FirstOrDefaultAsync(gv => gv.TaiKhoan == taiKhoan && gv.MatKhau == matKhau);

            if (giaoVien != null)
            {
                // Add your authentication logic here
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
            return View();
        }
    }

}
