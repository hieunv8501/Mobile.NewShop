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
    public partial class DangKy : ContentPage
    {
        APIString APIString = new APIString();
        TAIKHOAN taikhoan = new TAIKHOAN();
        public DangKy()
        {
            InitializeComponent();
            GenderCreate();
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
        string dd ="";
        private void dkdob_DateSelected(object sender, DateChangedEventArgs e)
        {
            CultureInfo englishUSCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = englishUSCulture;
            dd = e.NewDate.ToString("dd/MM/yyyy");
        }

        private async void btndk_dk_Clicked(object sender, EventArgs e)
        {
            string TenDangNhap = dktdn.Text;
            string MatKhau = dkmk.Text;
            string TenKhachHang = dkhoten.Text;
            string Email = dkemail.Text;
            string SoDienThoai = dksdt.Text;
            string NgaySinh = dd;
            int GioiTinh = 1;
            if (dkgender.Title == "Nam") GioiTinh = 1;
            else if (dkgender.Title == "Nữ")
            {
                GioiTinh = 0;
            }
            //await DisplayAlert("Data", TenDangNhap + MatKhau + TenKhachHang + Email + SoDienThoai + NgaySinh + GioiTinh, "OK");

            if (TenDangNhap == "" || TenKhachHang == "" || MatKhau == "" || Email == "" || SoDienThoai == "" || NgaySinh == "")
            {
                _ = DisplayAlert("Thông báo", "Bạn chưa nhập đầy đủ thông tin đăng ký", "OK");
            }
            else
            {
                var httpClient = new HttpClient();
                var res = await httpClient.GetStringAsync(APIString.str + "ThemTaiKhoan?TenDangNhap=" + TenDangNhap + "&MatKhau=" + MatKhau + "&TenKhachHang=" + TenKhachHang + "&Email=" + Email + "&SoDienThoai=" + SoDienThoai + "&NgaySinh=" + NgaySinh + "&GioiTinh=" + GioiTinh.ToString() + "&IsAdmin=0");
                _ = DisplayAlert("Thông báo", "Đăng ký tài khoản thành công", "OK");
                bool check = false;
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayDanhSachTaiKhoan");
                var ConnectAPIConvert = JsonConvert.DeserializeObject<List<TAIKHOAN>>(ConnectAPI);

                for (int i = 0; i < ConnectAPIConvert.Count(); i++)
                {
                    if (ConnectAPIConvert[i].TenDangNhap == dktdn.Text && ConnectAPIConvert[i].MatKhau == dkmk.Text)
                    {
                        check = true;
                        TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
                        taikhoan = ConnectAPIConvert[i];
                        tENDANGNHAP.Set_TenDangNhap(dktdn.Text);
                        //await Navigation.PushAsync(new DaDangNhap(lbTenDangNhap.Text));
                        await Navigation.PushAsync(new DaDangNhap(taikhoan));
                    }
                }
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (dkmk.IsPassword)
            {
                dkmk.IsPassword = false;
                show_pass_eye.Source = "hidepass.png";
            }
            else
            {
                dkmk.IsPassword = true;
                show_pass_eye.Source = "showpass.png";
            }
        }
    }
}
