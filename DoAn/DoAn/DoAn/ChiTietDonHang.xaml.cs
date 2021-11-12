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
        public ChiTietDonHang(DonHang donhang)
        {
            InitializeComponent();

            MDH.Text = "Mã đơn hàng: " + donhang.Madonhang;
            TinhTrang.Text = "Trang thái: " + donhang.Tinhtrang;
            tennguoinhan.Text = donhang.Tennguoinhan;
            sdt.Text = donhang.Sdt;
            diachi.Text = "Địa chỉ: " + donhang.Diachi;
            hinhthucvanchuyen.Text = donhang.Hinhthucvanchuyen;
            hinhthucthanhtoan.Text = donhang.Hinhthucthanhtoan;
            image.Source = donhang.Image;
            tensach.Text = donhang.Tensach;
            Gia.Text = donhang.Gia.ToString() + "đ x " + donhang.Soluong.ToString();
            giamgia.Text = "Giảm:" + donhang.Giamgia.ToString() + "%";
            Thanhtien.Text = ((donhang.Gia - (donhang.Gia * donhang.Giamgia / 100)) * donhang.Soluong).ToString() + "đ";
            phivanchuyen.Text = donhang.Phivanchuyen.ToString() + "đ";
            tongthanhtoan.Text = ((donhang.Gia - (donhang.Gia * donhang.Giamgia / 100)) + donhang.Phivanchuyen).ToString() + "đ";

        }
    }
}