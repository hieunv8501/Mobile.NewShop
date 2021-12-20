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
            Title = loaisach.TenLoaiSach;
            //InitializeManHinhListSach(loaisach);
        }
        //void InitializeManHinhListSach(LoaiSach LoaiSach)
        //{
        //    CultureInfo.CurrentCulture = new CultureInfo("vi-VN");
        //    List<Sach> Sachs = new List<Sach>();
        //    switch (LoaiSach.ID)
        //    {
        //        case ("BC"):
        //            {
        //                Sachs.Add(new Sach { MaSach = "BV", TenSach = " Khách Sạn Ba Vì", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                Sachs.Add(new Sach { MaSach = "AB", TenSach = " Amorita Boutique Sach Hanoi", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                Sachs.Add(new Sach { MaSach = "LG", TenSach = "Le Grand Hanoi Sach", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                Sachs.Add(new Sach { MaSach = "LHH", TenSach = " Lotte Sach Hanoi", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                Sachs.Add(new Sach { MaSach = "BV", TenSach = " Khách Sạn Ba Vì", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                break;
        //            }
        //        case ("KD"):
        //            {
        //                Sachs.Add(new Sach { MaSach = "SG", TenSach = " Khách Sạn Sài Gòn", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                Sachs.Add(new Sach { MaSach = "PH", TenSach = " PIANO Sach", Hinh = "PianoSach.jpg", Gia = 115000 });
        //                Sachs.Add(new Sach { MaSach = "SYH", TenSach = "Silverland Yen Sach", Hinh = "SilverlandSach.jpg", Gia = 115000 });
        //                break;
        //            }
        //        case ("TN"):
        //            {
        //                Sachs.Add(new Sach { MaSach = "HPS", TenSach = " Khách sạn Hoa Păng Sê Đà Lạt ", Hinh = "ThieuNhi.jpg", Gia = 115000 });
        //                break;
        //            }
        //        case ("VT"):
        //            {
        //                Sachs.Add(new Sach { MaSach = "HH", TenSach = " Hafi Sach", Hinh = "HH.jpg", Gia = 115000 });
        //                break;
        //            }
        //        case ("KNS"):
        //            {
        //                Sachs.Add(new Sach { MaSach = "Hue", NaTenSachme = " Hue Serene Palace Sach", Hinh = "HH.jpg", Gia = 115000 });
        //                break;
        //            }

        //        default:
        //            {
        //                break;
        //            }
        //    }
        //    LstSach.ItemsSource = Sachs;
        //}

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
            DisplayAlert(Sachchon.TenSach, "Đã chọn", "OK");
        }
    }
}