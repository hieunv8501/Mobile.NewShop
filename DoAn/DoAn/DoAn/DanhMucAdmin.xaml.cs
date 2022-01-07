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
    public partial class DanhMucAdmin : ContentPage
    {
        public DanhMucAdmin()
        {

            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            TaoCacLoaiSach();
        }
        List<LoaiSach> LoaiSachs = new List<LoaiSach>();
        async void TaoCacLoaiSach()
        {

            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/LayDanhSachLoaiSach");
                var loaisach = JsonConvert.DeserializeObject<List<LoaiSach>>(kq);
                LstLoaiSach.ItemsSource = loaisach;
                LoaiSachs = loaisach;
            }
            catch
            {
                LstLoaiSach.ItemsSource = null;
            }
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
                Navigation.PushAsync(new SachAdmin(clicked_LoaiSach));
                LstLoaiSach.SelectedItem = null;
            }
        }

        private async void cmdXoa_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            LoaiSach item = (LoaiSach)b.CommandParameter;
            HttpClient http = new HttpClient();
            try
            {
                var kq = await http.GetStringAsync("http://192.168.1.4/newshopwebapi/api/ServiceController/XoaLoaiSach?MaLoaiSach=" + item.MaLoaiSach);
                if (int.Parse(kq) > 0)
                {
                    await DisplayAlert("Thông Báo", "Bạn đã xóa thành công", "OK");
                    await Navigation.PushAsync(new DanhMucAdmin());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Xóa thất bại ", "OK");
                }

            }
            catch
            {
                {
                    await DisplayAlert("Thông Báo", "Xóa thất bại!", "OK");
                }
            }
        }

        private void cmnChinhSua_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            LoaiSach item = (LoaiSach)b.CommandParameter;
            Navigation.PushAsync(new ChinhSuaDanhMucAdmin(item));
        }

        private void cmdThemLS_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemDanhMucAdmin());

        }
    }
}