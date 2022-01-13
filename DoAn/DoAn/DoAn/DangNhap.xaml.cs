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
    public partial class DangNhap : ContentPage
    {
        APIString APIString = new APIString();
        TAIKHOAN taikhoan = new TAIKHOAN();
        public DangNhap()
        {
            InitializeComponent();
            Create_danhmuc();
        }
        void Create_danhmuc()
        {
            List<DanhMuc_TK> danhmuc = new List<DanhMuc_TK>();
            danhmuc.Add(new DanhMuc_TK { ID = "gg", Text = "Sign in with Google", Icon = "ggicon.png", Icon_next = "icon_next.png" });
            danhmuc.Add(new DanhMuc_TK { ID = "fb", Text = "Sign in with Facebook", Icon = "fbicon.png", Icon_next = "icon_next.png" });
            lstdn_choice.ItemsSource = danhmuc;
        }

        private async void dnbtn_Clicked(object sender, EventArgs e)
        {
            if (lbTenDangNhap.Text != null && lbMatKhau.Text != null)
            {
                HttpClient httpClient = new HttpClient();
                bool check = false;
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayDanhSachTaiKhoan");
                var ConnectAPIConvert = JsonConvert.DeserializeObject<List<TAIKHOAN>>(ConnectAPI);

                for (int i = 0; i < ConnectAPIConvert.Count(); i++)
                {
                    if (ConnectAPIConvert[i].TenDangNhap == lbTenDangNhap.Text && ConnectAPIConvert[i].MatKhau == lbMatKhau.Text)
                    {
                        check = true;
                        TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
                        taikhoan = ConnectAPIConvert[i];
                        tENDANGNHAP.Set_TenDangNhap(lbTenDangNhap.Text);
                        //await Navigation.PushAsync(new DaDangNhap(lbTenDangNhap.Text));
                        await Navigation.PushAsync(new DaDangNhap(taikhoan));
                    }
                }
                if (check == false)
                    await DisplayAlert("Thông báo", "Tên đăng nhập hoặc mật khẩu không đúng", "OK");
            }

        }

        private void dkbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DangKy());
        }

        private void qmkbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuenMatKhau());
        }

        private void lstdn_choice_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DanhMuc_TK danhmuc = (DanhMuc_TK)lstdn_choice.SelectedItem;
            lstdn_choice.SelectedItem = "";

            if (danhmuc.ID == "fb")
            {
                DisplayAlert("Đăng nhập bằng facebook", "Facebook", "OK");
            }
            else if (danhmuc.ID == "gg")
            {
                DisplayAlert("Đăng nhập bằng Google", "Google", "OK");
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (lbMatKhau.IsPassword)
            {
                lbMatKhau.IsPassword = false;
                show_pass_eye.Source = "hidepass.png";
            }
            else
            {
                lbMatKhau.IsPassword = true;
                show_pass_eye.Source = "showpass.png";
            }
        }
    }
}