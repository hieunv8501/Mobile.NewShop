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
            LayDanhSachLoaiSach();
        }

        private void CarouselInit()
        {
            var list = new List<string>
            {
                "slider5.jpg", "slider6.jpg", "slider7.jpg", "slider8.jpg", "slider9.jpg", "slider10.jpg", "slider11.png", "slider12.jpg",
            };
            TheCarousel.ItemsSource = list;
        }

        private void btnGH_Clicked(object sender, EventArgs e)
        {
            if (TENDANGNHAP.TenDangNhap == null || TENDANGNHAP.TenDangNhap == "")
            {
                DisplayAlert("Thông báo", "Vui lòng đăng nhập", "OK");
                Navigation.PushAsync(new DangNhap());
            }
            else Navigation.PushAsync(new GioHang());
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
        public async void LayDanhSachSachKM()
        {
            var httpClient = new HttpClient();
            var resachlv = await httpClient.GetStringAsync(APIString.str + "LayDanhSachSachTheoKhuyenMai");
            var dsSachKhuyenMai = JsonConvert.DeserializeObject<List<Sach>>(resachlv);
            listKHUYENMAI.ItemsSource = dsSachKhuyenMai;
            listKHUYENMAI.WidthRequest = (dsSachKhuyenMai.Count() / 2 + 1) * 200;
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

        Sach sachlv = new Sach();
       
        private void listKHUYENMAI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                if (listKHUYENMAI.SelectedItem != null)
                {
                    sachlv = (Sach)listKHUYENMAI.SelectedItem;
                    Navigation.PushAsync(new ChiTietSachAdmin(sachlv));
                    listKHUYENMAI.SelectedItem = null;
                }
            }
            else
            {
                if (listKHUYENMAI.SelectedItem != null)
                {
                    sachlv = (Sach)listKHUYENMAI.SelectedItem;
                    Navigation.PushAsync(new ChiTietSach(sachlv));
                    listKHUYENMAI.SelectedItem = null;
                }
            }
        }

        private void listBANCHAY_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                if (listBANCHAY.SelectedItem != null)
                {
                    sachlv = (Sach)listBANCHAY.SelectedItem;
                    Navigation.PushAsync(new ChiTietSachAdmin(sachlv));
                    listBANCHAY.SelectedItem = null;
                }
            }
            else
            {
                if (listBANCHAY.SelectedItem != null)
                {
                    sachlv = (Sach)listBANCHAY.SelectedItem;
                    Navigation.PushAsync(new ChiTietSach(sachlv));
                    listBANCHAY.SelectedItem = null;
                }
            }
        }

        private void listLTQG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                if (listLTQG.SelectedItem != null)
                {
                    sachlv = (Sach)listLTQG.SelectedItem;
                    Navigation.PushAsync(new ChiTietSachAdmin(sachlv));
                    listLTQG.SelectedItem = null;
                }
            }
            else
            {
                if (listLTQG.SelectedItem != null)
                {
                    sachlv = (Sach)listLTQG.SelectedItem;
                    Navigation.PushAsync(new ChiTietSach(sachlv));
                    listLTQG.SelectedItem = null;
                }
            }
        }

        private void listVH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                if (listVH.SelectedItem != null)
                {
                    sachlv = (Sach)listVH.SelectedItem;
                    Navigation.PushAsync(new ChiTietSachAdmin(sachlv));
                    listVH.SelectedItem = null;
                }
            }
            else
            {
                if (listVH.SelectedItem != null)
                {
                    sachlv = (Sach)listVH.SelectedItem;
                    Navigation.PushAsync(new ChiTietSach(sachlv));
                    listVH.SelectedItem = null;
                }
            }
        }

        private void listNN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                if (listNN.SelectedItem != null)
                {
                    sachlv = (Sach)listNN.SelectedItem;
                    Navigation.PushAsync(new ChiTietSachAdmin(sachlv));
                    listNN.SelectedItem = null;
                }
            }
            else
            {
                if (listNN.SelectedItem != null)
                {
                    sachlv = (Sach)listNN.SelectedItem;
                    Navigation.PushAsync(new ChiTietSach(sachlv));
                    listNN.SelectedItem = null;
                }
            }
        }
        ////////////////////////////
        LoaiSach listls = new LoaiSach();
        private List<LoaiSach> listbtnSachMore;
        public async void LayDanhSachLoaiSach()
        {
            var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(APIString.str + "LayDanhSachLoaiSach");
            listbtnSachMore = JsonConvert.DeserializeObject<List<LoaiSach>>(res);
        }
        private void btnBanChayMore_Clicked(object sender, EventArgs e)
        {
            listls = listbtnSachMore.Where(c => c.TenLoaiSach == "Sách Bán Chạy").FirstOrDefault();
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                Navigation.PushAsync(new SachAdmin(listls));
            }
            else
            {
                Navigation.PushAsync(new ManHinhListSach(listls));
            }
        }

        private void btnLTQGMore_Clicked(object sender, EventArgs e)
        {
            listls = listbtnSachMore.Where(c => c.TenLoaiSach == "Sách Luyện Thi THPT Quốc Gia").FirstOrDefault();
            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                Navigation.PushAsync(new SachAdmin(listls));
            }
            else
            {
                Navigation.PushAsync(new ManHinhListSach(listls));
            }
        }

        private void btnVanHocMore_Clicked(object sender, EventArgs e)
        {
            listls = listbtnSachMore.Where(c => c.TenLoaiSach == "Sách Văn Học").FirstOrDefault();

            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                Navigation.PushAsync(new SachAdmin(listls));
            }
            else
            {
                Navigation.PushAsync(new ManHinhListSach(listls));
            }
        }

        private void btnNN_Clicked(object sender, EventArgs e)
        {
            listls = listbtnSachMore.Where(c => c.TenLoaiSach == "Sách Ngoại Ngữ").FirstOrDefault();

            if (TENDANGNHAP.TenDangNhap == "admin")
            {
                Navigation.PushAsync(new SachAdmin(listls));
            }
            else
            {
                Navigation.PushAsync(new ManHinhListSach(listls));
            }
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