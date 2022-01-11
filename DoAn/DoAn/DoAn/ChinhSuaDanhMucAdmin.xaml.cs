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
    public partial class ChinhSuaDanhMucAdmin : ContentPage
    {
        APIString APIString = new APIString();
        public ChinhSuaDanhMucAdmin()
        {
            InitializeComponent();
        }
        LoaiSach globaldanhmuc = new LoaiSach();
        public ChinhSuaDanhMucAdmin(LoaiSach item)
        {
            InitializeComponent();

            Title = "Chỉnh Sửa Danh Mục " + item.TenLoaiSach;
            globaldanhmuc = item;
            txtTenLoaiSach.Text = item.TenLoaiSach;
            string[] subs = item.Hinh.Split('/');

            txtHinh.Text = subs[subs.Length - 1];
        }

        private async void cmdSuaDanhMuc_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync(APIString.str + "CapNhatLoaiSach?MaLoaiSach=" + globaldanhmuc.MaLoaiSach + "&TenLoaiSach=" + txtTenLoaiSach.Text + "&Hinh=" + APIString.str_img + txtHinh.Text);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã chỉnh sửa thành công", "OK");
                    await Navigation.PushAsync(new DanhMucAdmin());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Chỉnh sửa thất bại ", "OK");
                }

            }
            catch
            {
                {
                    await DisplayAlert("Thông Báo", "Chỉnh sửa thất bại", "OK");
                }
            }
        }
    }
}