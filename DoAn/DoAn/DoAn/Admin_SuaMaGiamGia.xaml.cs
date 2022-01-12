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
    public partial class Admin_SuaMaGiamGia : ContentPage
    {
        APIString APIString = new APIString();
        string MAGIAMGIA;
        public Admin_SuaMaGiamGia()
        {
            InitializeComponent();
        }

        public Admin_SuaMaGiamGia(string MaGiamGia)
        {
            InitializeComponent();
            KhoiTao(MaGiamGia);
            MAGIAMGIA = MaGiamGia;
        }

        async void KhoiTao(string MaGiamGia)
        {
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayMaGiamGia?MaGiamGia=" + MaGiamGia);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<MAGIAMGIA>>(ConnectAPI);

            lbMaGiamGia.Text = "Mã giảm giá: " + ConnectAPIConvert.First().MaGiamGia;
            TiLeGiamGia.Text = ConnectAPIConvert.First().TiLeGiam.ToString();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "SuaMaGiamGia?MaGiamGia=" + MAGIAMGIA + "&TiLeGiam=" + TiLeGiamGia.Text);

                await DisplayAlert("Thông báo", "Bạn đã sửa mã giảm giá thành công", "ok");

                await Navigation.PopAsync();

            }
            catch
            {
                await DisplayAlert("Thông báo", "Sửa mã giảm giá thất bại", "ok");
            }

        }
    }
}