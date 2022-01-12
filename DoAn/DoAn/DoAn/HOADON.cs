using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn
{
    public class HOADON
    {
        public string TenSach { get; set; }
        public int SoCTHD { get; set; }
        public int MaHoaDon { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string TinhTrangDisplay => (TinhTrang == false ? "Tình trạng: Đang giao hàng" : "Tình trạng: Đã giao hàng");
        public string TenSachDisplay => (SoCTHD == 1 ? TenSach : TenSach + " và " + (SoCTHD - 1).ToString() + " sản phẩm khác");

        public string btnDisplayForAdmin => (TinhTrang == false ? "Đã giao hàng" : "Xóa");
        public string btnDisplayForUser => (TinhTrang == false ? "Hủy" : "Xóa");
    }

}
