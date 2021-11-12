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
    public partial class DonHangCuaToi : ContentPage
    {
        public DonHangCuaToi()
        {
            InitializeComponent();
            List<DonHang> donHangs = new List<DonHang>();
            donHangs.Add(new DonHang
            {
                Tensach = "Tuyển chọn 400 Bài toán Đại số 10",
                Madonhang = "2770699959",
                Tinhtrang = "Đơn hàng mới",
                Icon = "icon_next.png",
                Tennguoinhan = "Bùi Văn Tình",
                Sdt = "0968568803",
                Diachi = "Hòa Đại, Cát Hiệp, Phù Cát, Bình Định",
                Hinhthucvanchuyen = "VAT",
                Hinhthucthanhtoan = "Thanh toán khi nhận hàng",
                Image = "baitoandaiso.jfif",
                Gia = 53950,
                Giamgia = 17,
                Soluong = 1,
                Phivanchuyen = 29000,


            });
            donHangs.Add(new DonHang
            {
                Tensach = "Sách ngữ văn lớp 12",
                Madonhang = "2770699960",
                Tinhtrang = "Đang vận chuyển",
                Icon = "icon_next.png",
                Tennguoinhan = "Bùi Văn Tình",
                Sdt = "0968568803",
                Diachi = "Hòa Đại, Cát Hiệp, Phù Cát, Bình Định",
                Hinhthucvanchuyen = "VAT",
                Hinhthucthanhtoan = "Thanh toán khi nhận hàng",
                Image = "baitoandaiso.jfif",
                Gia = 59950,
                Giamgia = 20,
                Soluong = 2,
                Phivanchuyen = 29000,
            });
            lst_donhang.ItemsSource = donHangs;
        }
        private void lst_donhang_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DonHang donHang = (DonHang)lst_donhang.SelectedItem;
            lst_donhang.SelectedItem = "";
            Navigation.PushAsync(new ChiTietDonHang(donHang));
        }
    }
}