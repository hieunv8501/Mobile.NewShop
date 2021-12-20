using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChiTietDonHang : ContentPage
    {
        public ChiTietDonHang()
        {
            InitializeComponent();
        }
        public ChiTietDonHang(HOADON hoadon)
        {
            InitializeComponent();

            //MDH.Text = "Mã đơn hàng: " + hoadon.MaHoaDon;
            //TinhTrang.Text = "Trang thái: " + hoadon.TinhTrangDisplay;
            //tennguoinhan.Text = hoadon.Tennguoinhan;
            //sdt.Text = hoadon.Sdt;
            //diachi.Text = "Địa chỉ: " + hoadon.Diachi;
            //hinhthucvanchuyen.Text = hoadon.Hinhthucvanchuyen;
            //hinhthucthanhtoan.Text = hoadon.Hinhthucthanhtoan;
            //image.Source = hoadon.Image;
            //tensach.Text = hoadon.Tensach;
            //Gia.Text = hoadon.Gia.ToString() + "đ x " + hoadon.Soluong.ToString();
            //giamgia.Text = "Giảm:" + hoadon.Giamgia.ToString() + "%";
            //Thanhtien.Text = ((hoadon.Gia - (hoadon.Gia * hoadon.Giamgia / 100)) * hoadon.Soluong).ToString() + "đ";
            //phivanchuyen.Text = hoadon.Phivanchuyen.ToString() + "đ";
            //tongthanhtoan.Text = ((hoadon.Gia - (hoadon.Gia * hoadon.Giamgia / 100)) + hoadon.Phivanchuyen).ToString() + "đ";

        }
    }
}