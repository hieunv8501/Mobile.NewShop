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
    public partial class KiemTraDonHang : ContentPage
    {
        public KiemTraDonHang()
        {
            InitializeComponent();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "Email / Số điện thoại";
            lblEmail.TextColor = Color.Blue;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "";
        }

        private void Entry_Focused_1(object sender, FocusEventArgs e)
        {
            lblmadh.Text = "Mã đơn hàng";
            lblmadh.TextColor = Color.Blue;
        }

        private void Entry_Unfocused_1(object sender, FocusEventArgs e)
        {
            lblmadh.Text = "";

        }
    }
}