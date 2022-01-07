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
    public partial class DanhMuc : ContentPage
    {
        public DanhMuc()
        {
            InitializeComponent();
            TaoCacLoaiSach();

        }
        List<LoaiSach> LoaiSachs = new List<LoaiSach>();
        async void TaoCacLoaiSach()
        {
            try
            {
                HttpClient http = new HttpClient();
                var kq = await http.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/LayDanhSachLoaiSach");
                var loaisach = JsonConvert.DeserializeObject<List<LoaiSach>>(kq);
                List<LoaiSach> ls2 = new List<LoaiSach>();
                List<LoaiSach> ls1 = new List<LoaiSach>();
                for (int i = 0; i < loaisach.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ls1.Add(loaisach[i]);
                    }
                    else
                    { ls2.Add(loaisach[i]); }
                }
                LstLoaiSach.ItemsSource = ls1;
                LstLoaiSach1.ItemsSource = ls2;
                LoaiSachs = loaisach;
            }
            catch { LstLoaiSach.ItemsSource = null; }
        }
        private void search_Clicked(object sender, EventArgs e)
        {
            //
        }
        IEnumerable<LoaiSach> GetDanhMuc(string searchtext = null)
        {
            List<LoaiSach> search = new List<LoaiSach>();
            if (string.IsNullOrEmpty(searchtext))
            {
                return search;
            }
            return LoaiSachs.Where(p => p.TenLoaiSach.Contains(searchtext));
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstLoaiSach.ItemsSource = LoaiSachs.Where(p => p.TenLoaiSach.ToLower().Contains(Search.Text.ToLower()));

        }

        private void LstLoaiSach_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstLoaiSach.SelectedItem != null)
            {
                LoaiSach clicked_LoaiSach = (LoaiSach)LstLoaiSach.SelectedItem;
                Navigation.PushAsync(new ManHinhListSach(clicked_LoaiSach));
                LstLoaiSach.SelectedItem = null;
            }
        }
        private void LstLoaiSach_ItemSelected1(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstLoaiSach1.SelectedItem != null)
            {
                LoaiSach clicked_LoaiSach1 = (LoaiSach)LstLoaiSach1.SelectedItem;
                Navigation.PushAsync(new ManHinhListSach(clicked_LoaiSach1));
                LstLoaiSach1.SelectedItem = null;
            }
        }
    }
}