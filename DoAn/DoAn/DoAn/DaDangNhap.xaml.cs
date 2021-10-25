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
            DanhMuc.Add(new DanhMuc_TK { id = "TTTK", text = "Thông tin tài khoản", icon = "icon_TTTK.png", icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { id = "DHCT", text = "Đơn hàng của tôi", icon = "icon_DHCT.png", icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { id = "DMK", text = "Đổi mật khẩu", icon = "icon_TDMK.png", icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { id = "DCGH", text = "Địa chỉ giao hàng", icon = "icon_DCGH.png", icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { id = "SPDX", text = "Sản phẩm đã xem", icon = "icon_SPDX.png", icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { id = "HT", text = "Hỗ trợ", icon = "icon_HT.png", icon_next = "icon_next.png" });
            lst_taikhoan.ItemsSource = DanhMuc;
        }
        private void lst_taikhoan_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DanhMuc_TK danhMuc_TK = (DanhMuc_TK)lst_taikhoan.SelectedItem;
            lst_taikhoan.SelectedItem = "";
            if (danhMuc_TK.id == "TTTK")
            {

                Navigation.PushAsync(new ThongTinTaiKhoan());
            }
            if (danhMuc_TK.id == "DMK")
            {

                Navigation.PushAsync(new DoiMatKhau());
            }
            if (danhMuc_TK.id == "DHCT")
            {

                Navigation.PushAsync(new DonHangCuaToi());
            }
        }
    }
}