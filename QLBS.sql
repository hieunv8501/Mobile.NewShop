create database QuanLyBanSach
go
use QuanLyBanSach
go

create table TAIKHOAN
(	
	TenDangNhap varchar(50) primary key,
	MatKhau varchar(50),
	TenKhachHang nvarchar(50),
	SoDienThoai varchar(10),
	Email varchar(50),
	NgaySinh datetime,
	GioiTinh bit
)

create table LOAISACH
(
	MaLoaiSach int identity(1,1) primary key,
	TenLoaiSach nvarchar(50),
	Hinh nvarchar(200),
)

create table SACH
(
	MaSach int identity(1,1) primary key,
	MaLoaiSach int,
	TenSach nvarchar(100),
	Gia money,
	MoTa nvarchar(max),
	Hinh nvarchar(200),
	GiamGia int
)
create table DIACHI
(
	MaDiaChi int IDENTITY(1,1) primary key,
	TenNguoiNhan nvarchar(50),
	SDT varchar(10),
	DiaChi nvarchar(100),
	TenDangNhap varchar(50),
	MacDinh bit,
)

create table HOADON 
(
	MaHoaDon int primary key,
	TenDangNhap varchar(50),
	NgayHoaDon datetime,
	TongTien money,
	HinhThucGiao nvarchar(50),--Set cứng giao hàng tiêu chuẩn
	HinhThucThanhToan nvarchar(50),--Set cứng tiền mặt
	MaDiaChi int,
	TinhTrang bit,
	PhiVanChuyen money,
)

create table GIAOHANG
(
	Gia money primary key,
)

create table CT_HOADON
(
	MaHoaDon int,
	MaSach int,
	SoLuong int,
	ThanhTien money,
	primary key (MaHoaDon, MaSach)
)

-- Giỏ hàng sẽ được tạo khi thêm tài khoản
create table GIOHANG 
(
	MaGioHang int IDENTITY(1,1) primary key,
	TenDangNhap varchar(50),
	DaDungMaGiamGia bit default 0,
	TongTien money default 0,
)

create table CT_GIOHANG 
(
	MaGioHang int,
	MaSach int,
	SoLuong int default 1,
	ThanhTien money,
	primary key (MaGioHang, MaSach)

)
create table MAGIAMGIA
(
	MaGiamGia varchar(5) primary key,
	TiLeGiam int,
)

alter table HOADON add constraint fk_HOADON_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
alter table CT_HOADON add constraint fk_CTHOADON_HOADON foreign key (MaHoaDon) references HOADON(MaHoaDon)
alter table CT_HOADON add constraint fk_CTHOADON_SACH foreign key (MaSach) references SACH(MaSach)
alter table SACH add constraint fk_SACH_LOAISACH foreign key (MaLoaiSach) references LOAISACH(MaLoaiSach)
alter table DIACHI add constraint fk_DIACHI_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
alter table HOADON add constraint fk_HOADON_DIACHI foreign key (MaDiaChi) references DIACHI(MaDiaChi)
alter table GIOHANG add constraint fk_GIOHANG_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
alter table CT_GIOHANG add constraint fk_CTGIOHANG_SACH foreign key (MaSach) references SACH(MaSach)
alter table CT_GIOHANG add constraint fk_CTGIOHANG_GIOHANG foreign key (MaGioHang) references GIOHANG(MaGioHang)
set dateformat dmy;

-- Đổi IP trong link, với cú pháp replace(column_name, 'old_IP', 'new_IP')
update SACH
set Hinh = replace(Hinh,'localhost','192.168.1.4/newshopwebapi')
where Hinh is not null;
update LOAISACH
set Hinh = replace(Hinh,'localhost','192.168.1.4/newshopwebapi')
where Hinh is not null;

--select * from SACH
--select * from LOAISACH

insert into TAIKHOAN values ('hieu', '1' , N'Hiếu', '0123456789', 'hieu@gmail.com', 01/01/2001, 1), ('hau', '1', N'Hậu', '0987654321', 'hau@gmail.com', 01/01/2001, 1), ('tinh', '1', N'Tình', '0984221251', 'tinh@gmail.com', 01/01/2001, 1)
insert into LOAISACH values (N'Sách Văn Học', N'http://192.168.1.4/newshopwebapi/Image/vanhoc.jpg'), 
			(N'Sách Tham Khảo', N'http://192.168.1.4/newshopwebapi/Image/thamkhao.jpg'), 
			(N'Sách Bán Chạy', N'http://192.168.1.4/newshopwebapi/Image/BanChay.jpg'), 
			(N'Sách Quản Lý - Kinh Doanh', N'http://192.168.1.4/newshopwebapi/Image/NgoaiNgu.jpg'), 
			(N'Sách Ngoại Ngữ', N'http://192.168.1.4/newshopwebapi/Image/NgoaiNgu.jpg'),
			(N'Sách Thiếu Nhi', N'http://192.168.1.4/newshopwebapi/Image/ThieuNhi.jpg'),
			(N'Sách Kỹ Năng Sống', N'http://192.168.1.4/newshopwebapi/Image/YChi.jpg'),
			(N'Sách Luyện Thi THPT Quốc Gia', N'http://192.168.1.4/newshopwebapi/Image/THPTQG.jpg'),
			(N'Sách Nghệ Thuật - Kiến Trúc', N'http://192.168.1.4/newshopwebapi/Image/NTKT.jpg'),
			(N'Sách Chính Trị - Luật Pháp', N'http://192.168.1.4/newshopwebapi/Image/CTLP.jpg')	,
			(N'Sách Tâm Lý - Giáo Dục Nuôi Dạy Con', N'http://192.168.1.4/newshopwebapi/Image/TamLy.jpg'),
			(N'Sách Kiến Thức Bách Khoa', N'http://192.168.1.4/newshopwebapi/Image/KTBK.jpg')	
--select * from LOAISACH

insert into SACH values (1, N'Phía Tây Thành Phố', 500000, N'Phía Tây Thành Phố - Tập tản văn cũng có những chiêm nghiệm khác rút ra từ cuộc sống hàng ngày, thể hiện cách nhìn đời nhẹ nhàng, vị tha của một bác sĩ đã từng chứng kiến nhiều cuộc sinh tử biệt ly và biết điều gì là đáng quý nhất trong đời.', N'http://192.168.1.4/newshopwebapi/Image/sach1.jpg', 20), 
			(1, N'Người Thăng Long', 100000, N'Người Thăng Long - Bản trường ca hào hùng về các vị vương, tướng nhà Trần trong cuộc chiến chống Nguyên Mông lần thứ hai.', N'http://192.168.1.4/newshopwebapi/Image/sach2.jpg', 5),
			(2, N'Chinh Phục 4 Kỹ Năng Tiếng Anh Nghe-Nói-Đọc-Viết', 100000, N'Chinh Phục 4 Kỹ Năng Tiếng Anh Nghe - Nói - Đọc - Viết Lớp 9 - Tập 1 - Sách tập trung vào việc rèn luyện các kỹ năng cơ bản như: Nghe, Nói, Đọc, Viết thông qua các bài tập và phát triển các kỹ năng giao tiếp tổng hợp về cách phát âm đúng; từ vựng phong phú, đọc các đoạn hội thoại, đoạn văn; viết câu hoặc đoạn văn theo mẫu, nói theo chủ đề từng bài học, nhằm giúp các em học sinh vận dụng và tổng hợp kiến thức hiệu quả nhất.', N'http://192.168.1.4/newshopwebapi/Image/sach3.jpg', 15), 
			(2, N'Chuyên Sâu Ngữ Pháp Và Từ Vựng Tiếng Anh Lớp 8', 150000, N'Luyện Chuyên Sâu Ngữ Pháp Và Từ Vựng Tiếng Anh Lớp 8 - Tập 1 - Cuốn sách các em đang cầm trên tay là cuốn sách không thể thiếu trong quá trình học tập tiếng Anh dành cho các em học sinh nhằm bổ trợ và nâng cao kiến thức trong chương trình Tiếng Anh hiện hành.', N'http://192.168.1.4/newshopwebapi/Image/sach4.jpg', 17),
			(2, N'Tự Học Tiếng Anh (Kèm CD)', 300000, N'Tự Học Tiếng Hoa Cấp Tốc (Kèm CD) - Cuốn sách với các tình huống đa dạng, cách trình bày bố cục rõ ràng cùng với cách phiên âm chuyển ngữ sang tiếng Việt', N'http://192.168.1.4/newshopwebapi/Image/sach5.jpg', 7),
			(3, N'Làm quen THỐNG KÊ HỌC qua biếm họa', 89000, N'Cuốn sách sẽ đem đến cho người đọc những kiến thức căn bản về thống kê từ việc lấy mẫu dữ liệu thô đến lập biểu đồ, từ kiểm định giả thiết đến đánh giá độ tin cậy. Nhưng may mắn thay, những khái niệm này không được trình bày giống như trong cuốn giáo trình làm chúng ta phát hoảng, mà dưới những ví dụ hấp dẫn về kích cỡ của các nàng tiên cá, tốc độ bay của lũ rồng, mức độ ghét nhau của hai tộc người ngoài hành tinh,… Tất cả sẽ làm chúng ta sảng khoái đến mức "phải lòng" thống kê học (trong một chừng mực nào đó)!
"Một nhà thống kê và một nghệ sĩ đã hợp sức để làm sáng tỏ những dữ liệu khó nhằn cho số đông. Thông qua những chuyện khôi hài về đua rồng, thu thập mẫu giun và uống soda vô độ, Klein và Dabney đã minh họa cách thức các nhà thống kê thu thập dư liệu như thế nào và đưa ra các dự đoán ra sao… Và vô cùng thú vị." - Scientific American.
"Ơn Chúa là cuối cùng cũng có ai đó viết một cuốn sách về thống kê thật sự vui nhộn đáng đọc. Cẩn thận khi mua cuốn sách này, bạn sẽ chẳng thể đặt được nó xuống trước khi đọc đến dòng cuối cùng." - Sebastian Thrun, Thành viên của Google  và CEO của Udacity.', N'http://192.168.1.4/newshopwebapi/Image/BanChay.jpg', 0),
			(4, N'Tiếng Anh Xã Giao (Tặng Kèm CD)', 150000, N'Tiếng Anh Xã Giao (Tặng Kèm CD) - Giúp bạn đọc tự học, tự rèn luyện để mạnh dạn giao tiếp trong mọi lĩnh vực, tình huống và ngữ cảnh khác nhau. Nội dung sách trình bày rõ ràng, thực tế. bao gồm những mẫu câu thường gặp nhất và các bài đàm thoại liên quan đến tình huống đó. Sách dùng trong: Sinh hoạt hàng ngày, khi đi du lịch, công tác nước ngoài.', N'http://192.168.1.4/newshopwebapi/Image/sach6.jpg', 22),
			insert into SACH values (8, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Bài Thi Khoa Học Xã Hội', 65000, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Bài Thi Khoa Học Xã Hội - Bộ sách đảm bảo yêu cầu cơ bản cho học sinh ôn luyện thi để xét công nhận tốt nghiệp THPT và cung cấp các kiến thức phân hóa cao để xét tuyển vào Đại học, Cao đẳng năm 2022.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-khxh.jpg', 20),
			(8, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Bài Thi Khoa Học Tự Nhiên', 65000, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Bài Thi Khoa Học Tự Nhiên - Bộ sách đảm bảo yêu cầu cơ bản cho học sinh ôn luyện thi để xét công nhận tốt nghiệp THPT và cung cấp các kiến thức phân hóa cao để xét tuyển vào Đại học, Cao đẳng năm 2022.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-khtn.jpg', 20),
			(8, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Môn Ngữ Văn', 45000, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Môn Ngữ Văn - Bộ sách đảm bảo yêu cầu cơ bản cho học sinh ôn luyện thi để xét công nhận tốt nghiệp THPT và cung cấp các kiến thức phân hóa cao để xét tuyển vào Đại học, Cao đẳng năm 2022.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-van2022.jpg', 20),
			(8, N'Luyện Đề Thi Tốt Nghiệp Thpt Năm 2022 - Môn Toán', 45000, N'Luyện Đề Thi Tốt Nghiệp Thpt Năm 2022 - Môn Toán - Bộ sách đảm bảo yêu cầu cơ bản cho học sinh ôn luyện thi để xét công nhận tốt nghiệp THPT và cung cấp các kiến thức phân hóa cao để xét tuyển vào Đại học, Cao đẳng năm 2022.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-toan2022.jpg', 20),
			(8, N'Luyện Đề Thi Tốt Nghiệp Thpt Năm 2022 - Môn Tiếng Anh', 45000, N'Luyện Đề Thi Tốt Nghiệp THPT Năm 2022 - Môn Tiếng Anh - Bộ sách đảm bảo yêu cầu cơ bản cho học sinh ôn luyện thi để xét công nhận tốt nghiệp THPT và cung cấp các kiến thức phân hóa cao để xét tuyển vào Đại học, Cao đẳng năm 2022.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-anh2022.jpg', 20),
			(8, N'Phương Pháp Trắc Nghiệm - 54 Bộ Đề Tiếng Anh Luyện Thi THPT Quốc Gia', 128000, N'Phương Pháp Trắc Nghiệm - 54 Bộ Đề Tiếng Anh Luyện Thi THPT Quốc Gia là cuốn sách được biên soạn dành cho các em học sinh lớp 12, là tài liệu bổ ích giúp các em chinh phục kì thi THPT Quốc gia.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-54bodeanh.jpg', 20),
			(8, N'Tài Liệu Ôn Thi THPT Quốc Gia Môn Tiếng Anh (Vĩnh Bá)', 140000, N'Sách Tài Liệu Ôn Thi Tốt Nghiệp THPT Quốc Gia Môn Tiếng Anh cung cấp một nguồn tài liệu bổ ích cho tất cả các bạn ôn thi THPT môn tiếng anh.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-tailieuonthithptanh.jpg', 20),
			(8, N'Câu Hỏi Và Bài Tập Trắc Nghiệm Lịch Sử Theo Chủ Đề 12', 95000, N'Cuốn sách Câu Hỏi Và Bài Tập Trắc Nghiệm Lịch Sử Theo Chủ Đề 12 giúp các em vận dụng kiến thức đã học và sự hiểu biết của mình để trả lời cầu hỏi trắc nghiệm theo từng bài cụ thể. Để chuẩn bị cho kỳ thi THPT Quốc Gia 2017.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-tnLS12.jpg', 20),
			(8, N'Ôn Tập Đánh Giá Năng Lực Môn Lịch Sử', 125000, N'Ôn Tập Đánh Giá Năng Lực Môn Lịch Sử - Đây là cuốn sách của các nhà khoa học giáo dục có nhiều năm kinh nghiệm trong nghiên cứu, giảng dạy ở đại học và bậc phổ thông. Tác giả cuốn sách và giáo vien đang tham gia bồi dưỡng kiến thức trên truyền hình.', N'http://192.168.1.4/newshopwebapi/Image/ltqg-ontapdgnlLS.jpg', 10)



--select * from SACH
go

-- Lấy thông tin tài khoản theo tên đăng nhâp
create procedure sp_LayDanhSachTaiKhoan
as begin
	select * from TAIKHOAN
end

go
-- Lấy thông tin tài khoản theo tên đăng nhâp
create procedure sp_LayThongTinTaiKhoan @TenDangNhap nvarchar(50)
as begin
	select * from TAIKHOAN where TenDangNhap = @TenDangNhap
end

go

-- Lấy danh sách loại sách
create procedure sp_LayDanhSachLoaiSach
as begin
	select * from LOAISACH
end

go
-- Lấy danh sách sách theo mã loại 
create procedure sp_LayDanhSachSachTheoLoaiSach @MaLoaiSach int
as begin
	if (@MaLoaiSach = 0)
	begin
		select MaSach, LOAISACH.TenLoaiSach, TenSach, Gia, MoTa, SACH.Hinh, SACH.GiamGia
		from SACH join LOAISACH on SACH.MaLoaiSach = LOAISACH.MaLoaiSach
	end
	else begin
		select MaSach, LOAISACH.TenLoaiSach, TenSach, Gia, MoTa, SACH.Hinh, SACH.GiamGia
		from SACH join LOAISACH on SACH.MaLoaiSach = LOAISACH.MaLoaiSach
		where LOAISACH.MaLoaiSach = @MaLoaiSach
	end
end
go

--exec sp_LayDanhSachSachTheoLoaiSach 3

-- Lấy danh sách sách theo mã khuyến mãi của sách
create procedure sp_LayDanhSachSachTheoKhuyenMai
as begin
	select top 5 *
	from SACH
	order by GiamGia Desc
end
go

-- Lấy hóa đơn theo tên đăng nhâp
create procedure sp_LayHoaDonTheoTenDangNhap @TenDangNhap varchar(50)
as begin
	select *
	from HOADON 
	where TenDangNhap = @TenDangNhap
end

go
-- Lấy CTHD theo mã hóa đơn
create procedure sp_LayCTHDTheoMaHoaDon @MaHoaDon int
as begin
	select MaHoaDon, SACH.TenSach, SoLuong, SACH.Gia, SACH.GiamGia, ThanhTien, SACH.Hinh
	from CT_HOADON join SACH on CT_HOADON.MaSach = SACH.MaSach
	where MaHoaDon = @MaHoaDon
end

go
--Thêm tài khoản
create procedure sp_ThemTaiKhoan @TenDangNhap varchar(50), @MatKhau varchar(50), @TenKhachHang nvarchar(50), @SoDienThoai varchar(10), @Email varchar(50), @NgaySinh datetime, @GioiTinh bit
as begin
	insert into TAIKHOAN values(@TenDangNhap, @MatKhau, @TenKhachHang, @SoDienThoai, @Email, @NgaySinh, @GioiTinh)
	insert into GIOHANG(TenDangNhap) values(@TenDangNhap) -- Tạo giỏ hàng cho tải khoản
end

--exec sp_ThemTaiKhoan 'tinh', '1', 'Bùi Văn Tình', '123456789', 'tinhbui@gmail.com', '07/02/2001', '1'
--delete from TAIKHOAN
--select * from TAIKHOAN
--select * from GIOHANG

go
-- Khi đặt hàng sẽ gọi
create procedure sp_ThemHoaDon @TenDangNhap varchar(50), @NgayHoaDon datetime, @MaDiaChi int
as begin
	-- Tạo hóa đơn
	declare @TongTien money, @MaHoaDon int, @Gia money, @PhiVanChuyen money
	select top 1 @Gia = Gia from GIAOHANG
	select @TongTien = TongTien + @Gia from GIOHANG where TenDangNhap = @TenDangNhap
	select @PhiVanChuyen = Gia from GIAOHANG
	set @MaHoaDon = 1
	while @MaHoaDon in (select MaHoaDon from HOADON)
		set @MaHoaDon = @MaHoaDon + 1
	insert into HOADON values (@MaHoaDon, @TenDangNhap, @NgayHoaDon, @TongTien, N'Giao hàng tiêu chuẩn', N'Thanh toán khi nhận hàng', @MaDiaChi, 0, @PhiVanChuyen)
	
	-- Tạo chi tiết hóa đơn
	declare @MaGioHang int , @MaSach int, @SoLuong int, @ThanhTien money
	select @MaGioHang = MaGioHang from GIOHANG where TenDangNhap = @TenDangNhap

	declare CUR_GIOHANG cursor for select MaSach, SoLuong, ThanhTien from CT_GIOHANG where MaGioHang = @MaGioHang
	open CUR_GIOHANG
	FETCH NEXT FROM CUR_GIOHANG INTO @MaSach, @SoLuong, @ThanhTien
	WHILE @@FETCH_STATUS = 0
	BEGIN
		insert into CT_HOADON values (@MaHoaDon, @MaSach, @SoLuong, @ThanhTien)
		FETCH NEXT FROM CUR_GIOHANG INTO @MaSach, @SoLuong, @ThanhTien
	END
	CLOSE CUR_GIOHANG
	DEALLOCATE CUR_GIOHANG

	-- Xóa CT_GioHang
	delete from CT_GIOHANG where MaGioHang = @MaGioHang
	update GIOHANG set DaDungMaGiamGia = 0 where MaGioHang = @MaGioHang
end


--Cập nhật tình trạng hóa đơn
go
create procedure sp_CapNhapTinhTrangHoaDon @MaHoaDon int
as begin
	update HOADON 
	set TinhTrang = 1
	where MaHoaDon = @MaHoaDon
end

go
--Lấy thông tin tất cả hóa đơn
create proc sp_LayTatCaHoaDon
as begin
	select COUNT(*) as SoCTHD, HOADON.MaHoaDon, TinhTrang into Temp
	from HOADON, CT_HOADON
	where HOADON.MaHoaDon = CT_HOADON.MaHoaDon
	group by HOADON.MaHoaDon, TinhTrang 

	select  SoCTHD,  Temp.MaHoaDon, TenSach, TinhTrang  from Temp, CT_HOADON, SACH where Temp.MaHoaDon = CT_HOADON.MaHoaDon and CT_HOADON.MaSach = SACH.MaSach

	drop table Temp
end

go
--Lấy CT_HOADON theo MaHoaDon
create proc sp_LayChiTietHoaDon  @MaHoaDon int
as begin
	select HOADON.MaHoaDon, TinhTrang, TenNguoiNhan, SDT, DiaChi, NgayHoaDon, HinhThucGiao, HinhThucThanhToan, Hinh, TenSach, Gia, SoLuong, ThanhTien, PhiVanChuyen, TongTien   from CT_HOADON, HOADON, DIACHI, SACH where SACH.MaSach = CT_HOADON.MaSach and DIACHI.MaDiaChi = HOADON.MaDiaChi and HOADON.MaHoaDon = CT_HOADON.MaHoaDon and HOADON.MaHoaDon = @MaHoaDon
end

go
--Lấy thông tin hóa đơn theo TenDangNhap
create proc sp_LayThongTinHoaDon @TenDangNhap varchar(50)
as begin
	select COUNT(*) as SoCTHD, HOADON.MaHoaDon, TinhTrang into Temp
	from HOADON, CT_HOADON
	where HOADON.MaHoaDon = CT_HOADON.MaHoaDon and TenDangNhap = @TenDangNhap
	group by HOADON.MaHoaDon, TinhTrang 

	select  SoCTHD,  Temp.MaHoaDon, TenSach, TinhTrang  from Temp, CT_HOADON, SACH where Temp.MaHoaDon = CT_HOADON.MaHoaDon and CT_HOADON.MaSach = SACH.MaSach

	drop table Temp
end

--Xóa chi tiết hóa đơn
go
create procedure sp_XoaChiTietHoaDon @MaHoaDon int
as begin
	delete from CT_HOADON where MaHoaDon = @MaHoaDon
	delete from HOADON where MaHoaDon = @MaHoaDon
end

--create trigger trigger_insert_cthoadon on CT_HOADON
--for insert as begin
--	declare @MaHoaDon int, @MaSach int, @SoLuong int, @Gia money, @TongTienCu money
--	select @MaHoaDon = MaHoaDon, @MaSach = MaSach, @SoLuong = SoLuong from inserted
--	select @TongTienCu = TongTien from HOADON where MaHoaDon = @MaHoaDon
--	select @Gia = Gia from SACH where MaSach = @MaSach
--	update HOADON 
--	set TongTien = @TongTienCu + (@SoLuong * @Gia)
--	where MaHoaDon = @MaHoaDon
--end


--create trigger trigger_delete_cthoadon on CT_HOADON
--for delete
--as begin
--	declare @MaHoaDon int, @ThanhTien money, @TongTienCu money
--	select @MaHoaDon = MaHoaDon, @ThanhTien = ThanhTien from deleted
--	select @TongTienCu = TongTien from HOADON where MaHoaDon = @MaHoaDon
--	update HOADON 
--	set TongTien = @TongTienCu - @ThanhTien
--	where MaHoaDon = @MaHoaDon
--	if not exists (select * from CT_HOADON where MaHoaDon = @MaHoaDon)
--	begin
--		delete from HOADON where MaHoaDon = @MaHoaDon
--	end
--end

go
-- Tính thành tiền khi update số lượng

go
-- Tính tổng tiền khi thêm sách vào giỏ hàng
create trigger trigger_insert_CTGIOHANG on CT_GIOHANG
for insert
as begin
	declare @TongTien money, @MaGioHang int, @ThanhTien money
	select @MaGioHang = MaGioHang, @ThanhTien = ThanhTien from inserted
	update GIOHANG set TongTien = TongTien + @ThanhTien, DaDungMaGiamGia = 0 where MaGioHang = @MaGioHang
end
go
-- Tính tổng tiền khi sửa giỏ hàng
create trigger trigger_update_CTGIOHANG on CT_GIOHANG
for update
as begin
	declare @TongTien money, @MaGioHang int, @ThanhTien money, @SoLuong int, @Gia money, @GiamGiaSach int, @MaSach int
	select @SoLuong = SoLuong, @MaSach = MaSach from inserted
	select @Gia = Gia from SACH where MaSach = @MaSach
	select @GiamGiaSach = GiamGia from SACH where MaSach = @MaSach
	select @MaGioHang = MaGioHang From deleted

	update CT_GIOHANG set ThanhTien = @SoLuong*(@Gia - @Gia*@GiamGiaSach/100) where MaSach = @MaSach and MaGioHang = @MaGioHang

	set @TongTien = 0

	declare CUR_GIOHANG cursor for select ThanhTien from CT_GIOHANG where MaGioHang = @MaGioHang
	open CUR_GIOHANG
	FETCH NEXT FROM CUR_GIOHANG INTO @ThanhTien
	WHILE @@FETCH_STATUS = 0
	BEGIN
		Set @TongTien = @TongTien + @ThanhTien
		FETCH NEXT FROM CUR_GIOHANG INTO @ThanhTien
	END
	CLOSE CUR_GIOHANG
	DEALLOCATE CUR_GIOHANG

	update GIOHANG set TongTien = @TongTien,  DaDungMaGiamGia = 0 where MaGioHang = @MaGioHang
end
go
-- Tính tổng tiền khi xóa giỏ hàng
create trigger trigger_delete_CTGIOHANG on CT_GIOHANG
for delete
as begin
	declare @TongTien money, @MaGioHang int, @ThanhTien money, @SoLuong int, @Gia money, @MaSach int
	select @MaGioHang = MaGioHang From deleted

	set @TongTien = 0

	declare CUR_GIOHANG cursor for select ThanhTien from CT_GIOHANG where MaGioHang = @MaGioHang
	open CUR_GIOHANG
	FETCH NEXT FROM CUR_GIOHANG INTO @ThanhTien
	WHILE @@FETCH_STATUS = 0
	BEGIN
		Set @TongTien = @TongTien + @ThanhTien
		FETCH NEXT FROM CUR_GIOHANG INTO @ThanhTien
	END
	CLOSE CUR_GIOHANG
	DEALLOCATE CUR_GIOHANG

	update GIOHANG set TongTien = @TongTien, DaDungMaGiamGia = 0  where MaGioHang = @MaGioHang
end

go
-- Thêm sách vào giỏ hàng 
create procedure sp_ThemSachVaoGioHang @TenDangNhap varchar(50), @MaSach int
as begin
	declare @MaGioHang int, @ThanhTien money, @Gia money, @GiamGiaSach int
	select @Gia = Gia from SACH where MaSach = @MaSach
	select @GiamGiaSach = GiamGia from SACH where MaSach = @MaSach
	set @ThanhTien = @Gia - @Gia*@GiamGiaSach/100;
	select @MaGioHang = MaGioHang from GIOHANG where TenDangNhap = @TenDangNhap
	insert into CT_GIOHANG(MaGioHang, MaSach, ThanhTien) values (@MaGioHang, @MaSach, @ThanhTien);
end
--exec sp_ThemSachVaoGioHang 'tinh', 1

--select * from SACH
--select * from CT_GIOHANG
--select * from GIOHANG
--delete CT_GIOHANG where MaGioHang = 1
--update CT_GIOHANG set SoLuong = 3

go
-- Giảm số lượng
create procedure sp_GiamSoLuong @MaGioHang int, @MaSach int
as begin
	declare @SoLuongHienTai int
	select @SoLuongHienTai = SoLuong from CT_GIOHANG where MaGioHang = @MaGioHang and MaSach = @MaSach
	set @SoLuongHienTai = @SoLuongHienTai - 1

	if(@SoLuongHienTai = 0)
	begin 
		Delete from CT_GIOHANG where MaGioHang = @MaGioHang and MaSach = @MaSach
	end
	else begin
		declare @ThanhTien money, @Gia money, @GiamGiaSach int
		select @Gia = Gia from SACH where MaSach = @MaSach
		select @GiamGiaSach = GiamGia from SACH where MaSach = @MaSach
		set @ThanhTien = (@Gia - @Gia*@GiamGiaSach/100)*@SoLuongHienTai
		Update CT_GIOHANG set SoLuong = @SoLuongHienTai, ThanhTien = @ThanhTien where MaSach = @MaSach and MaGioHang = @MaGioHang
	end
end
go
-- Tăng số lượng
create procedure sp_TangSoLuong @MaGioHang nvarchar(50), @MaSach int
as begin
	declare @SoLuongHienTai int
	select @SoLuongHienTai = SoLuong from CT_GIOHANG where MaGioHang = @MaGioHang and MaSach = @MaSach
	
	set @SoLuongHienTai = @SoLuongHienTai + 1

		declare @ThanhTien money, @Gia money, @GiamGiaSach int
		select @Gia = Gia from SACH where MaSach = @MaSach
		select @GiamGiaSach = GiamGia from SACH where MaSach = @MaSach
		set @ThanhTien = (@Gia - @Gia*@GiamGiaSach/100)*@SoLuongHienTai
		Update CT_GIOHANG set SoLuong = @SoLuongHienTai, ThanhTien = @ThanhTien where MaSach = @MaSach and MaGioHang = @MaGioHang

end

--exec sp_ThayDoiSoLuong 1, 2, 3
--select * from CT_GIOHANG
--select * from GIOHANG

go
-- Xóa tất cả CT_GIOHANG khi đã đặt hàng
create proc sp_XoaGioHang @MaGioHang int 
as begin
	delete from CT_GIOHANG where MaGioHang = @MaGioHang
end


go
-- Lấy thông tin giỏ hàng theo tên đăng nhập
create procedure sp_LayThongTinGioHang @TenDangNhap varchar(50)
as begin

	select TenSach, ThanhTien, SoLuong, Hinh, TongTien, GIOHANG.MaGioHang, CT_GIOHANG.MaSach
	from GIOHANG, SACH, CT_GIOHANG
	where CT_GIOHANG.MaSach = SACH.MaSach and CT_GIOHANG.MaGioHang = GIOHANG.MaGioHang and TenDangNhap = @TenDangNhap

end

--exec sp_LayThongTinGioHang tinh

go
-- Thêm mã giảm giá
create procedure sp_ThemMaGiamGia @MaGiamGia varchar(5), @TiLeGiam int
as begin
	if not exists (select * from MAGIAMGIA where  MaGiamGia = @MaGiamGia)
	begin
		if @TiLeGiam > 0 and @TiLeGiam < 100
		begin 
			insert into MAGIAMGIA values (@MaGiamGia, @TiLeGiam)
		end
	end
end

--exec sp_ThemMaGiamGia 12348, 10
--select * from MAGIAMGIA


go
-- Sửa mã giảm giá
create procedure sp_SuaMaGiamGia @MaGiamGia varchar(5), @TiLeGiam int
as begin
	if @TiLeGiam > 0 and @TiLeGiam < 100
	begin 
		update MAGIAMGIA set TiLeGiam = @TiLeGiam where MaGiamGia = @MaGiamGia
	end
end

--exec sp_SuaMaGiamGia 12345, 50

go
-- Xóa mã giảm giá
create procedure sp_XoaMaGiamGia @MaGiamGia varchar(5)
as begin
	Delete from MAGIAMGIA where MaGiamGia = @MaGiamGia
end

go
-- Lây danh sách mã giảm giá
create procedure sp_LayDanhSachMaGiamGia 
as begin
	select * from MAGIAMGIA
end

go
-- Lấy mã giảm giá
create procedure sp_LayMaGiamGia @MaGiamGia varchar(5)
as begin
	Select * from MAGIAMGIA where MaGiamGia = @MaGiamGia
end

go
-- Áp dụng mã giảm giá 
create proc sp_ApDungMa @MaGiamGia varchar(5), @MaGioHang int
as begin
	if exists (select * from MAGIAMGIA where MaGiamGia = @MaGiamGia)
	begin

		declare @TiLeGiam int, @DaDungMaGiamGia bit
		select @DaDungMaGiamGia = DaDungMaGiamGia from GIOHANG where MaGioHang = @MaGioHang
		if (@DaDungMaGiamGia = 0)
		begin 
			select @TiLeGiam = TiLeGiam from MAGIAMGIA where MaGiamGia = @MaGiamGia
			update GIOHANG set TongTien = TongTien - TongTien*@TiLeGiam/100, DaDungMaGiamGia = 1 where MaGioHang = @MaGioHang
		end
	end
end

--exec sp_ApDungMa 12345, 1
--Select * from MAGIAMGIA
--select * from GIOHANG
--select * from CT_GIOHANG
--delete from CT_GIOHANG
go
-- Thêm địa chỉ
create proc sp_ThemDiaChi @TenNguoiNhan nvarchar(50), @SDT varchar(10), @DiaChi nvarchar(100), @TenDangNhap varchar(50)
as begin
	declare @MacDinh bit
	set @MacDinh = 0
	if not exists(select * from DIACHI where TenDangNhap = @TenDangNhap)
	begin
		set @MacDinh = 1;
	end
	insert into DIACHI (TenNguoiNhan, SDT, DiaChi, TenDangNhap, MacDinh) values (@TenNguoiNhan, @SDT, @DiaChi, @TenDangNhap, @MacDinh)
end

--exec sp_ThemDiaChi 'Bùi Văn Tình', 123456789, 'Hòa Đại - Cát Hiệp - Phù Cát - Bình Định', tinh

--Thay đổi địa chỉ mặc định
create proc sp_ThayDoiDiaChiMacDinh @MaDiaChi int, @TenDangNhap varchar(50)
as begin
	update DIACHI set MacDinh = 0 where TenDangNhap = @TenDangNhap
	update DIACHI set MacDinh = 1 where TenDangNhap = @TenDangNhap and MaDiaChi = @MaDiaChi
end

go
-- Lấy địa chỉ theo tên đăng nhập
create proc sp_LayDiaChi @TenDangNhap varchar(50)
as begin
	select * from DIACHI where TenDangNhap = @TenDangNhap
end

--exec sp_LayDiaChi tinh
go
create trigger trigger_update_DIACHI on DIACHI
for delete
as begin
	declare @MaDiaChi int, @TenDangNhap varchar(50), @MacDinh bit
	select @MaDiaChi = MaDiaChi, @TenDangNhap = TenDangNhap, @MacDinh = MacDinh from deleted

	if(@MacDinh = 1)
	begin
		declare @MDC int
		select top 1 @MDC = MaDiaChi from DIACHI where TenDangNhap = @TenDangNhap
		update DIACHI set MacDinh = 1 where MaDiaChi = @MDC
	end

	if exists (select MaDiaChi from HOADON where MaDiaChi = @MaDiaChi)
	begin
		print N'Địa chỉ đang tồn tại trong hóa đơn, không thể xóa'
		ROLLBACK TRAN
	end
end

go
-- Xóa địa chỉ
create proc sp_SuaDiaChi @MaDiaChi int
as begin
	delete from DIACHI where MaDiaChi = @MaDiaChi
end

-- Lấy giá tiền giao hàng
create proc sp_LayGiaGiaoHang
as begin
	select * from GIAOHANG
end

go
-- Sửa giá tiền giao hàng
create proc sp_SuaGiaGiaoHang @Gia money
as begin
	update GIAOHANG set Gia = @Gia;
end

--Thêm sách
create PROC sp_ThemSach (@MaLoaiSach int,
	@TenSach nvarchar (100),
	@Gia money,
	@MoTa nvarchar(max),
	@Hinh nvarchar(200), @GiamGia int, @CurrentID int output)
as
begin try

if(exists(select * from SACH where TenSach=@TenSach and MaLoaiSach=@MaLoaiSach))
begin
set @CurrentID=0
return
end
insert into SACH values(@MaLoaiSach,@TenSach,@Gia,@MoTa,@Hinh,@GiamGia);
set @CurrentID=@@IDENTITY
end try
begin catch
set @CurrentID=0
end catch
go

--Cap nhat sach
create PROC sp_CapNhatSach (@MaSach int ,@MaLoaiSach int,
	@TenSach nvarchar (100),
	@Gia money,
	@MoTa nvarchar(max),
	@Hinh nvarchar(200), @GiamGia int, @CurrentID int output)
as
begin try
if(not exists(select * from SACH where MaSach=@MaSach and MaLoaiSach=@MaLoaiSach))
begin
set @CurrentID=0
return
end
Update  SACH  set MaLoaiSach=@MaLoaiSach,TenSach=@TenSach,Gia=@Gia,MoTa=@MoTa,Hinh=@Hinh,GiamGia=@GiamGia where MaSach=@MaSach;
set @CurrentID=1
end try
begin catch
set @CurrentID=0
end catch
go

--Xoa sach
create PROC sp_XoaSach @MaSach int,@CurrentID int output
as
begin try
if(not exists(select * from SACH where MaSach=@MaSach))
begin
set @CurrentID=0
return
end
Delete From SACH where MaSach=@MaSach;
set @CurrentID=1
end try
begin catch
set @CurrentID=0
end catch
go

--Xoa loai sach
create PROC sp_XoaLoaiSach @MaLoaiSach int, @CurrentID int output
as
begin try
if(not exists(select * from LOAISACH where MaLoaiSach=@MaLoaiSach) or (select COUNT(*) from SACH where MaLoaiSach=@MaLoaiSach)>0)
begin
set @CurrentID=0
return
end
Delete From LOAISACH where MaLoaiSach=@MaLoaiSach;
set @CurrentID=1
end try
begin catch
set @CurrentID=0
end catch
go

--Them loai sach
create PROC sp_ThemLoaiSach(@TenLoaiSach nvarchar(50), @Hinh nvarchar(200), @CurrentID int output)
as
begin try

if(exists(select * from LOAISACH where TenLoaiSach=@TenLoaiSach))
begin
set @CurrentID=0
return
end
insert into LOAISACH values (@TenLoaiSach, @Hinh);
set @CurrentID=@@IDENTITY
end try
begin catch
set @CurrentID=0
end catch
go

--Sua loai sach
create PROC sp_CapNhatLoaiSach(@MaLoaiSach int, @TenLoaiSach nvarchar(50), @Hinh nvarchar(200), @CurrentID int output)
as
begin try
if(not exists(select * from LOAISACH where MaLoaiSach=@MaLoaiSach))
begin
set @CurrentID=0
return
end
Update LOAISACH Set  TenLoaiSach=@TenLoaiSach,Hinh= @Hinh where MaLoaiSach=@MaLoaiSach;
set @CurrentID=1
end try
begin catch
set @CurrentID=0
end catch


go
create proc sp_CheckDiaChi @MaDiaChi int
as begin
	select DIACHI.MaDiaChi from DIACHI, HOADON where DIACHI.MaDiaChi = HoaDon.MaDiaChi and DIACHI.MaDiaChi = @MaDiaChi
end

go
--Lấy thông tin hóa đơn theo MaHoaDon
create proc sp_LayThongTinHoaDonTheoMa @MaHoaDon int
as begin
	select COUNT(*) as SoCTHD, HOADON.MaHoaDon, TinhTrang into Temp
	from HOADON, CT_HOADON
	where HOADON.MaHoaDon = CT_HOADON.MaHoaDon and HOADON.MaHoaDon = @MaHoaDon
	group by HOADON.MaHoaDon, TinhTrang 

	select  SoCTHD,  Temp.MaHoaDon, TenSach, TinhTrang  from Temp, CT_HOADON, SACH where Temp.MaHoaDon = CT_HOADON.MaHoaDon and CT_HOADON.MaSach = SACH.MaSach

	drop table Temp
end