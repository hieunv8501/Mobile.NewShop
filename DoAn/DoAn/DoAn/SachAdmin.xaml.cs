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
    public partial class SachAdmin : ContentPage
    {
        public SachAdmin()
        {
            InitializeComponent();
        }
        LoaiSach sach1 = new LoaiSach();
        public SachAdmin(LoaiSach sach)
        {
            InitializeComponent();
            Title = sach.TenLoaiSach;
            InitializeManHinhListSach(sach);
            sach1 = sach;
        }


        List<Sach> Sachs = new List<Sach>();
        async void InitializeManHinhListSach(LoaiSach Loaisach)
        {


            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/LayDanhSachSachTheoLoaiSach?MaLoaiSach=" + Loaisach.MaLoaiSach);
                var sach = JsonConvert.DeserializeObject<List<Sach>>(kq);
                LstSach.ItemsSource = sach;
                Sachs = sach;
            }
            catch
            {
                LstSach.ItemsSource = null;
            }
        }
        private void LstSach_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstSach.SelectedItem != null)
            {
                Sach Sach = (Sach)LstSach.SelectedItem;
                Navigation.PushAsync(new ChiTietSachAdmin(Sach));
                LstSach.SelectedItem = null;
            }
        }

        private void cmdchonmua_Clicked(object sender, EventArgs e)
        {
            Button chon = (Button)sender;
            Sach Sachchon = (Sach)chon.CommandParameter;
            DisplayAlert(Sachchon.TenSach, "Đã chọn", "OK");
        }

        private void cmdSua_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            Sach item = (Sach)b.CommandParameter;
            Navigation.PushAsync(new ChinhSuaSach(item));
        }

        private async void cmdXoa_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            Sach item = (Sach)b.CommandParameter;
            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/XoaSach?MaSach=" + item.MaSach);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã xóa thành công", "OK");
                    await Navigation.PushAsync(new SachAdmin());
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
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstSach.ItemsSource = Sachs.Where(p => p.TenSach.ToLower().Contains(Search.Text.ToLower()));

        }

        private void cmdThemSach_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemSachAdmin(sach1));
        }
    }
}