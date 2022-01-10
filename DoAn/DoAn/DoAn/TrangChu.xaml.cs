using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrangChu : ContentPage
    {
        APIString APIString = new APIString();
        public TrangChu()
        {
            InitializeComponent();
            CarouselInit();
            LayDanhSachSachKM();
            PhoneCall();
            LayDanhSachSachTheoMaLoai(1); LayDanhSachSachTheoMaLoai(3); LayDanhSachSachTheoMaLoai(5); LayDanhSachSachTheoMaLoai(8);

        }
        //public static string GetLocalIPAddress()
        //{
        //    var host = Dns.GetHostEntry(Dns.GetHostName());
        //    foreach (var ip in host.AddressList)
        //    {
        //        if (ip.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            return ip.ToString();
        //        }
        //    }
        //    throw new Exception("No network adapters with an IPv4 address in the system!");
        //}
        private void CarouselInit()
        {
            var list = new List<string>
            {
                "slider5.jpg", "slider6.jpg", "slider7.jpg", "slider8.jpg", "slider9.jpg", "slider10.jpg", "slider11.png", "slider12.jpg",
            };
            TheCarousel.ItemsSource = list;
        }
        public async void LayDanhSachSachKM()
        {
            var httpClient = new HttpClient();
            var resKM = await httpClient.GetStringAsync(APIString.str + "LayDanhSachSachTheoKhuyenMai");
            var dsSachKhuyenMai = JsonConvert.DeserializeObject<List<Sach>>(resKM);
            listKHUYENMAI.ItemsSource = dsSachKhuyenMai;
            listKHUYENMAI.WidthRequest = (dsSachKhuyenMai.Count() / 2 + 1) * 200;
            //listMoiCapNhap.ItemsSource = dsSach.GetRange(0, 6);
        }
        public async void LayDanhSachSachTheoMaLoai(int MaLoaiSach)
        {

            var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(APIString.str + "LayDanhSachSachTheoLoaiSach?MaLoaiSach=" + MaLoaiSach);
            var dsSach = JsonConvert.DeserializeObject<List<Sach>>(res);
            switch (MaLoaiSach)
            {
                case 1:
                    {
                        listVH.ItemsSource = dsSach;
                        listVH.WidthRequest = (dsSach.Count() * 110);
                        break;
                    }
                case 3:
                    {
                        listBANCHAY.ItemsSource = dsSach;
                        listBANCHAY.WidthRequest = (dsSach.Count() * 110);
                        break;
                    }
                case 5:
                    {
                        listNN.ItemsSource = dsSach;
                        listNN.WidthRequest = (dsSach.Count() * 110);
                        break;
                    }
                case 8:
                    {
                        listLTQG.ItemsSource = dsSach;
                        listLTQG.WidthRequest = (dsSach.Count() * 110);
                        break;
                    }
                default:
                    break;
            }
        }

        //private void listKHUYENMAI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
        LoaiSach ls = new LoaiSach();
        private void btnBanChayMore_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLTQGMore_Clicked(object sender, EventArgs e)
        {
            //
        }

        private void btnVanHocMore_Clicked(object sender, EventArgs e)
        {
            //
        }

        private void btnNN_Clicked(object sender, EventArgs e)
        {
            //
        }

        private void btnGH_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSearchTK_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimKiem());
        }
        private void PhoneCall()
        {
            phone1.TextTransform = phone2.TextTransform = TextTransform.None;
            phone1.Text = "02866825005" + "\n" + "Hotline mua hàng online";
            phone2.Text = "0909354135" + "\n" + "Hotline mua hàng online";
        }
        private void phone1_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var number = btn.Text.Substring(0, 11);
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException)
            {
                DisplayAlert("Lỗi", "Không có số điện thoại hợp lệ", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                DisplayAlert("Lỗi", "Dịch vụ cuộc gọi không hỗ trợ trên thiết bị này.", "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Lỗi", "Vui lòng thử lại", "OK");
            }
        }

        private void phone2_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var number = btn.Text.Substring(0, 10);
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException)
            {
                DisplayAlert("Lỗi", "Không có số điện thoại hợp lệ", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                DisplayAlert("Lỗi", "Phone Dialer is not supported on this device.", "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Lỗi", "Vui lòng thử lại", "OK");
            }
        }
    }
}