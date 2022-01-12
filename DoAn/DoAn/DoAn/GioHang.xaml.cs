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
        TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
        APIString APIString = new APIString();
        public GioHang()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (tENDANGNHAP.Get_TenDangNhap() != null)
            {
                LayThongTinGioHang(tENDANGNHAP.Get_TenDangNhap());
            }
            else
            {
                DatHang.IsEnabled = false;
            }

        }

        async void LayThongTinGioHang(string TenDangNhap)
        {

            HttpClient httpClient = new HttpClient();
            var GioHangList = await httpClient.GetStringAsync(APIString.str + "LayThongTinGioHang?TenDangNhap=" + TenDangNhap);

            if (GioHangList.ToString() != "[]")
            {
                var GioHangListConvert = JsonConvert.DeserializeObject<List<GioHangTheoTK>>(GioHangList);


                lstGioHang.ItemsSource = GioHangListConvert;

                lbTongTien.Text = GioHangListConvert.First().TongTien.ToString();
                MaGioHang = GioHangListConvert.First().MaGioHang;
                DatHang.IsEnabled = true;
            }
            else
            {
                lstGioHang.ItemsSource = null;
                lbTongTien.Text = null;
                DatHang.IsEnabled = false;
            }

        }

        private async void GiamSL_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaSach = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();
            var CT_GIOHANG = await httpClient.GetStringAsync(APIString.str + "GiamSoLuong?MaGioHang=" + MaGioHang + "&MaSach=" + MaSach);

            OnAppearing();

        }

        private async void TangSL_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaSach = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();
            var CT_GIOHANG = await httpClient.GetStringAsync(APIString.str + "TangSoLuong?MaGioHang=" + MaGioHang + "&MaSach=" + MaSach);

            OnAppearing();

        }

        private async void ApDung_Clicked(object sender, EventArgs e)
        {
            var TongTienTruoc = lbTongTien.Text;

            HttpClient httpClient = new HttpClient();
            var MaGiamGia = await httpClient.GetStringAsync(APIString.str + "ApDungMa?MaGiamGia=" + lbMaGiamGia.Text + "&MaGioHang=" + MaGioHang);

            var GioHangList = await httpClient.GetStringAsync(APIString.str + "LayThongTinGioHang?TenDangNhap=" + tENDANGNHAP.Get_TenDangNhap());

            if (GioHangList.ToString() != "[]")
            {
                var GioHangListConvert = JsonConvert.DeserializeObject<List<GioHangTheoTK>>(GioHangList);

                if (GioHangListConvert.First().TongTien.ToString() == TongTienTruoc)
                {
                    await DisplayAlert("Thông báo", "Không hợp lệ", "Ok");
                }

            }

            OnAppearing();

        }

        private void DatHang_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DatHang(tENDANGNHAP.Get_TenDangNhap()));
        }
    }
}