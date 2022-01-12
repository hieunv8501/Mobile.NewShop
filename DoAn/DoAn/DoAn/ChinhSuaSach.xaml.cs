using Newtonsoft.Json;
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
    public partial class ChinhSuaSach : ContentPage
    {
        APIString APIString = new APIString();
        public ChinhSuaSach()
        {
            InitializeComponent();
        }
        Sach globalSach = new Sach();
        List<LoaiSach> loaisachs = new List<LoaiSach>();
        public ChinhSuaSach(Sach sach)
        {
            InitializeComponent();
            pickerLoaiSach();
            Title = "Chỉnh sửa sách: " + sach.TenSach;
            globalSach = sach;

            string[] subs = sach.Hinh.Split('/');

            txtHinh.Text = subs[subs.Length - 1];

            txtMoTa.Text = sach.MoTa;
            txtNameSach.Text = sach.TenSach;
            GiaTien.Text =sach.Gia.ToString();
            GiamGia.Text = sach.GiamGia.ToString();

        }
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
                    if (ct.MaLoaiSach == globalSach.MaLoaiSach.ToString())
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
        private async void cmdCapNhat_Clicked(object sender, EventArgs e)
        {

            double giatien = new double();
            bool check = double.TryParse(GiaTien.Text, out giatien);
            if (!check)
            {
                await DisplayAlert("Thông Báo", "Giá tiền không đúng kiểu", "OK");

            }
            else
            {

                HttpClient http = new HttpClient();
                try
                {
                    var kq = await http.GetStringAsync(APIString.str + "CapNhatSach?MaSach=" + globalSach.MaSach + "&MaLoaiSach=" + loaisachs[ChonLoaiSach.SelectedIndex].MaLoaiSach + "&TenSach=" + txtNameSach.Text + "&Gia=" + giatien + "&MoTa=" + txtMoTa.Text + "&Hinh=" + APIString.str_img + txtHinh.Text);
                    if (int.Parse(kq) > 0)
                    {
                        await DisplayAlert("Thông Báo", "Bạn đã chỉnh sửa thành công", "OK");
                        await Navigation.PushAsync(new SachAdmin(loaisachs[ChonLoaiSach.SelectedIndex]));
                    }
                    else
                    {
                        await DisplayAlert("Thông Báo", "Chỉnh sửa thất bại ", "OK");
                    }

                }
                catch
                {
                    {
                        await DisplayAlert("Thông Báo", "Chỉnh sửa thất bại", "OK");
                    }
                }
            }
        }
    }
}