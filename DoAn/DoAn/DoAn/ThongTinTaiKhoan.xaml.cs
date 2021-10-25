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
    public partial class ThongTinTaiKhoan : ContentPage
    {
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }
        private void edit_Clicked(object sender, EventArgs e)
        {
            if (edit.Text == "Sửa")
            {
                hoten.IsReadOnly = false;
                sdt.IsReadOnly = false;
                email.IsReadOnly = false;
                ngaysinh.IsEnabled = true;
                Nam.IsEnabled = true;
                Nu.IsEnabled = true;
                edit.Text = "Lưu";
            }
            else
            {
                hoten.IsReadOnly = true;
                sdt.IsReadOnly = true;
                email.IsReadOnly = true;
                ngaysinh.IsEnabled = false;
                Nam.IsEnabled = false;
                Nu.IsEnabled = false;
                edit.Text = "Sửa";
            }

        }

        private void Nam_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Nam.IsChecked == true)
            {
                Nu.IsChecked = false;
            }
            else
            {
                Nu.IsChecked = true;
            }
        }

        private void Nu_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Nu.IsChecked == true)
            {
                Nam.IsChecked = false;
            }
            else
            {
                Nam.IsChecked = true;
            }
        }
    }
}