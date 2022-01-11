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
    public partial class DiaChi : ContentPage
    {
        string TENDANGNHAP;
        APIString APIString = new APIString();
        public DiaChi()
        {
            InitializeComponent();

        }
        public DiaChi(string TenDangNhap)
        {
            InitializeComponent();
            LayDiaChi(TenDangNhap);
            TENDANGNHAP = TenDangNhap;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LayDiaChi(TENDANGNHAP);
        }


        async void LayDiaChi(string TenDangNhap)
        {
            HttpClient httpClient = new HttpClient();


            var GioHangList = await httpClient.GetStringAsync(APIString.str + "LayDiaChi?TenDangNhap=" + TenDangNhap);

            if (GioHangList.ToString() != "[]")
            {
                var GioHangListConvert = JsonConvert.DeserializeObject<List<DIACHI>>(GioHangList);

                lstDiaChi.ItemsSource = GioHangListConvert;

            }
            else
            {
                lstDiaChi.ItemsSource = null;
            }

        }

        private void bntThemDiaChi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemDiaChi(TENDANGNHAP));
        }

        private async void bntXoa_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaDiaChi = selected.CommandParameter.ToString();

            var userchoice = await DisplayAlert("Thông báo", "Bạn có chắt muốn xóa?", "Có", "Không");
            if (userchoice)
            {
                HttpClient httpClient = new HttpClient();

                var CheckDiaChi = await httpClient.GetStringAsync(APIString.str + "CheckDiaChi?MaDiaChi=" + MaDiaChi);
                if (CheckDiaChi.ToString() == "[]")
                {
                    var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "XoaDiaChi?MaDiaChi=" + MaDiaChi);
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Thông báo", "Không thể xóa vì đang có hóa đơn giao hàng cho địa chỉ này", "Ok");
                }

            }
        }

        private void bntSua_Clicked(object sender, EventArgs e)
        {

        }

        private async void bntSetMacDinh_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaDiaChi = selected.CommandParameter.ToString();

            var userchoice = await DisplayAlert("Thông báo", "Đặt địa chỉ này làm địa chỉ giao hàng", "Có", "Không");
            if (userchoice)
            {
                HttpClient httpClient = new HttpClient();

                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "ThayDoiDiaChiMacDinh?MaDiaChi=" + MaDiaChi + "&TenDangNhap=" + TENDANGNHAP);
                OnAppearing();
            }
        }
    }
}