using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChiTietSach : ContentPage
    {
        APIString APIString = new APIString();

        public ChiTietSach()
        {
            InitializeComponent();
        }
        public ChiTietSach(Sach sach)
        {
            InitializeComponent();
            Title = "Thông tin chi tiết sách";
            KhoiTao(sach);
        }

        async void KhoiTao(Sach sach)
        {
            image.Source = sach.Hinh;
            tensach.Text = sach.TenSach;
            mota.Text = sach.MoTa;

            giacu.Text = sach.GiaDisplayOld;
            phantramgiam.Text = sach.GiamGiaDisPlay;

            image.MinimumHeightRequest = 300;
            image.MinimumWidthRequest = 300;
            image.WidthRequest = 300;
            image.HeightRequest = 300;
            //giaban.Text = sach.Price.ToString("C");
            CultureInfo cultureInfo = new CultureInfo("vi-VN");

            //giaban.Text = string.Format(cultureInfo, "{0:C}", sach);
            giaban.Text = sach.GiaDisplayNew;

            MaSach.Text = sach.MaSach.ToString();


            TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
            if (tENDANGNHAP.Get_TenDangNhap() != null)
            {
                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "ThemSachDaXem?TenDangNhap=" + tENDANGNHAP.Get_TenDangNhap() + "&MaSach=" + sach.MaSach);
            }

        }

        private async void cmdChonMua_Clicked(object sender, EventArgs e)
        {

            TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
            if (tENDANGNHAP.Get_TenDangNhap() != null)
            {
                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "ThemSachVaoGioHang?TenDangNhap=" + tENDANGNHAP.Get_TenDangNhap() + "&MaSach=" + MaSach.Text);
                await DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
            }
            else
            {
                await DisplayAlert("Thông báo", "Bạn cần phải đăng nhập", "OK");

            }


        }
    }
}