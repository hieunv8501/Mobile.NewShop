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
    public partial class DanhSachTaiKhoan : ContentPage
    {
        APIString APIString = new APIString();

        public DanhSachTaiKhoan()
        {
            InitializeComponent();
            ListTaiKhoan();
        }

        List<TAIKHOAN> tks = new List<TAIKHOAN>();
        private async void ListTaiKhoan()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(APIString.str + "LayDanhSachTaiKhoan");
            tks = JsonConvert.DeserializeObject<List<TAIKHOAN>>(kq);
            listTaiKhoan.ItemsSource = tks;
        }
        private void listTaiKhoan_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listTaiKhoan.SelectedItem != null)
            {
                TAIKHOAN taikhoan = (TAIKHOAN)listTaiKhoan.SelectedItem;
                Navigation.PushAsync(new ThongTinTaiKhoan(taikhoan.TenDangNhap));
                listTaiKhoan.SelectedItem = null;
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //
        }

        private async void btnThemTaiKhoan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThemTaiKhoan());
        }

        private async void btnXoa_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            TAIKHOAN tkbixoa = (TAIKHOAN)b.CommandParameter;
            HttpClient http = new HttpClient();
            var dec = DisplayAlert("Thông báo", "Bạn có thực sự muốn xóa tài khoản này?", "Đồng ý", "Hủy");
            if (await dec == true)
            {
                try
                {
                    var kq = await http.GetStringAsync(APIString.str + "XoaTaiKhoan?TenDangNhap=" + tkbixoa.TenDangNhap);
                    if (int.Parse(kq) > 0)
                    {
                        await DisplayAlert("Thông báo", "Xóa thành công", "OK");
                        await Navigation.PushAsync(new DanhSachTaiKhoan());
                    }
                    else
                    {
                        await DisplayAlert("Thông báo", "Xóa thất bại", "OK");
                    }

                }
                catch
                {
                    await DisplayAlert("Thông báo", "Xóa thất bại!", "OK");
                }
            }
        }
    }
}