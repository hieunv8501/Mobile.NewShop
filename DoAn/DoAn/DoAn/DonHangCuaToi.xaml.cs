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
    public partial class DonHangCuaToi : ContentPage
    {
        string TENDANGNHAP;
        APIString APIString = new APIString();
        public DonHangCuaToi()
        {
            InitializeComponent();
        }
        public DonHangCuaToi(string TenDangNhap)
        {
            InitializeComponent();
            KhoiTao(TenDangNhap);
            TENDANGNHAP = TenDangNhap;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            KhoiTao(TENDANGNHAP);
        }

        async void KhoiTao(string TenDangNhap)
        {
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayThongTinHoaDon?TenDangNhap=" + TenDangNhap);
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
            Navigation.PushAsync(new ChiTietDonHang(hOADON.MaHoaDon));
        }

        private async void btnXoa_Clicked(object sender, EventArgs e)
        {
            SwipeItem selected = (SwipeItem)sender;
            string MaHoaDon = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayChiTietHoaDon?MaHoaDon=" + MaHoaDon);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<CT_DONHANG>>(ConnectAPI);
            var SelectOne = ConnectAPIConvert.First();
            if (SelectOne.TinhTrang == false)
            {

                if ((DateTime.Now - SelectOne.NgayHoaDon).TotalHours < 24)
                {
                    var userchoice = await DisplayAlert("Thông báo", "Bạn có chắc muốn hủy hóa đơn này?", "Có", "Không");
                    if (userchoice)
                    {
                        try
                        {
                            var ConnectAPIXoa = await httpClient.GetStringAsync(APIString.str + "XoaChiTietHoaDon?MaHoaDon=" + MaHoaDon);
                            await DisplayAlert("Thông báo", "Đã hủy đơn hàng thành công", "Ok");
                            OnAppearing();
                        }
                        catch
                        {
                            await DisplayAlert("Thông báo", "Hủy thất bại", "Ok");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Thông báo", "Đã qua 24 giờ, không thể hủy đơn hàng", "Ok");
                }
            }
            else
            {
                var userchoice = await DisplayAlert("Thông báo", "Bạn có chắc muốn xóa đơn hàng này?", "Có", "Không");
                if (userchoice)
                {
                    var ConnectAPIXoa = await httpClient.GetStringAsync(APIString.str + "XoaChiTietHoaDon?MaHoaDon=" + MaHoaDon);
                    OnAppearing();
                }
            }
        }
    }
}