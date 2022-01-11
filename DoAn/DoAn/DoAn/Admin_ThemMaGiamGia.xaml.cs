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
    public partial class Admin_ThemMaGiamGia : ContentPage
    {
        APIString APIString = new APIString();
        public Admin_ThemMaGiamGia()
        {
            InitializeComponent();
        }

        private async void btnThem_Clicked(object sender, EventArgs e)
        {
            if (Int32.Parse(lbTiLeGiam.Text) > 0 && Int32.Parse(lbTiLeGiam.Text) < 100)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    var CT_GIOHANG = await httpClient.GetStringAsync(APIString.str + "ThemMaGiamGia?MaGiamGia=" + lbMaGiamGia.Text + "&TiLeGiam=" + lbTiLeGiam.Text);

                    await DisplayAlert("Thông báo", "Thêm mã giảm giá thành công", "Ok");
                    await Navigation.PopAsync();

                }
                catch
                {
                    await DisplayAlert("Lỗi", "Thêm mã giảm giá thất bại", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Tỉ lệ giảm giá không hợp lệ", "Ok");
            }


        }
    }
}