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
    public partial class HoTro : ContentPage
    {
        public HoTro()
        {
            InitializeComponent();
        }

        private void general_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChinhSachVaQuyDinhChung());
        }

        private void security_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChinhSachBaoMatThongTin());
        }

    }
}