using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRegistrationCore.Models;

namespace StudentRegistrationCore.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowKQ(string mssv, string hoten, double diemTB, string chuyennganh)
        {
            // Lấy danh sách sinh viên từ Session
            var sinhVienDaDangKy = HttpContext.Session.GetString("SinhVienList");
            var danhSach = sinhVienDaDangKy != null
                ? JsonConvert.DeserializeObject<List<SinhVien>>(sinhVienDaDangKy)
                : new List<SinhVien>();

            // Thêm sinh viên mới
            var sinhVienMoi = new SinhVien
            {
                MSSV = mssv,
                HoTen = hoten,
                DiemTB = diemTB,
                ChuyenNganh = chuyennganh
            };
            danhSach.Add(sinhVienMoi);

            // Lưu danh sách vào Session
            HttpContext.Session.SetString("SinhVienList", JsonConvert.SerializeObject(danhSach));

            // Đếm số lượng sinh viên cùng ngành
            int soLuongCungNganh = danhSach.Count(sv => sv.ChuyenNganh == chuyennganh);

            // Truyền dữ liệu sang View
            ViewBag.MSSV = mssv;
            ViewBag.HoTen = hoten;
            ViewBag.ChuyenNganh = chuyennganh;
            ViewBag.SoLuongCungNganh = soLuongCungNganh;

            return View();
        }
    }
}
