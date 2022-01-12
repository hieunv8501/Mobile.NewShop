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
    public partial class Admin_CapNhatTaiKhoan : ContentPage
    {
        public Admin_CapNhatTaiKhoan()
        {
            InitializeComponent();
        }
        TAIKHOAN taikhoan = new TAIKHOAN();
        public Admin_CapNhatTaiKhoan(TAIKHOAN taikhoan1)
        {
            InitializeComponent();
            Title = "Cập nhật tài khoản: " + taikhoan1.TenDangNhap;
            taikhoan = taikhoan1;
            txtMatKhau.Text = taikhoan1.MatKhau; ;
            txtTenKhachHang.Text = taikhoan1.TenKhachHang;
            txtSDT.Text = taikhoan1.SoDienThoai;
            txtEmail.Text = taikhoan1.Email;
            txtngaysinh.Date = taikhoan1.NgaySinh.Date;
            ChonGioiTinh.SelectedIndex = taikhoan1.GioiTinh;
            if(taikhoan1.IsAdmin==1)
            {
                IsAdmin.IsChecked = true;
            }
            else
            {
                IsAdmin.IsChecked = false;
            }
            
        }
        
        
        private async void cmdCapNhatTaiKhoan_Clicked(object sender, EventArgs e)
        {

            HttpClient http = new HttpClient();
            try
            {
                int c = IsAdmin.IsChecked ? 1 : 0;
                var kq = await http.GetStringAsync("http://172.20.10.4/newshopwebapi/api/ServiceController/CapNhatTaiKhoan?TenDangNhap=" + taikhoan.TenDangNhap + "&MatKhau=" + txtMatKhau.Text + "&TenKhachHang=" + txtTenKhachHang.Text + "&SoDienThoai=" + txtSDT.Text + "&Email=" + txtEmail.Text + "&NgaySinh=" + txtngaysinh.Date + "&GioiTinh=" + ChonGioiTinh.SelectedIndex + "&IsAdmin=" + c);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã thêm tài khoản thành công", "OK");
                    await Navigation.PushAsync(new TaiKhoanAdmin());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Cập nhật tài khoản thất bại ", "OK");
                }

            }
            catch
            {
                {
                    await DisplayAlert("Thông Báo", "Cập nhật tài khoản thất bại", "OK");
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