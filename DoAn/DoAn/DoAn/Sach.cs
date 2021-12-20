using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn
{
    public class Sach
    {
        public int MaSach { get; set; }
        public int MaLoaiSach { get; set; }
        public string TenSach { get; set; }
        public string Hinh { get; set; }
        public string MoTa { get; set; }
        public Nullable<Decimal> Gia { get; set; }
        public string GiaDisplay => $"{Gia} vnd";

    }
}
