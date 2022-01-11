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
    public partial class DatHang : ContentPage
    {
        string TENDANGNHAP;
        int MADIACHI;
        APIString APIString = new APIString();
        public DatHang()
        {
            InitializeComponent();
        }
        public DatHang(string TenDangNhap)
        {
            InitializeComponent();
            TENDANGNHAP = TenDangNhap;
            KhoiTaoDonHang(TenDangNhap);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            KhoiTaoDonHang(TENDANGNHAP);
        }

        async void KhoiTaoDonHang(string TenDangNhap)
        {
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayDiaChi?TenDangNhap=" + TenDangNhap);

            if (ConnectAPI.ToString() != "[]")
            {
                var ConnectAPIConvert = JsonConvert.DeserializeObject<List<DIACHI>>(ConnectAPI);

                foreach (var item in ConnectAPIConvert)
                {
                    if (item.MacDinh == true)
                    {
                        lbTenNguoiNhan.Text = item.TenNguoiNhan;
                        lbSDT.Text = item.SDT;
                        lbDiaChi.Text = item.DiaChi;
                        MADIACHI = item.MaDiaChi;
                        bntDatHang.IsEnabled = true;
                    }
                }


            }

            var GioHangList = await httpClient.GetStringAsync(APIString.str + "LayThongTinGioHang?TenDangNhap=" + TenDangNhap);
            var GioHangListConvert = JsonConvert.DeserializeObject<List<GioHangTheoTK>>(GioHangList);

            lstCTDH.ItemsSource = GioHangListConvert;

            var GiaoHang = await httpClient.GetStringAsync(APIString.str + "LayGiaGiaoHang");
            var GiaoHangConvert = JsonConvert.DeserializeObject<List<GIAOHANG>>(GiaoHang);

            lbGia.Text = GiaoHangConvert.First().Gia.ToString();

            lbThanhTien.Text = (GioHangListConvert.First().TongTien + int.Parse(lbGia.Text)).ToString();
            if (lbTenNguoiNhan.Text == "" || lbTenNguoiNhan.Text == null)
            {
                bntThayDoi.Text = "Thêm";
                bntDatHang.IsEnabled = false;
            }
        }

        private void bntThayDoi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DiaChi(TENDANGNHAP));

            OnAppearing();
        }

        private async void bntDatHang_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "ThemHoaDon?TenDangNhap=" + TENDANGNHAP + "&NgayHoaDon=" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "&MaDiaChi=" + MADIACHI);
                await DisplayAlert("Thông báo", "Đơn hàng đã tạo thành công", "Ok");
            }
            catch
            {
                await DisplayAlert("Thông báo", "Tạo đơn hàng thất bại", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}