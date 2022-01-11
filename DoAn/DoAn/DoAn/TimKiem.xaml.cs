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
    public partial class TimKiem : ContentPage
    {
        APIString APIString = new APIString();

        public TimKiem()
        {
            InitializeComponent();
            KhoiTaoTimKiemAsync();

        }
        List<LoaiSach> SachLoai = new List<LoaiSach>();
        List<Sach> SachSach = new List<Sach>();
        async void KhoiTaoTimKiemAsync()
        {
            
            HttpClient http = new HttpClient();
            var kq1 = await http.GetStringAsync(APIString.str + "LayDanhSachLoaiSach");
            var kq2 = await http.GetStringAsync(APIString.str + "LayDanhSachSach");
            SachLoai = JsonConvert.DeserializeObject<List<LoaiSach>>(kq1);
            SachSach = JsonConvert.DeserializeObject<List<Sach>>(kq2);
        }


        private void btnGH_Clicked(object sender, EventArgs e)
        {
            //
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnEntryTK_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (btnEntryTK.Text == null || btnEntryTK.Text == "")
            {
                LstTK.ItemsSource = null;
                LstTK1.ItemsSource = null;
            }
            else
            {
                var count1 = SachLoai.Where(c => c.TenLoaiSach.ToLower().Contains(btnEntryTK.Text.ToLower()));
                var count2 = SachSach.Where(c => c.TenSach.ToLower().Contains(btnEntryTK.Text.ToLower()));

                if (count1 == null) LstTK.IsVisible = false;
                else
                {
                    LstTK.ItemsSource = count1;
                    LstTK.RowHeight = 90;
                    LstTK.HeightRequest = count1.Count() * 95; 
                }
                if (count2 == null) LstTK.IsVisible = false;
                else
                {
                    LstTK.ItemsSource = count2;
                    LstTK.RowHeight = 90;
                    LstTK.HeightRequest = (count2.Count() * 95);
                }
            }
            
        }
    }
}