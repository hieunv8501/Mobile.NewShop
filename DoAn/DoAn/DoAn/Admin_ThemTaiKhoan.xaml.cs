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
    public partial class Admin_ThemTaiKhoan : ContentPage
    {
        public Admin_ThemTaiKhoan()
        {
            InitializeComponent();
            Title = "Thêm Tài Khoản";
        
        }
        private async void cmdAddTaiKhoan_Clicked(object sender, EventArgs e)
        {
          
            HttpClient http = new HttpClient();
            try
            {
                int c = IsAdmin.IsChecked ? 1 : 0;
                var kq = await http.GetStringAsync("http://172.20.10.4/newshopwebapi/api/ServiceController/ThemTaiKhoan?TenDangNhap=" + txtTenDN.Text + "&MatKhau=" + txtMatKhau.Text + "&TenKhachHang=" + txtTenKhachHang + "&SoDienThoai=" + txtSDT.Text + "&Email=" + txtEmail.Text + "&NgaySinh=" + txtngaysinh.Date + "&GioiTinh=" + ChonGioiTinh.SelectedIndex + "&IsAdmin=" + c);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã thêm tài khoản thành công", "OK");
                    await Navigation.PushAsync(new TaiKhoanAdmin());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Thêm tài khoản thất bại ", "OK");
                }

            }
            catch
            {
                {
                    await DisplayAlert("Thông Báo", "Thêm tài khoản thất bại", "OK");
                }
            }

        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (txtMatKhau.IsPassword)
            {
                txtMatKhau.IsPassword = false;
                show_pass_eye.Source = "hidepass.png";
            }
            else
            {
                txtMatKhau.IsPassword = true;
                show_pass_eye.Source = "showpass.png";
            }
        }

    }
}