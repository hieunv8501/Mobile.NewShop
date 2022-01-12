
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemSachAdmin : ContentPage
    {
    APIString APIString = new APIString();
        public ThemSachAdmin()
        {
            InitializeComponent();
            Title = "Thêm sách";
        }
        LoaiSach loaisach = new LoaiSach();
        List<LoaiSach> loaisachs = new List<LoaiSach>();
        public ThemSachAdmin(LoaiSach sach1)
        {
            InitializeComponent();
            Title = "Thêm sách";
            loaisach = sach1;
            pickerLoaiSach();
        }
        //Chua xu ly picker loai sach.
        
        public async void pickerLoaiSach()
        {
            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync(APIString.str + "LayDanhSachLoaiSach");
                loaisachs = JsonConvert.DeserializeObject<List<LoaiSach>>(kq);
                ChonLoaiSach.ItemsSource = loaisachs;

                foreach (LoaiSach ct in loaisachs)
                {
                    if (ct.MaLoaiSach == loaisach.MaLoaiSach)
                    {
                        ChonLoaiSach.SelectedIndex = loaisachs.IndexOf(ct);
                        break;

                    }
                }
            }
            catch
            {
                ChonLoaiSach.ItemsSource = null;
            }
        }
        private async void cmdAddSach_Clicked(object sender, EventArgs e)
        {
            double giatien = new double();
            bool check = double.TryParse(GiaTien.Text, out giatien);
            if (!check)
            {
                await DisplayAlert("Thông Báo", "Giá tiền không đúng kiểu", "OK");

            }
            else
            {
                int giamgia = new int();
                bool check1 = int.TryParse(GiamGia.Text, out giamgia);
                if (check1)
                {
                    await DisplayAlert("Thông Báo", "Phần trăm giảm giá không đúng kiểu", "OK");
                }
                else
                {
                    if(giamgia<0||giamgia>100)
                    {
                        await DisplayAlert("Thông Báo", "Phần trăm giảm giá không hợp lệ", "OK");
                    }
                    else
                    {
                        HttpClient http = new HttpClient();
                        try
                        {
                            var kq = await http.GetStringAsync(APIString.str + "ThemSach?&MaLoaiSach=" + loaisachs[ChonLoaiSach.SelectedIndex].MaLoaiSach + "&TenSach=" + txtNameSach.Text + "&Gia=" + giatien + "&MoTa=" + txtMoTa.Text + "&Hinh=" + APIString.str_img+ txtHinh.Text + "&GiamGia=" + GiamGia.Text);
                            if (int.Parse(kq) > 0)
                            {
                                await DisplayAlert("Thông Báo", "Bạn đã thêm sách thành công", "OK");
                                await Navigation.PushAsync(new DanhMucAdmin());
                            }
                            else
                            {
                                await DisplayAlert("Thông Báo", "Thêm sách thất bại ", "OK");
                            }

                        }
                        catch
                        {
                            {
                                await DisplayAlert("Thông Báo", "Thêm sách thất bại", "OK");
                            }
                        }
                    }
                }
                    
                    
                
            }
        }
    }

}