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
    public partial class QuenMatKhau : ContentPage
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "Email";
            lblEmail.TextColor = Color.Blue;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "";
        }
    }
}