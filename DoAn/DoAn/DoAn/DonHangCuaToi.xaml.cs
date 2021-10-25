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
                tensach = "Tuyển chọn 400 Bài toán Đại số 10",
                madonhang = "2770699959",
                tinhtrang = "Đơn hàng mới",
                icon = "icon_next.png",
                tennguoinhan = "Bùi Văn Tình",
                sdt = "0968568803",
                diachi = "Hòa Đại, Cát Hiệp, Phù Cát, Bình Định",
                hinhthucvanchuyen = "VAT",
                hinhthucthanhtoan = "Thanh toán khi nhận hàng",
                image = "baitoandaiso.jfif",
                gia = 53950,
                giamgia = 17,
                soluong = 1,
                phivanchuyen = 29000,


            });
            donHangs.Add(new DonHang
            {
                tensach = "Sách ngữ văn lớp 12",
                madonhang = "2770699960",
                tinhtrang = "Đang vận chuyển",
                icon = "icon_next.png",
                tennguoinhan = "Bùi Văn Tình",
                sdt = "0968568803",
                diachi = "Hòa Đại, Cát Hiệp, Phù Cát, Bình Định",
                hinhthucvanchuyen = "VAT",
                hinhthucthanhtoan = "Thanh toán khi nhận hàng",
                image = "baitoandaiso.jfif",
                gia = 59950,
                giamgia = 20,
                soluong = 2,
                phivanchuyen = 29000,
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