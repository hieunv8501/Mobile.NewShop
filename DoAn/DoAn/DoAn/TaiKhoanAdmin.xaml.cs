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
    public partial class TaiKhoanAdmin : ContentPage
    {
        public TaiKhoanAdmin()
        {
            InitializeComponent();
            Title = "Quản lý tài khoản";
            LayDanhSachTaiKhoan();
            
        }
        List<TAIKHOAN> TaiKhoans = new List<TAIKHOAN>();
        async void LayDanhSachTaiKhoan()
        {

            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync("http://172.20.10.4/newshopwebapi/api/ServiceController/LayDanhSachTaiKhoan");
                var dstaikhoan = JsonConvert.DeserializeObject<List<TAIKHOAN>>(kq);
                LstTaiKhoan.ItemsSource = dstaikhoan;
                TaiKhoans = dstaikhoan;
            }
            catch
            {
                LstTaiKhoan.ItemsSource = null;
            }
        }
        private void search_Clicked(object sender, EventArgs e)
        {
            //
        }
        IEnumerable<TAIKHOAN> GetDanhMuc(string searchtext = null)
        {
            List<TAIKHOAN> search = new List<TAIKHOAN>();
            if (string.IsNullOrEmpty(searchtext))
            {
                return search;
            }
            return TaiKhoans.Where(p => p.TenDangNhap.Contains(searchtext));
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstTaiKhoan.ItemsSource = TaiKhoans.Where(p => p.TenDangNhap.ToLower().Contains(Search.Text.ToLower()));

        }

        private void LstLoaiSach_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstTaiKhoan.SelectedItem != null)
            {
                TAIKHOAN clicked_LoaiSach = (TAIKHOAN)LstTaiKhoan.SelectedItem;
                Navigation.PushAsync(new TaiKhoan_ChiTiet(clicked_LoaiSach));
                LstTaiKhoan.SelectedItem = null;
            }
        }

        private async void cmdXoa_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            TAIKHOAN item = (TAIKHOAN)b.CommandParameter;
            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync("http://172.20.10.4/newshopwebapi/api/ServiceController/XoaTaiKhoan?TenDangNhap=" + item.TenDangNhap);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã xóa thành công", "OK");
                    await Navigation.PushAsync(new TaiKhoanAdmin());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Xóa thất bại ", "OK");
                }

            }
            catch
            {
                {
                    await DisplayAlert("Thông Báo", "Xóa thất bại!", "OK");
                }
            }
        }

        private void cmnChinhSua_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            TAIKHOAN item = (TAIKHOAN)b.CommandParameter;
            Navigation.PushAsync(new Admin_CapNhatTaiKhoan(item));
        }

        private void cmdThemTK_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Admin_ThemTaiKhoan());

        }
    }
}