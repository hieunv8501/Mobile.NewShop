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
        public IHttpActionResult ThemTaiKhoan(string TenDangNhap, string MatKhau, string TenKhachHang, string SoDienThoai, string Email, DateTime NgaySinh, bool GioiTinh)
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
                DataTable kq = Database.Database.Read_Table("sp_ThemTaiKhoan", param);
                return Ok(kq);
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


    }
}
