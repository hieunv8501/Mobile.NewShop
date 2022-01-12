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
        APIString APIString = new APIString();
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
                var kq = await http.GetStringAsync(APIString.str + "LayDanhSachLoaiSach");
                var loaisach = JsonConvert.DeserializeObject<List<LoaiSach>>(kq);
                
                LstLoaiSach.ItemsSource = loaisach;
                
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

        
        
        private void LstLoaiSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstLoaiSach.SelectedItem != null)
            {
                LoaiSach clicked_LoaiSach = (LoaiSach)LstLoaiSach.SelectedItem;
                Navigation.PushAsync(new ManHinhListSach(clicked_LoaiSach));
                LstLoaiSach.SelectedItem = null;
            }
        }
    }
}