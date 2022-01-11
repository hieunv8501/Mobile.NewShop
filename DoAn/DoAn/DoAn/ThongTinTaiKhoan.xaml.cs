using Newtonsoft.Json;
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
    public partial class ThongTinTaiKhoan : ContentPage
    {
        string TENDANGNHAP;
        APIString APIString = new APIString();
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }
        public ThongTinTaiKhoan(string TenDangNhap)
        {
            InitializeComponent();
            TENDANGNHAP = TenDangNhap;
            KhoiTao();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            KhoiTao();
        }

        async void KhoiTao()
        {
            HttpClient httpClient = new HttpClient();
            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayThongTinTaiKhoan?TenDangNhap=" + TENDANGNHAP);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<TAIKHOAN>>(ConnectAPI);
            var SelectFirst = ConnectAPIConvert.First();

            hoten.Text = SelectFirst.TenKhachHang;
            sdt.Text = SelectFirst.SoDienThoai;
            email.Text = SelectFirst.Email;
            ngaysinh.Date = SelectFirst.NgaySinh;

            if (SelectFirst.GioiTinh == true)
            {
                Nam.IsChecked = true;
            }
            else
            {
                Nu.IsChecked = true;
            }

        }

        private async void edit_Clicked(object sender, EventArgs e)
        {
            if (edit.Text == "Sửa")
            {
                hoten.IsReadOnly = false;
                sdt.IsReadOnly = false;
                email.IsReadOnly = false;
                ngaysinh.IsEnabled = true;
                Nam.IsEnabled = true;
                Nu.IsEnabled = true;
                edit.Text = "Lưu";
            }
            else
            {
                bool GioiTinh;
                if (Nam.IsChecked == true)
                {
                    GioiTinh = true;
                }
                else
                {
                    GioiTinh = false;
                }

                HttpClient httpClient = new HttpClient();
                int temp_GT = (GioiTinh == true) ? 1 : 0;
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "CapNhatTaiKhoan?TenDangNhap=" + TENDANGNHAP + "&TenKhachHang=" + hoten.Text + "&SoDienThoai=" + sdt.Text + "&Email=" + email.Text + "&NgaySinh=" + dd + "&GioiTinh=" + temp_GT.ToString());

                hoten.IsReadOnly = true;
                sdt.IsReadOnly = true;
                email.IsReadOnly = true;
                ngaysinh.IsEnabled = false;
                Nam.IsEnabled = false;
                Nu.IsEnabled = false;
                edit.Text = "Sửa";

                OnAppearing();
            }

        }

        private void Nam_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Nam.IsChecked == true)
            {
                Nu.IsChecked = false;
            }
            else
            {
                Nu.IsChecked = true;
            }
        }

        private void Nu_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Nu.IsChecked == true)
            {
                Nam.IsChecked = false;
            }
            else
            {
                Nam.IsChecked = true;
            }
        }

        private string dd;
        private void ngaysinh_DateSelected(object sender, DateChangedEventArgs e)
        {
            CultureInfo englishUSCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = englishUSCulture;
            dd = e.NewDate.ToString("dd/MM/yyyy");
        }
    }
}