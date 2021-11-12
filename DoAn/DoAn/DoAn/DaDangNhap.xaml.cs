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
    public partial class DaDangNhap : ContentPage
    {
        public DaDangNhap()
        {
            InitializeComponent();
            List<DanhMuc_TK> DanhMuc = new List<DanhMuc_TK>();
            DanhMuc.Add(new DanhMuc_TK { ID = "TTTK", Text = "Thông tin tài khoản", Icon = "icon_TTTK.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "DHCT", Text = "Đơn hàng của tôi", Icon = "icon_DHCT.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "DMK", Text = "Đổi mật khẩu", Icon = "icon_TDMK.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "DCGH", Text = "Địa chỉ giao hàng", Icon = "icon_DCGH.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "SPDX", Text = "Sản phẩm đã xem", Icon = "icon_SPDX.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "HT", Text = "Hỗ trợ", Icon = "icon_HT.png", Icon_next = "icon_next.png" });
            lst_taikhoan.ItemsSource = DanhMuc;
        }

        private void lst_taikhoan_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DanhMuc_TK danhMuc_TK = (DanhMuc_TK)lst_taikhoan.SelectedItem;
            lst_taikhoan.SelectedItem = "";
            if (danhMuc_TK.ID == "TTTK")
            {

                Navigation.PushAsync(new ThongTinTaiKhoan());
            }
            if (danhMuc_TK.ID == "DMK")
            {

                Navigation.PushAsync(new DoiMatKhau());
            }
            if (danhMuc_TK.ID == "DHCT")
            {

                Navigation.PushAsync(new DonHangCuaToi());
            }
        }
    }
}