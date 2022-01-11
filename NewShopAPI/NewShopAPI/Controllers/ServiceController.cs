using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewShopAPI.Database;

namespace NewShopAPI.Controllers
{
    public class ServiceController : ApiController
    {
        [Route("api/ServiceController/LayDanhSachTaiKhoan")]
        [HttpGet]
        public IHttpActionResult LayDanhSachTaiKhoan()
        {
            DataTable kq = Database.Database.Read_Table("sp_LayDanhSachTaiKhoan");
            if (kq != null && kq.Rows.Count > 0)
                return Ok(kq);
            else
                return NotFound();
        }


        [Route("api/ServiceController/ThemTaiKhoan")]
        [HttpGet]
        public IHttpActionResult ThemTaiKhoan(string TenDangNhap, string MatKhau, string TenKhachHang, string SoDienThoai, string Email, DateTime NgaySinh, int GioiTinh,int IsAdmin)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("MatKhau", MatKhau);
                param.Add("TenKhachHang", TenKhachHang);
                param.Add("SoDienThoai", SoDienThoai);
                param.Add("Email", Email);
                param.Add("NgaySinh", NgaySinh);
                param.Add("GioiTinh", GioiTinh);
                param.Add("IsAdmin", IsAdmin);
                int kq = int.Parse(Database.Database.Exec_Command("sp_ThemTaiKhoan", param).ToString());
                if (kq > 0)
                    return Ok(kq);
                else
                    return NotFound();
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayDanhSachLoaiSach")]
        [HttpGet]
        public IHttpActionResult LayDanhSachLoaiSach()
        {
            DataTable kq = Database.Database.Read_Table("sp_LayDanhSachLoaiSach");
            if (kq != null && kq.Rows.Count > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/ServiceController/LayDanhSachSachTheoKhuyenMai")]
        [HttpGet]
        public IHttpActionResult LayDanhSachSachTheoKhuyenMai()
        {
            DataTable kq = Database.Database.Read_Table("sp_LayDanhSachSachTheoKhuyenMai");
            if (kq != null && kq.Rows.Count > 0)
                return Ok(kq);
            else
                return NotFound();

        }

        [Route("api/ServiceController/LayDanhSachSach")]
        [HttpGet]
        public IHttpActionResult LayDanhSachSach()
        {
            DataTable kq = Database.Database.Read_Table("sp_LayDanhSachSach");
            if (kq != null && kq.Rows.Count > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/ServiceController/LayDanhSachSachTheoLoaiSach")]
        [HttpGet]
        public IHttpActionResult LayDanhSachSachTheoLoaiSach(int MaLoaiSach)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaLoaiSach", MaLoaiSach);
                DataTable kq = Database.Database.Read_Table("sp_LayDanhSachSachTheoLoaiSach", param);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/LayHoaDonTheoTenDangNhap")]
        [HttpGet]
        public IHttpActionResult LayHoaDonTheoTenDangNhap(string TenDangNhap)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                DataTable kq = Database.Database.Read_Table("sp_LayHoaDonTheoTenDangNhap", param);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/LayCTHDTheoMaHoaDon")]
        [HttpGet]
        public IHttpActionResult LayCTHDTheoMaHoaDon(int MaHoaDon)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaHoaDon", MaHoaDon);
                DataTable kq = Database.Database.Read_Table("sp_LayCTHDTheoMaHoaDon", param);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


        //[Route("api/ServiceController/ThemHoaDon")]
        //[HttpGet]
        //public IHttpActionResult ThemHoaDon(int MaHoaDon, string TenDangNhap, System.DateTime NgayHoaDon, int MaDiaChi)
        //{
        //    try
        //    {
        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("MaHoaDon", MaHoaDon);
        //        param.Add("TenDangNhap", TenDangNhap);
        //        param.Add("NgayHoaDon", NgayHoaDon);
        //        param.Add("MaDiaChi", MaDiaChi);
        //        DataTable kq = Database.Database.Read_Table("sp_ThemHoaDon", param);
        //        return Ok(kq);
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}


        //[Route("api/ServiceController/ThemChiTietHoaDon")]
        //[HttpGet]
        //public IHttpActionResult ThemChiTietHoaDon(int MaHoaDon, int MaSach, int SoLuong, Nullable<decimal> TongTien)
        //{
        //    try
        //    {
        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("MaHoaDon", MaHoaDon);
        //        param.Add("MaSach", MaSach);
        //        param.Add("SoLuong", SoLuong);
        //        param.Add("TongTien", TongTien);
        //        DataTable kq = Database.Database.Read_Table("sp_ThemChiTietHoaDon", param);
        //        return Ok(kq);
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}


        [Route("api/ServiceController/LayThongTinGioHang")]
        [HttpGet]
        public IHttpActionResult LayThongTinGioHang(string TenDangNhap)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);

                DataTable result = Database.Database.Read_Table("sp_LayThongTinGioHang", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/TangSoLuong")]
        [HttpGet]
        public IHttpActionResult TangSoLuong(int MaGioHang, int MaSach)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGioHang", MaGioHang);
                param.Add("MaSach", MaSach);

                DataTable result = Database.Database.Read_Table("sp_TangSoLuong", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/GiamSoLuong")]
        [HttpGet]
        public IHttpActionResult GiamSoLuong(int MaGioHang, int MaSach)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGioHang", MaGioHang);
                param.Add("MaSach", MaSach);

                DataTable result = Database.Database.Read_Table("sp_GiamSoLuong", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }
        //LoaiSach
        [Route("api/ServiceController/ThemLoaiSach")]
        [HttpGet]
        public IHttpActionResult ThemLoaiSach(string TenLoaiSach, string Hinh)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenLoaiSach", TenLoaiSach);
                param.Add("Hinh", Hinh);

                int kq = int.Parse(Database.Database.Exec_Command("sp_ThemLoaiSach", param).ToString());
                if (kq > 0)
                    return Ok(kq);
                else
                    return NotFound();
            }
            catch
            { return NotFound(); }
        }
        [Route("api/ServiceController/XoaLoaiSach")]
        [HttpGet]
        public IHttpActionResult XoaLoaiSach(int MaLoaiSach)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("MaLoaiSach", MaLoaiSach);
            int kq = int.Parse(Database.Database.Exec_Command("sp_XoaLoaiSach", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }
        [Route("api/ServiceController/CapNhatLoaiSach")]
        [HttpGet]
        public IHttpActionResult CapNhatLoaiSach(int MaLoaiSach, string TenLoaiSach, string Hinh)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("MaLoaiSach", MaLoaiSach);
            param.Add("TenLoaiSach", TenLoaiSach);
            param.Add("Hinh", Hinh);
            int kq = int.Parse(Database.Database.Exec_Command("sp_CapNhatLoaiSach", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        //Sach
        [Route("api/ServiceController/ThemSach")]
        [HttpGet]
        public IHttpActionResult ThemSach(int MaLoaiSach, string TenSach, double Gia, string MoTa, string Hinh, int GiamGia)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("MaLoaiSach", MaLoaiSach);
            param.Add("TenSach", TenSach);
            param.Add("Gia", Gia);
            param.Add("MoTa", MoTa);
            param.Add("Hinh", Hinh);
            param.Add("GiamGia", GiamGia);
            int kq = int.Parse(Database.Database.Exec_Command("sp_ThemSach", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();

        }

        [Route("api/ServiceController/CapNhatSach")]
        [HttpGet]
        public IHttpActionResult CapNhatSach(int MaSach, int MaLoaiSach, string TenSach, double Gia, string MoTa, string Hinh, int GiamGia)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("MaSach", MaSach);
            param.Add("MaLoaiSach", MaLoaiSach);
            param.Add("TenSach", TenSach);
            param.Add("Gia", Gia);
            param.Add("MoTa", MoTa);
            param.Add("Hinh", Hinh);
            param.Add("GiamGia", GiamGia);
            int kq = int.Parse(Database.Database.Exec_Command("sp_CapNhatSach", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();

        }

        [Route("api/ServiceController/XoaSach")]
        [HttpGet]
        public IHttpActionResult XoaSach(int MaSach)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("MaSach", MaSach);
            int kq = int.Parse(Database.Database.Exec_Command("sp_XoaSach", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        // Sử dụng mã giảm giá
        [Route("api/ServiceController/ApDungMa")]
        [HttpGet]
        public IHttpActionResult ApDungMaGiamGia(string MaGiamGia, int MaGioHang)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGiamGia", MaGiamGia);
                param.Add("MaGioHang", MaGioHang);

                DataTable result = Database.Database.Read_Table("sp_ApDungMa", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }


        [Route("api/ServiceController/ThemHoaDon")]
        [HttpGet]
        public IHttpActionResult ThemHoaDon(string TenDangNhap, DateTime NgayHoaDon, int MaDiaChi)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("NgayHoaDon", NgayHoaDon);
                param.Add("MaDiaChi", MaDiaChi);

                DataTable result = Database.Database.Read_Table("sp_ThemHoaDon", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayThongTinHoaDon")]
        [HttpGet]
        public IHttpActionResult LayThongTinHoaDon(string TenDangNhap)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);

                DataTable result = Database.Database.Read_Table("sp_LayThongTinHoaDon", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayChiTietHoaDon")]
        [HttpGet]
        public IHttpActionResult LayChiTietHoaDon(int MaHoaDon)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaHoaDon", MaHoaDon);

                DataTable result = Database.Database.Read_Table("sp_LayChiTietHoaDon", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/ThemDiaChi")]
        [HttpGet]
        public IHttpActionResult ThemDiaChi(string TenNguoiNhan, string SDT, string DiaChi, string TenDangNhap)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenNguoiNhan", TenNguoiNhan);
                param.Add("SDT", SDT);
                param.Add("DiaChi", DiaChi);
                param.Add("TenDangNhap", TenDangNhap);

                DataTable result = Database.Database.Read_Table("sp_ThemDiaChi", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/XoaDiaChi")]
        [HttpGet]
        public IHttpActionResult XoaDiaChi(int MaDiaChi)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaDiaChi", MaDiaChi);


                DataTable result = Database.Database.Read_Table("sp_XoaDiaChi", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }


        [Route("api/ServiceController/ThayDoiDiaChiMacDinh")]
        [HttpGet]
        public IHttpActionResult ThayDoiDiaChiMacDinh(int MaDiaChi, string TenDangNhap)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaDiaChi", MaDiaChi);
                param.Add("TenDangNhap", TenDangNhap);

                DataTable result = Database.Database.Read_Table("sp_ThayDoiDiaChiMacDinh", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayDiaChi")]
        [HttpGet]
        public IHttpActionResult LayDiaChi(string TenDangNhap)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);

                DataTable result = Database.Database.Read_Table("sp_LayDiaChi", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayGiaGiaoHang")]
        [HttpGet]
        public IHttpActionResult LayGiaGiaoHang()
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();

                DataTable result = Database.Database.Read_Table("sp_LayGiaGiaoHang");

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/SuaGiaGiaoHang")]
        [HttpGet]
        public IHttpActionResult SuaGiaGiaoHang(double Gia)
        {

            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("Gia", Gia);

                DataTable result = Database.Database.Read_Table("sp_SuaGiaGiaoHang", param);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        //phan Tai Khoan
        [Route("api/ServiceController/CapNhatTaiKhoan")]
        [HttpGet]
        public IHttpActionResult CapNhatTaiKhoan(string TenDangNhap, string MatKhau, string TenKhachHang, string SoDienThoai, string Email, DateTime NgaySinh, int GioiTinh, int IsAdmin)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TenDangNhap", TenDangNhap);
            param.Add("MatKhau", MatKhau);
            param.Add("TenKhachHang", TenKhachHang);
            param.Add("SoDienThoai", SoDienThoai);
            param.Add("Email", Email);
            param.Add("NgaySinh", NgaySinh);
            param.Add("GioiTinh", GioiTinh);
            param.Add("IsAdmin", IsAdmin);
            int kq = int.Parse(Database.Database.Exec_Command("sp_CapNhatTaiKhoan", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/ServiceController/XoaTaiKhoan")]
        [HttpGet]
        public IHttpActionResult XoaTaiKhoan(string TenDangNhap)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TenDangNhap", TenDangNhap);
            int kq = int.Parse(Database.Database.Exec_Command("sp_XoaTaiKhoan", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/ServiceController/LayTatCaHoaDon")]
        [HttpGet]
        public IHttpActionResult LayTatCaHoaDon()
        {
            try
            {
                DataTable result = Database.Database.Read_Table("sp_LayTatCaHoaDon");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/CapNhapTinhTrangHoaDon")]
        [HttpGet]
        public IHttpActionResult CapNhapTinhTrangHoaDon(int MaHoaDon)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaHoaDon", MaHoaDon);
                DataTable result = Database.Database.Read_Table("sp_CapNhapTinhTrangHoaDon", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/XoaChiTietHoaDon")]
        [HttpGet]
        public IHttpActionResult XoaChiTietHoaDon(int MaHoaDon)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaHoaDon", MaHoaDon);
                DataTable result = Database.Database.Read_Table("sp_XoaChiTietHoaDon", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/CheckDiaChi")]
        [HttpGet]
        public IHttpActionResult CheckDiaChi(int MaDiaChi)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaDiaChi", MaDiaChi);
                DataTable result = Database.Database.Read_Table("sp_CheckDiaChi", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayThongTinHoaDonTheoMa")]
        [HttpGet]
        public IHttpActionResult LayThongTinHoaDonTheoMa(int MaHoaDon)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaHoaDon", MaHoaDon);
                DataTable result = Database.Database.Read_Table("sp_LayThongTinHoaDonTheoMa", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }


        [Route("api/ServiceController/LayDanhSachMaGiamGia")]
        [HttpGet]
        public IHttpActionResult LayDanhSachMaGiamGia()
        {
            try
            {

                DataTable result = Database.Database.Read_Table("sp_LayDanhSachMaGiamGia");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/ThemMaGiamGia")]
        [HttpGet]
        public IHttpActionResult ThemMaGiamGia(string MaGiamGia, int TiLeGiam)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGiamGia", MaGiamGia);
                param.Add("TiLeGiam", TiLeGiam);

                DataTable result = Database.Database.Read_Table("sp_ThemMaGiamGia", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/XoaMaGiamGia")]
        [HttpGet]
        public IHttpActionResult XoaMaGiamGia(string MaGiamGia)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGiamGia", MaGiamGia);

                DataTable result = Database.Database.Read_Table("sp_XoaMaGiamGia", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LayMaGiamGia")]
        [HttpGet]
        public IHttpActionResult LayMaGiamGia(string MaGiamGia)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGiamGia", MaGiamGia);

                DataTable result = Database.Database.Read_Table("sp_LayMaGiamGia", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/SuaMaGiamGia")]
        [HttpGet]
        public IHttpActionResult SuaMaGiamGia(string MaGiamGia, int TiLeGiam)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaGiamGia", MaGiamGia);
                param.Add("TiLeGiam", TiLeGiam);

                DataTable result = Database.Database.Read_Table("sp_SuaMaGiamGia", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/ThemSachVaoGioHang")]
        [HttpGet]
        public IHttpActionResult ThemSachVaoGioHang(string TenDangNhap, int MaSach)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("MaSach", MaSach);

                DataTable result = Database.Database.Read_Table("sp_ThemSachVaoGioHang", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }


        [Route("api/ServiceController/LayThongTinSPDaXem")]
        [HttpGet]
        public IHttpActionResult LayThongTinSPDaXem(string TenDangNhap)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);

                DataTable result = Database.Database.Read_Table("sp_LayThongTinSPDaXem", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/ThemSachDaXem")]
        [HttpGet]
        public IHttpActionResult ThemSachDaXem(string TenDangNhap, int MaSach)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("MaSach", MaSach);

                DataTable result = Database.Database.Read_Table("sp_ThemSachDaXem", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }


        [Route("api/ServiceController/LayThongTinTaiKhoan")]
        [HttpGet]
        public IHttpActionResult LayThongTinTaiKhoan(string TenDangNhap)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TenDangNhap", TenDangNhap);
            DataTable kq = Database.Database.Read_Table("sp_LayThongTinTaiKhoan", param);
            if (kq != null && kq.Rows.Count > 0)
                return Ok(kq);
            else
                return NotFound();
        }


        [Route("api/ServiceController/SuaThongTinTaiKhoan")]
        [HttpGet]
        public IHttpActionResult SuaThongTinTaiKhoan(string TenDangNhap, string TenKhachHang, string SoDienThoai, string Email, DateTime NgaySinh, bool GioiTinh)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("TenKhachHang", TenKhachHang);
                param.Add("SoDienThoai", SoDienThoai);
                param.Add("Email", Email);
                param.Add("NgaySinh", NgaySinh);
                param.Add("GioiTinh", GioiTinh);

                DataTable result = Database.Database.Read_Table("sp_SuaThongTinTaiKhoan", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/DoiMatKhau")]
        [HttpGet]
        public IHttpActionResult DoiMatKhau(string TenDangNhap, string MatKhau)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("MatKhau", MatKhau);


                DataTable result = Database.Database.Read_Table("sp_DoiMatKhau", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Route("api/ServiceController/LaySachTheoMaSach")]
        [HttpGet]
        public IHttpActionResult LaySachTheoMaSach(string MaSach)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaSach", MaSach);


                DataTable result = Database.Database.Read_Table("sp_LaySachTheoMaSach", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

    }
}
