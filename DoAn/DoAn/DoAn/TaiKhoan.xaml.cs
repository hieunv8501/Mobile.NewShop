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
    public partial class TaiKhoan : ContentPage
    {
        public TaiKhoan()
        {
            InitializeComponent();
            Create_danhmuc();
        }
        void Create_danhmuc()
        {           
            List<DanhMuc_TK> danhmuc = new List<DanhMuc_TK>();
            danhmuc.Add(new DanhMuc_TK { ID = "KTDH", Text = "Kiểm tra đơn hàng", Icon = "icon_KTDH.png", Icon_next = "icon_next.png" });
            danhmuc.Add(new DanhMuc_TK { ID = "HT", Text = "Hỗ trợ", Icon = "icon_HT.png", Icon_next = "icon_next.png" });
            listdn.ItemsSource = danhmuc;
        }

        private void dangnhap_dangky_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DangNhap());
        }

        private void listdn_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DanhMuc_TK danhMuc_TK = (DanhMuc_TK)listdn.SelectedItem;
            listdn.SelectedItem = "";

            if (danhMuc_TK.ID == "KTDH")
            {

                Navigation.PushAsync(new KiemTraDonHang());
            }
            if (danhMuc_TK.ID == "HT")
            {

                Navigation.PushAsync(new HoTro());
            }
        }
    }
}