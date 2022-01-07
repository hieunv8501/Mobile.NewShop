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
    public partial class GioHang : ContentPage
    {
        int MaGioHang;
        public GioHang()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LayThongTinGioHang("tinh");
        }

        async void LayThongTinGioHang(string TenDangNhap)
        {
            HttpClient httpClient = new HttpClient();


            var GioHangList = await httpClient.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/LayThongTinGioHang?TenDangNhap=" + TenDangNhap);

            if (GioHangList.ToString() != "[]")
            {
                var GioHangListConvert = JsonConvert.DeserializeObject<List<GioHangTheoTK>>(GioHangList);


                lstGioHang.ItemsSource = GioHangListConvert;

                lbTongTien.Text = GioHangListConvert.First().TongTien.ToString();
                MaGioHang = GioHangListConvert.First().MaGioHang;
            }



        }

        private async void GiamSL_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaSach = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();
            var CT_GIOHANG = await httpClient.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/GiamSoLuong?MaGioHang=" + MaGioHang + "&MaSach=" + MaSach);

            base.OnAppearing();
            LayThongTinGioHang("tinh");
        }

        private async void TangSL_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaSach = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();
            var CT_GIOHANG = await httpClient.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/TangSoLuong?MaGioHang=" + MaGioHang + "&MaSach=" + MaSach);

            base.OnAppearing();
            LayThongTinGioHang("tinh");
        }
    }
}