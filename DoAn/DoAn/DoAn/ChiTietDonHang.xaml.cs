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

            MDH.Text = "Mã đơn hàng: " + donhang.madonhang;
            TinhTrang.Text = "Trang thái: " + donhang.tinhtrang;
            tennguoinhan.Text = donhang.tennguoinhan;
            sdt.Text = donhang.sdt;
            diachi.Text = "Địa chỉ: " + donhang.diachi;
            hinhthucvanchuyen.Text = donhang.hinhthucvanchuyen;
            hinhthucthanhtoan.Text = donhang.hinhthucthanhtoan;
            image.Source = donhang.image;
            tensach.Text = donhang.tensach;
            Gia.Text = donhang.gia.ToString() + "đ x " + donhang.soluong.ToString();
            giamgia.Text = "Giảm:" + donhang.giamgia.ToString() + "%";
            Thanhtien.Text = ((donhang.gia - (donhang.gia * donhang.giamgia / 100)) * donhang.soluong).ToString() + "đ";
            phivanchuyen.Text = donhang.phivanchuyen.ToString() + "đ";
            tongthanhtoan.Text = ((donhang.gia - (donhang.gia * donhang.giamgia / 100)) + donhang.phivanchuyen).ToString() + "đ";

        }
    }
}