using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn
{
    public class DIACHI
    {
        public int MaDiaChi { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public bool MacDinh { get; set; }
        public string MacDinhDisplay => (MacDinh == true ? "Địa chỉ giao hàng" : null);

    }
}
