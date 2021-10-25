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
        }

        private void btnDNDK_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DangNhap());
        }
    }
}