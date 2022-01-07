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
    public partial class ManHinhListSach : ContentPage
    {
        public ManHinhListSach()
        {
            InitializeComponent();
        }
        public ManHinhListSach(LoaiSach loaisach)
        {
            InitializeComponent();
            Title = loaisach.TenLoaiSach;
            InitializeManHinhListSach(loaisach);

        }
        List<Sach> Sachs = new List<Sach>();
        async void InitializeManHinhListSach(LoaiSach LoaiSach)
        {
            CultureInfo.CurrentCulture = new CultureInfo("vi-VN");

            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController//LayDanhSachSachTheoLoaiSach?MaLoaiSach=" + LoaiSach.MaLoaiSach.ToString());
            var dssach = JsonConvert.DeserializeObject<List<Sach>>(kq);
            Sachs = dssach;
            LstSach.ItemsSource = Sachs;
        }

        private void LstSach_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstSach.SelectedItem != null)
            {
                Sach Sach = (Sach)LstSach.SelectedItem;
                Navigation.PushAsync(new ChiTietSach(Sach));
                LstSach.SelectedItem = null;
            }
        }

        private void cmdchonmua_Clicked(object sender, EventArgs e)
        {
            Button chon = (Button)sender;
            Sach Sachchon = (Sach)chon.CommandParameter;
            DisplayAlert(Sachchon.TenSach, "Đã chọn", "OK");
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstSach.ItemsSource = Sachs.Where(p => p.TenSach.ToLower().Contains(Search.Text.ToLower()));

        }
    }
}