using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChiTietSachAdmin : ContentPage
    {
        public ChiTietSachAdmin()
        {
            InitializeComponent();
        }
        public ChiTietSachAdmin(Sach sach)
        {
            InitializeComponent();
            Title = sach.TenSach;
            image.Source = sach.Hinh;
            tensach.Text = sach.TenSach;
            mota.Text = sach.MoTa;
            giacu.Text = sach.GiaDisplayOld;
            phantramgiam.Text = sach.GiamGiaDisPlay;
            image.MinimumHeightRequest = 300;
            image.MinimumWidthRequest = 300;
            image.WidthRequest = 300;
            image.HeightRequest = 300;
            //giaban.Text = sach.Price.ToString("C");
            giaban.Text = sach.GiaDisplayNew;

        }
        private void cmdChonMua_Clicked(object sender, EventArgs e)
        {
            Button chon = (Button)sender;
            Sach Sachchon = (Sach)chon.CommandParameter;
            DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
        }
    }
}