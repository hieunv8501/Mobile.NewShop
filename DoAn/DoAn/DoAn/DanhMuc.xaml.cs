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
            LoaiSachs.Add(new LoaiSach { MaLoaiSach = "BC", TenLoaiSach = "Sách Bán Chạy", Hinh = "BanChay.jpg" });
            LoaiSachs.Add(new LoaiSach { MaLoaiSach = "KD", TenLoaiSach = "Sách Quản Lý - Kinh Doanh", Hinh = "KinhDoanh.jpg" });
            LoaiSachs.Add(new LoaiSach { MaLoaiSach = "NN", TenLoaiSach = "Sách Ngoại Ngữ", Hinh = "NgoaiNgu.jpg" });
            LoaiSachs.Add(new LoaiSach { MaLoaiSach = "TN", TenLoaiSach = "Sách Thiếu Nhi", Hinh = "ThieuNhi.jpg" });
            LoaiSachs.Add(new LoaiSach { MaLoaiSach = "KNS", TenLoaiSach = "Sách Kỹ Năng Sống", Hinh = "YChi.jpg" });
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
            }
        }
    }
}