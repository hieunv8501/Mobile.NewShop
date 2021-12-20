using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn
{
    public class HOADON
    {
        public int MaHoaDon { get; set; }
        public string TenDangNhap { get; set; }
        public System.DateTime NgayHoaDon { get; set; }
        public string HinhThucGiao { get; set; }
        public string HinhThucThanhToan { get; set; }
        public int MaDiaChi { get; set; }
        public Nullable<Decimal> TongTien { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string TinhTrangDisplay => (TinhTrang == true ? "Tình trạng: Đã" : "Tình trạng: Chưa") + " thanh toán";
    }

}
