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
    public partial class ThemDanhMucAdmin : ContentPage
    {
        APIString APIString = new APIString();
        public ThemDanhMucAdmin()
        {
            InitializeComponent();
            Title = "Thêm Danh Mục";
        }

        async private void cmdThemDanhMuc_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync(APIString.str + "ThemLoaiSach?TenLoaiSach=" + txtTenLoaiSach.Text + "&Hinh=" + APIString.str_img + txtHinh.Text);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã thêm thành công", "OK");
                    await Navigation.PushAsync(new DanhMucAdmin());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Thêm danh mục thất bại vì danh mục này đã tồn tại rồi", "OK");
                }

            }
            catch
            {
                {
                    await DisplayAlert("Thông Báo", "Thêm danh mục thất bại vì danh mục này đã tồn tại rồi", "OK");
                }
            }


        }
    }
}