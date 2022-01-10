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
    public partial class Admin_DanhSachDonHang : ContentPage
    {
        APIString APIString = new APIString();

        public Admin_DanhSachDonHang()
        {
            InitializeComponent();
            KhoiTao();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            KhoiTao();
        }

        async void KhoiTao()
        {
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayTatCaHoaDon");
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<HOADON>>(ConnectAPI);
            for (int i = 1; i < ConnectAPIConvert.Count(); i++)
            {

                if (ConnectAPIConvert[i].MaHoaDon == ConnectAPIConvert[i - 1].MaHoaDon)
                {
                    ConnectAPIConvert.RemoveAt(i - 1);
                    i--;

                }
            }


            if (ConnectAPIConvert.ToString() == "[]")
            {
                lst_donhang.ItemsSource = null;
            }
            else
            {
                lst_donhang.ItemsSource = ConnectAPIConvert;
            }
        }

        private void lst_donhang_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HOADON hOADON = (HOADON)lst_donhang.SelectedItem;
            lst_donhang.SelectedItem = "";
            Navigation.PushAsync(new Admin_ChiTietDonHang(hOADON.MaHoaDon));
        }

        //private async void btnDaGiaoHang_Clicked(object sender, EventArgs e)
        //{
        //    Button selected = (Button)sender;
        //    string MaHoaDon = selected.CommandParameter.ToString();

        //    var userchoice = await DisplayAlert("Thông báo", MaHoaDon, "Có", "Không");
        //    HttpClient httpClient = new HttpClient();

        //    var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayChiTietHoaDon?MaHoaDon=" + MaHoaDon);
        //    var ConnectAPIConvert = JsonConvert.DeserializeObject<List<CT_DONHANG>>(ConnectAPI);
        //    var SelectOne = ConnectAPIConvert.First();
        //    if (SelectOne.TinhTrang == false)
        //    {
        //        var userchoice = await DisplayAlert("Thông báo", "Bạn đã giao đơn hàng này thành công?", "Có", "Không");
        //        if (userchoice)
        //        {
        //            var ConnectAPICapNhat = await httpClient.GetStringAsync(APIString.str + "CapNhapTinhTrangHoaDon?MaHoaDon=" + MaHoaDon);
        //            OnAppearing();
        //        }
        //    }
        //    else
        //    {
        //        var userchoice = await DisplayAlert("Thông báo", "Bạn có chắc muốn xóa hóa đơn này?", "Có", "Không");
        //        if (userchoice)
        //        {
        //            var ConnectAPIXoa = await httpClient.GetStringAsync(APIString.str + "XoaChiTietHoaDon?MaHoaDon=" + MaHoaDon);
        //            OnAppearing();
        //        }
        //    }


        //}

        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            if (lbMaDonHang.Text != null && lbMaDonHang.Text.Trim() != "")
            {

                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayThongTinHoaDonTheoMa?MaHoaDon=" + lbMaDonHang.Text);
                var ConnectAPIConvert = JsonConvert.DeserializeObject<List<HOADON>>(ConnectAPI);
                if (ConnectAPIConvert.ToString() == "[]")
                {
                    lst_donhang.ItemsSource = null;
                }
                else
                {
                    lst_donhang.ItemsSource = ConnectAPIConvert;
                }
            }
            else
            {
                OnAppearing();
            }

        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            string MaHoaDon = swipeItem.CommandParameter.ToString();

            //var userchoice =  await DisplayAlert("Thông báo", MaHoaDon, "Có", "Không");
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayChiTietHoaDon?MaHoaDon=" + MaHoaDon);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<CT_DONHANG>>(ConnectAPI);
            var SelectOne = ConnectAPIConvert.First();
            if (SelectOne.TinhTrang == false)
            {
                var userchoice = await DisplayAlert("Thông báo", "Bạn đã giao đơn hàng này thành công?", "Có", "Không");
                if (userchoice)
                {
                    var ConnectAPICapNhat = await httpClient.GetStringAsync(APIString.str + "CapNhapTinhTrangHoaDon?MaHoaDon=" + MaHoaDon);
                    OnAppearing();
                }
            }
            else
            {
                var userchoice = await DisplayAlert("Thông báo", "Bạn có chắc muốn xóa hóa đơn này?", "Có", "Không");
                if (userchoice)
                {
                    var ConnectAPIXoa = await httpClient.GetStringAsync(APIString.str + "XoaChiTietHoaDon?MaHoaDon=" + MaHoaDon);
                    OnAppearing();
                }
            }
        }
    }
}