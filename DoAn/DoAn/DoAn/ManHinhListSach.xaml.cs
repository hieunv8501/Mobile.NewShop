using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManHinhListSach : ContentPage
    {
        public ManHinhListSach()
        {
            InitializeComponent();
        }
        public ManHinhListSach(LoaiSach loaisach)
        {
            InitializeComponent();
            Title = loaisach.Name;
            InitializeManHinhListSach(loaisach);
        }
        void InitializeManHinhListSach(LoaiSach LoaiSach)
        {
            CultureInfo.CurrentCulture = new CultureInfo("vi-VN");
            List<Sach> Sachs = new List<Sach>();
            switch (LoaiSach.ID)
            {
                case ("BC"):
                    {
                        Sachs.Add(new Sach { ID = "BV", Name = " Khách Sạn Ba Vì", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        Sachs.Add(new Sach { ID = "AB", Name = " Amorita Boutique Sach Hanoi", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        Sachs.Add(new Sach { ID = "LG", Name = "Le Grand Hanoi Sach", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        Sachs.Add(new Sach { ID = "LHH", Name = " Lotte Sach Hanoi", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        Sachs.Add(new Sach { ID = "BV", Name = " Khách Sạn Ba Vì", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        break;
                    }
                case ("KD"):
                    {
                        Sachs.Add(new Sach { ID = "SG", Name = " Khách Sạn Sài Gòn", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        Sachs.Add(new Sach { ID = "PH", Name = " PIANO Sach", ImageURL = "PianoSach.jpg", Price = 115000 });
                        Sachs.Add(new Sach { ID = "SYH", Name = "Silverland Yen Sach", ImageURL = "SilverlandSach.jpg", Price = 115000 });
                        break;
                    }
                case ("TN"):
                    {
                        Sachs.Add(new Sach { ID = "HPS", Name = " Khách sạn Hoa Păng Sê Đà Lạt ", ImageURL = "ThieuNhi.jpg", Price = 115000 });
                        break;
                    }
                case ("VT"):
                    {
                        Sachs.Add(new Sach { ID = "HH", Name = " Hafi Sach", ImageURL = "HH.jpg", Price = 115000 });
                        break;
                    }
                case ("KNS"):
                    {
                        Sachs.Add(new Sach { ID = "Hue", Name = " Hue Serene Palace Sach", ImageURL = "HH.jpg", Price = 115000 });
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            LstSach.ItemsSource = Sachs;
        }

        private void LstSach_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstSach.SelectedItem != null)
            {
                Sach Sach = (Sach)LstSach.SelectedItem;
                Navigation.PushAsync(new ChiTietSach(Sach));
            }
        }

        private void cmdchonmua_Clicked(object sender, EventArgs e)
        {
            Button chon = (Button)sender;
            Sach Sachchon = (Sach)chon.CommandParameter;
            DisplayAlert(Sachchon.Name, "Đã chọn", "OK");
        }
    }
}