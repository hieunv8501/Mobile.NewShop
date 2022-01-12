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
    public partial class ChiTietDonHang : ContentPage
    {
        APIString APIString = new APIString();
        public ChiTietDonHang()
        {
            InitializeComponent();
        }
        public ChiTietDonHang(int MaHoaDon)
        {
            InitializeComponent();
            KhoiTao(MaHoaDon);
        }
        async void KhoiTao(int MaHoaDon)
        {
            HttpClient httpClient = new HttpClient();

            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayChiTietHoaDon?MaHoaDon=" + MaHoaDon);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<CT_DONHANG>>(ConnectAPI);
            var SelectOne = ConnectAPIConvert.First();

            MDH.Text = "Mã đơn hàng: " + SelectOne.MaHoaDon.ToString();
            TinhTrang.Text = SelectOne.TinhTrangDisplay;
            tennguoinhan.Text = SelectOne.TenNguoiNhan;
            sdt.Text = SelectOne.SDT;
            diachi.Text = "Địa chỉ:" + SelectOne.DiaChi;
            hinhthucvanchuyen.Text = SelectOne.HinhThucGiao;
            hinhthucthanhtoan.Text = SelectOne.HinhThucThanhToan;

            phivanchuyen.Text = SelectOne.PhiVanChuyen.ToString();
            tongthanhtoan.Text = SelectOne.TongTien.ToString();

            lstCT_DONHANG.ItemsSource = ConnectAPIConvert;

        }
        private async void btnMuaLai_Clicked(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            string MaSach = selected.CommandParameter.ToString();

            HttpClient httpClient = new HttpClient();
            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LaySachTheoMaSach?MaSach=" + MaSach);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<Sach>>(ConnectAPI);
            var First = ConnectAPIConvert.First();

            await Navigation.PushAsync(new ChiTietSach(First));
        }
    }
}