﻿using System;
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


        [Route("api/ServiceController/ThemHoaDon")]
        [HttpGet]
        public IHttpActionResult ThemHoaDon(int MaHoaDon, string TenDangNhap, System.DateTime NgayHoaDon, int MaDiaChi)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("MaHoaDon", MaHoaDon);
                param.Add("TenDangNhap", TenDangNhap);
                param.Add("NgayHoaDon", NgayHoaDon);
                param.Add("MaDiaChi", MaDiaChi);
                DataTable kq = Database.Database.Read_Table("sp_ThemHoaDon", param);
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
      

    }
}