﻿using Newtonsoft.Json;
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
    public partial class DaDangNhap : ContentPage
    {
        string TENDANGNHAP;
        APIString APIString = new APIString();
        public DaDangNhap(string TenDangNhap)
        {
            InitializeComponent();
            TENDANGNHAP = TenDangNhap;
            KhoiTao(TenDangNhap);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            KhoiTao(TENDANGNHAP);
        }

        async void KhoiTao(string TenDangNhap)
        {
            HttpClient httpClient = new HttpClient();
            var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "LayThongTinTaiKhoan?TenDangNhap=" + TenDangNhap);
            var ConnectAPIConvert = JsonConvert.DeserializeObject<List<TAIKHOAN>>(ConnectAPI);
            TenNguoiDung.Text = ConnectAPIConvert.First().TenKhachHang;
            Mail.Text = ConnectAPIConvert.First().Email;

            List<DanhMuc_TK> DanhMuc = new List<DanhMuc_TK>();
            DanhMuc.Add(new DanhMuc_TK { ID = "TTTK", Text = "Thông tin tài khoản", Icon = "icon_TTTK.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "DHCT", Text = "Đơn hàng của tôi", Icon = "icon_DHCT.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "DMK", Text = "Đổi mật khẩu", Icon = "icon_TDMK.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "DCGH", Text = "Địa chỉ giao hàng", Icon = "icon_DCGH.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "SPDX", Text = "Sản phẩm đã xem", Icon = "icon_SPDX.png", Icon_next = "icon_next.png" });
            DanhMuc.Add(new DanhMuc_TK { ID = "HT", Text = "Hỗ trợ", Icon = "icon_HT.png", Icon_next = "icon_next.png" });

            TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
            if (tENDANGNHAP.Get_TenDangNhap() == "admin")
            {
                DanhMuc.Add(new DanhMuc_TK { ID = "QLDH", Text = "Quản lý đơn hàng", Icon = "icon_bill.png", Icon_next = "icon_next.png" });
                DanhMuc.Add(new DanhMuc_TK { ID = "QLMGG", Text = "Quản lý mã giảm giá", Icon = "icon_discount.png", Icon_next = "icon_next.png" });
                DanhMuc.Add(new DanhMuc_TK { ID = "QLPGH", Text = "Quản lý phí giao hàng", Icon = "icon_delivery.png", Icon_next = "icon_next.png" });
            }

            lst_taikhoan.ItemsSource = DanhMuc;
        }

        private void lst_taikhoan_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DanhMuc_TK danhMuc_TK = (DanhMuc_TK)lst_taikhoan.SelectedItem;
            lst_taikhoan.SelectedItem = "";
            switch (danhMuc_TK.ID)
            {
                case "TTTK":
                    Navigation.PushAsync(new ThongTinTaiKhoan(TENDANGNHAP));
                    break;
                case "DMK":
                    Navigation.PushAsync(new DoiMatKhau(TENDANGNHAP));
                    break;
                case "DHCT":
                    Navigation.PushAsync(new DonHangCuaToi(TENDANGNHAP));
                    break;
                case "DCGH":
                    Navigation.PushAsync(new DiaChi(TENDANGNHAP));
                    break;
                case "HT":
                    Navigation.PushAsync(new HoTro());
                    break;
                case "SPDX":
                    Navigation.PushAsync(new ManHinhListSach(TENDANGNHAP));
                    break;
                case "QLDH":
                    Navigation.PushAsync(new Admin_DanhSachDonHang());
                    break;
                case "QLMGG":
                    Navigation.PushAsync(new Admin_MaGiamGia());
                    break;
                case "QLPGH":
                    Navigation.PushAsync(new Admin_ChiPhiGiaoHang());
                    break;

            }

        }

        private void bnt_dangxuat_Clicked(object sender, EventArgs e)
        {
            TENDANGNHAP tENDANGNHAP = new TENDANGNHAP();
            tENDANGNHAP.SetNull_TenDangNhap();
            Navigation.PushModalAsync(new MainPage());
        }
    }
}