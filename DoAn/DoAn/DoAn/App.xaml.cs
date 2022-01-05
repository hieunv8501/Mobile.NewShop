using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    public partial class App : Application
    {
        public static string TenDangNhapSignedIn = null;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DanhMucAdmin());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
