﻿using System;
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
    public partial class ThemTaiKhoan : ContentPage
    {
        APIString APIString = new APIString();

        public ThemTaiKhoan()
        {
            InitializeComponent();
            GenderCreate();
        }

        private async void btnThemTaiKhoan_Clicked(object sender, EventArgs e)
        {
            string TenDangNhap = dktdn.Text;
            string MatKhau = dkmk.Text;
            string TenKhachHang = dkhoten.Text;
            string Email = dkemail.Text;
            string SoDienThoai = dksdt.Text;
            string NgaySinh = dd;
            int GioiTinh = 1;
            int IsAdmin = 0;

            if (dkgender.Title == "Nam") GioiTinh = 1;
            else if (dkgender.Title == "Nữ")
            {
                GioiTinh = 0;
            }
            if (isadmin.IsToggled == true) IsAdmin = 1;
            else if (isadmin.IsToggled == false)
            {
                IsAdmin = 0;
            }
            //await DisplayAlert("Data", TenDangNhap + MatKhau + TenKhachHang + Email + SoDienThoai + NgaySinh + GioiTinh + IsAdmin, "OK");

            if (TenDangNhap == "" || TenKhachHang == "" || MatKhau == "" || Email == "" || SoDienThoai == "" || NgaySinh == "")
            {
                _ = DisplayAlert("Thông báo", "Bạn chưa nhập đầy đủ thông tin", "OK");
            }
            else
            {
                var httpClient = new HttpClient();
                var res = await httpClient.GetStringAsync(APIString.str + "ThemTaiKhoan?TenDangNhap=" + TenDangNhap + "&MatKhau=" + MatKhau + "&TenKhachHang=" + TenKhachHang + "&Email=" + Email + "&SoDienThoai=" + SoDienThoai + "&NgaySinh=" + NgaySinh + "&GioiTinh=" + GioiTinh.ToString() + "&IsAdmin=" + IsAdmin.ToString());
                _ = DisplayAlert("Thông báo", "Thêm tài khoản thành công", "OK");
                await Navigation.PushAsync(new DangNhap()).ConfigureAwait(false);
            }
        }
        private void GenderCreate()
        {
            var genders = new List<string>();
            genders.Add("Nam");
            genders.Add("Nữ");
            dkgender.ItemsSource = genders;
        }

        private void dkgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genpicker = (Picker)sender;
            int selectedIndex = genpicker.SelectedIndex;

            if (selectedIndex != -1)
            {
                dkgender.Title = (string)genpicker.ItemsSource[selectedIndex];
            }
        }
        string dd = "";
        private void dkdob_DateSelected(object sender, DateChangedEventArgs e)
        {
            CultureInfo englishUSCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = englishUSCulture;
            dd = e.NewDate.ToString("dd/MM/yyyy");
        }

    }
}