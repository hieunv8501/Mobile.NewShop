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
    public partial class ThemDiaChi : ContentPage
    {
        string TENDANGNHAP;
        APIString APIString = new APIString();
        public ThemDiaChi()
        {
            InitializeComponent();
        }
        public ThemDiaChi(string TenDangNhap)
        {
            InitializeComponent();
            TENDANGNHAP = TenDangNhap;
        }

        private async void bntThemDiaChi_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var CT_GIOHANG = await httpClient.GetStringAsync(APIString.str + "ThemDiaChi?TenNguoiNhan=" + TenNguoiNhan.Text + "&SDT=" + SoDienThoai.Text + "&DiaChi=" + DiaChi.Text + "&TenDangNhap=" + TENDANGNHAP);

                await DisplayAlert("Thông báo", "Thêm địa chỉ thành công", "Ok");

                await Navigation.PopAsync();

            }
            catch
            {
                await DisplayAlert("Lỗi", "Thêm địa chỉ thất bại", "Ok");
            }

        }
    }
}