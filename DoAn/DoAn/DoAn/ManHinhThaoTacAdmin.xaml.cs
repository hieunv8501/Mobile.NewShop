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
    public partial class ManHinhThaoTacAdmin : TabbedPage
    {
        public ManHinhThaoTacAdmin()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        public ManHinhThaoTacAdmin(TAIKHOAN taikhoan)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            NavigationPage navigationPage = new NavigationPage(new DaDangNhap(taikhoan));
            navigationPage.IconImageSource = "IconTaiKhoan.png";
            navigationPage.Title = "Tài khoản";
            Children.Add(navigationPage);
        }
    }
}