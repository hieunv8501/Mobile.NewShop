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
    public partial class Admin_ChiPhiGiaoHang : ContentPage
    {
        APIString APIString = new APIString();

        public Admin_ChiPhiGiaoHang()
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

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayGiaGiaoHang");
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<GIAOHANG>>(ConnectAPI);
            var SelectOne = ConnectAPIConvert.First();

            lbGia.Text = SelectOne.Gia.ToString();

        }

        private async void btnSuaChiPhiGiao_Clicked(object sender, EventArgs e)
        {
            var userchoice = await DisplayAlert("Thông báo", "Bạn có chắc muốn sửa giá tiền giao hàng?", "Có", "Không");
            if (userchoice)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "SuaGiaGiaoHang?Gia=" + lbGia.Text);
                    await DisplayAlert("Thông báo", "Sửa giá giao hàng thành công?", "Ok");
                    OnAppearing();
                }
                catch
                {
                    await DisplayAlert("Thông báo", "Sửa giá giao hàng thất bại?", "Ok");
                }

            }

        }
    }
}