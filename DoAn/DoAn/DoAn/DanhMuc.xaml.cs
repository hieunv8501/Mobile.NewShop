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
    public partial class DanhMuc : ContentPage
    {
        public DanhMuc()
        {
            InitializeComponent();
            TaoCacLoaiSach();
        }
        List<LoaiSach> LoaiSachs = new List<LoaiSach>();
        void TaoCacLoaiSach()
        {
            LoaiSachs.Add(new LoaiSach { ID = "BC", Name = "Sách Bán Chạy", ImageURL = "BanChay.jpg" });
            LoaiSachs.Add(new LoaiSach { ID = "KD", Name = "Sách Quản Lý - Kinh Doanh", ImageURL = "KinhDoanh.jpg" });
            LoaiSachs.Add(new LoaiSach { ID = "NN", Name = "Sách Ngoại Ngữ", ImageURL = "NgoaiNgu.jpg" });
            LoaiSachs.Add(new LoaiSach { ID = "TN", Name = "Sách Thiếu Nhi", ImageURL = "ThieuNhi.jpg" });
            LoaiSachs.Add(new LoaiSach { ID = "KNS", Name = "Sách Kỹ Năng Sống", ImageURL = "YChi.jpg" });
            LstLoaiSach.ItemsSource = LoaiSachs;
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
            return LoaiSachs.Where(p => p.Name.Contains(searchtext));
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstLoaiSach.ItemsSource = LoaiSachs.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower()));

        }

        private void LstLoaiSach_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LstLoaiSach.SelectedItem != null)
            {
                LoaiSach clicked_LoaiSach = (LoaiSach)LstLoaiSach.SelectedItem;
                Navigation.PushAsync(new ManHinhListSach(clicked_LoaiSach));
            }
        }
    }
}