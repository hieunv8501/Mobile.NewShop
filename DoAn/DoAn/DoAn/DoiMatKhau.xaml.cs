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
    public partial class DoiMatKhau : ContentPage
    {
        string TENDANGNHAP;
        APIString APIString = new APIString();
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public DoiMatKhau(string TenDangNhap)
        {
            InitializeComponent();
            TENDANGNHAP = TenDangNhap;

        }

        private async void save_Clicked(object sender, EventArgs e)
        {
            Thongbao1.Text = "";
            Thongbao2.Text = "";
            if (MKmoi.Text != "" && MKmoi.Text != null && MKmoi.Text.Length > 6 && XacNhan.Text.Length > 6)
            {
                if (MKmoi.Text == XacNhan.Text)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "DoiMatKhau?TenDangNhap=" + TENDANGNHAP + "&MatKhau=" + MKmoi.Text);

                        await DisplayAlert("Thông báo: ", "Đổi mật khẩu thành công", "Ok");
                        await Navigation.PopAsync();
                    }
                    catch
                    {
                        await DisplayAlert("Thông báo: ", "Đổi mật khẩu thất bại", "Ok");
                    }

                }
                else
                {

                    Thongbao2.Text = "Nhập lại mật khẩu không đúng";

                }
            }
            else
            {
                Thongbao1.Text = "Mật khẩu phải nhiều hơn 6 ký tự";
                Thongbao2.Text = "Mật khẩu phải nhiều hơn 6 ký tự";
            }
        }

        private void show_MKmoi_Clicked(object sender, EventArgs e)
        {
            if (show_MKmoi.Text == "Hiện")
            {
                MKmoi.IsPassword = false;
                show_MKmoi.Text = "Ẩn";
            }
            else
            {
                MKmoi.IsPassword = true;
                show_MKmoi.Text = "Hiện";
            }

        }

        private void show_XacNhan_Clicked(object sender, EventArgs e)
        {
            if (show_XacNhan.Text == "Hiện")
            {
                XacNhan.IsPassword = false;
                show_XacNhan.Text = "Ẩn";
            }
            else
            {
                XacNhan.IsPassword = true;
                show_XacNhan.Text = "Hiện";
            }

        }
    }
}