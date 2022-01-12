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
    public partial class TaiKhoan_ChiTiet : ContentPage
    {
        public TaiKhoan_ChiTiet()
        {
            InitializeComponent();
        }
        public TaiKhoan_ChiTiet(TAIKHOAN taikhoan)
        {
            InitializeComponent();
        }
    }
}