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
        APIString APIString = new APIString();
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

            var kq = await http.GetStringAsync(APIString.str + "LayDanhSachSachTheoLoaiSach?MaLoaiSach=" + LoaiSach.MaLoaiSach.ToString());
            var dssach = JsonConvert.DeserializeObject<List<Sach>>(kq);
            Sachs = dssach;
            LstSach.ItemsSource = Sachs;
        }



        public ManHinhListSach(string TenDangNhap)
        {
            InitializeComponent();
            Title = "Sách đã xem";
            InitializeManHinhListSach(TenDangNhap);

        }

        async void InitializeManHinhListSach(string TenDangNhap)
        {
            CultureInfo.CurrentCulture = new CultureInfo("vi-VN");

            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(APIString.str + "LayThongTinSPDaXem?TenDangNhap=" + TenDangNhap);
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

        private async void cmdchonmua_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaSach = selected.CommandParameter.ToString();

            TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
            if (tENDANGNHAP.Get_TenDangNhap() != null)
            {
                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "ThemSachVaoGioHang?TenDangNhap=" + tENDANGNHAP.Get_TenDangNhap() + "&MaSach=" + MaSach);
                await DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
            }
            else
            {
                await DisplayAlert("Thông báo", "Bạn cần phải đăng nhập", "OK");

            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstSach.ItemsSource = Sachs.Where(p => p.TenSach.ToLower().Contains(Search.Text.ToLower()));

        }
    }
}