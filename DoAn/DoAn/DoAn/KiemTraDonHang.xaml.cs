using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KiemTraDonHang : ContentPage
    {
        APIString APIString = new APIString();
        public KiemTraDonHang()
        {
            InitializeComponent();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "Tên đăng nhập";
            lblEmail.TextColor = Color.Blue;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "";
        }

        private void Entry_Focused_1(object sender, FocusEventArgs e)
        {
            lbMaDonHang.Text = "Mã đơn hàng";
            lbMaDonHang.TextColor = Color.Blue;
        }

        private void Entry_Unfocused_1(object sender, FocusEventArgs e)
        {
            lbMaDonHang.Text = "";

        }

        private async void check_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "KiemTraDonHang?TenDangNhap=" + lbTenDangNhap.Text + "&MaHoaDon=" + lbMaDonHang.Text);
            if (ConnectAPI.ToString() == "[]")
            {

                await DisplayAlert("Thông báo", "Không tìm thấy đơn hàng", "Ok");

            }
            else
            {
                var ConnectAPIConvert = JsonConvert.DeserializeObject<List<HOADON>>(ConnectAPI);
                await Navigation.PushAsync(new ChiTietDonHang(ConnectAPIConvert.First().MaHoaDon));
            }
        }
    }
}