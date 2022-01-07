﻿using System;
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
    public partial class ChiTietSachAdmin : ContentPage
    {
        public ChiTietSachAdmin()
        {
            InitializeComponent();
        }
        public ChiTietSachAdmin(Sach sach)
        {
            InitializeComponent();
            Title = "Thông tin chi tiết sách";
            image.Source = sach.Hinh;
            tensach.Text = sach.TenSach;
            mota.Text = sach.MoTa;
            image.MinimumHeightRequest = 300;
            image.MinimumWidthRequest = 300;
            image.WidthRequest = 300;
            image.HeightRequest = 300;
            //giaban.Text = sach.Price.ToString("C");
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            giaban.Text = string.Format(cultureInfo, "{0:C}", sach.Gia);

        }
        private void cmdChonMua_Clicked(object sender, EventArgs e)
        {
            Button chon = (Button)sender;
            Sach Sachchon = (Sach)chon.CommandParameter;
            DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
        }
    }
}