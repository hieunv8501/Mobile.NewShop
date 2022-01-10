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
    public partial class Admin_MaGiamGia : ContentPage
    {
        APIString APIString = new APIString();
        public Admin_MaGiamGia()
        {
            InitializeComponent();
            KhoiTao();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            KhoiTao();
        }
        async void KhoiTao()
        {
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayDanhSachMaGiamGia");
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<MAGIAMGIA>>(ConnectAPI);

            lst_MaGiamGia.ItemsSource = ConnectAPIConvert;


        }



        private void btnThemMaGiamGia_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Admin_ThemMaGiamGia());
        }

        private void btnSua_Clicked(object sender, EventArgs e)
        {
            SwipeItem selected = (SwipeItem)sender;
            string MaGiamGia = selected.CommandParameter.ToString();
            Navigation.PushAsync(new Admin_SuaMaGiamGia(MaGiamGia));
        }

        private async void btnXoa_Clicked(object sender, EventArgs e)
        {
            SwipeItem selected = (SwipeItem)sender;
            string MaGiamGia = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();

            var userchoice = await DisplayAlert("Thông báo", "Bạn có chắc muốn xóa mã giảm giá này?", "Có", "Không");
            if (userchoice)
            {
                var ConnectAPIXoa = await httpClient.GetStringAsync(APIString.str + "XoaMaGiamGia?MaGiamGia=" + MaGiamGia);
                OnAppearing();
            }
        }
    }
}