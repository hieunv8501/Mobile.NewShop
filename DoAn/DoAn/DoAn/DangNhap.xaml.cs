using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DangNhap : ContentPage
    {
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


        private void dnbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DaDangNhap());
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
    }
}