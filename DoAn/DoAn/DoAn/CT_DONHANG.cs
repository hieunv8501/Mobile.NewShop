using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn
{
    public class CT_DONHANG
    {
        public int MaHoaDon { get; set; }
        public bool TinhTrang { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public string HinhThucGiao { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string Hinh { get; set; }
        public string TenSach { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
        public double PhiVanChuyen { get; set; }
        public double TongTien { get; set; }
        public string TinhTrangDisplay => (TinhTrang == false ? "Tình trạng đơn hàng: Đang giao hàng" : "Tình trạng đơn hàng: Đã giao hàng");
        public string Gia_SL => (Gia.ToString() + " x " + SoLuong.ToString());
    }
}
