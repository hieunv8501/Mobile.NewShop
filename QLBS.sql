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

CREATE TABLE LOAISACH
(
	MaLoaiSach int identity(1,1) primary key,
	TenLoaiSach nvarchar(50),
	Hinh nvarchar(200),
)
create table SACH
(
	MaSach int identity(1,1) primary key,
	MaLoaiSach int,
	TenSach nvarchar(50),
	Gia money,
	MoTa nvarchar(2000),
	Hinh nvarchar(200),
)

create table DIACHI
(
	MaDiaChi int IDENTITY(1,1) primary key,
	TenNguoiNhan nvarchar(50),
	SDT varchar(10),
	DiaChi nvarchar(100),
	TenDangNhap varchar(50),
)

create table HOADON 
(
	MaHoaDon int primary key,
	TenDangNhap varchar(50),
	NgayHoaDon datetime,
	TongTien money,
	HinhThucGiao nvarchar(50),--Set cứng giao hàng tiêu chuẩn (15k)
	HinhThucThanhToan nvarchar(50),--Set cứng tiền mặt
	MaDiaChi int,
	TinhTrang bit,
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

create table HOADON add constraint fk_HOADON_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
create table CT_HOADON add constraint fk_CTHOADON_HOADON foreign key (MaHoaDon) references HOADON(MaHoaDon)
create table CT_HOADON add constraint fk_CTHOADON_SACH foreign key (MaSach) references SACH(MaSach)
create table SACH add constraint fk_SACH_LOAISACH foreign key (MaLoaiSach) references LOAISACH(MaLoaiSach)
create table DIACHI add constraint fk_DIACHI_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
create table HOADON add constraint fk_HOADON_DIACHI foreign key (MaDiaChi) references DIACHI(MaDiaChi)
create table GIOHANG add constraint fk_GIOHANG_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
create table CT_GIOHANG add constraint fk_CTGIOHANG_SACH foreign key (MaSach) references SACH(MaSach)
create table CT_GIOHANG add constraint fk_CTGIOHANG_GIOHANG foreign key (MaGioHang) references GIOHANG(MaGioHang)

set dateformat dmy;

insert into TAIKHOAN values ('hieu', '1' , N'Hiếu', '0123456789', 'hieu@gmail.com', 01/01/2001, 1), ('hau', '1', N'Hậu', '0987654321', 'hau@gmail.com', 01/01/2001, 1), ('tinh', '1', N'Tình', '0984221251', 'tinh@gmail.com', 01/01/2001, 1)
insert into LOAISACH values (N'Sách Bán Chạy', N'http://172.20.10.4/newshopwebapi/Image/BanChay.jpg'), 
			( N'Sách Quản Lý - Kinh Doanh', N'http://172.20.10.4/newshopwebapi/Image/NgoaiNgu.jpg'), 
			( N'Sách Ngoại Ngữ', N'http://172.20.10.4/newshopwebapi/Image/NgoaiNgu.jpg'),( N'Sách Thiếu Nhi', N'http://172.20.10.4/newshopwebapi/Image/ThieuNhi.jpg'),( N'Sách Kỹ Năng Sống', N'http://172.20.10.4/newshopwebapi/Image/YChi.jpg')
insert into SACH values (1, 1, N'Làm quen THỐNG KÊ HỌC qua biếm họa', 89000, N'Cuốn sách sẽ đem đến cho người đọc những kiến thức căn bản về thống kê từ việc lấy mẫu dữ liệu thô đến lập biểu đồ, từ kiểm định giả thiết đến đánh giá độ tin cậy. Nhưng may mắn thay, những khái niệm này không được trình bày giống như trong cuốn giáo trình làm chúng ta phát hoảng, mà dưới những ví dụ hấp dẫn về kích cỡ của các nàng tiên cá, tốc độ bay của lũ rồng, mức độ ghét nhau của hai tộc người ngoài hành tinh,… Tất cả sẽ làm chúng ta sảng khoái đến mức "phải lòng" thống kê học (trong một chừng mực nào đó)!

"Một nhà thống kê và một nghệ sĩ đã hợp sức để làm sáng tỏ những dữ liệu khó nhằn cho số đông. Thông qua những chuyện khôi hài về đua rồng, thu thập mẫu giun và uống soda vô độ, Klein và Dabney đã minh họa cách thức các nhà thống kê thu thập dư liệu như thế nào và đưa ra các dự đoán ra sao… Và vô cùng thú vị." - Scientific American.

"Ơn Chúa là cuối cùng cũng có ai đó viết một cuốn sách về thống kê thật sự vui nhộn đáng đọc. Cẩn thận khi mua cuốn sách này, bạn sẽ chẳng thể đặt được nó xuống trước khi đọc đến dòng cuối cùng." - Sebastian Thrun, Thành viên của Google  và CEO của Udacity.', N'http://172.20.10.4/newshopwebapi/Image/BanChay.jpg'), 
			(2, 1, 'TenSach2', 1000, N'Mô tả TenSach2', 'sach2.jpg'),
			(3, 2, 'TenSach3', 100, N'Mô tả TenSach3', 'sach3.jpg'), 
			(4, 2, 'TenSach4', 1500, N'Mô tả TenSach4', 'sach4.jpg'),
			(5, 2, 'TenSach5', 3000, N'Mô tả TenSach5', 'sach5.jpg'),
			(6, 3, 'TenSach6', 1500, N'Mô tả TenSach6', 'sach6.jpg')

go
-- Lấy danh sách tài khoản
create procedure sp_LayDanhSachTaiKhoan
as begin
	select * from TAIKHOAN
end

exec sp_LayDanhSachTaiKhoan
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
		select MaSach, LOAISACH.TenLoaiSach, TenSach, Gia, MoTa, SACH.Hinh
		from SACH join LOAISACH on SACH.MaLoaiSach = LOAISACH.MaLoaiSach
	end
	else begin
		select MaSach, LOAISACH.TenLoaiSach, TenSach, Gia, MoTa, SACH.Hinh
		from SACH join LOAISACH on SACH.MaLoaiSach = LOAISACH.MaLoaiSach
		where LOAISACH.MaLoaiSach = @MaLoaiSach
	end
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
	select MaHoaDon, SACH.TenSach, SoLuong, SACH.Gia, ThanhTien, SACH.Hinh
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
	declare @TongTien money, @MaHoaDon int
	select @TongTien = TongTien from GIOHANG where TenDangNhap = @TenDangNhap
	set @MaHoaDon = 1
	while @MaHoaDon in (select MaHoaDon from HOADON)
		set @MaHoaDon = @MaHoaDon + 1
	insert into HOADON values (@MaHoaDon, @TenDangNhap, @NgayHoaDon, @TongTien + 15000, 'Giao hàng tiêu chuẩn', 'Thanh toán khi nhận hàng', @MaDiaChi, 0)
	
	-- Tạo chi tiết hóa đơn
	declare @MaGioHang int , @MaSach int, @SoLuong int, @ThanhTien money
	select @MaGioHang = MaGioHang from GIOHANG where TenDangNhap = @TenDangNhap

	declare CUR_GIOHANG cursor for select MaSach, SoLuong, ThanhTien from CT_GIOHANG where MaGioHang = @MaGioHang
	open CUR_GIOHANG
	FETCH NEXT FROM CUR_GIOHANG INTO @MaSach, @SoLuong, @SoLuong
	WHILE @@FETCH_STATUS = 0
	BEGIN
		insert into CT_HOADON values (@MaHoaDon, @MaSach, @SoLuong, @SoLuong)
		FETCH NEXT FROM CUR_GIOHANG INTO @MaSach, @SoLuong, @SoLuong
	END
	CLOSE CUR_GIOHANG
	DEALLOCATE CUR_GIOHANG

	-- Xóa CT_GioHang
	delete from CT_GIOHANG where MaGioHang = @MaGioHang
end

--exec sp_ThemHoaDon tinh, '17-12-2021', 1
--select * from HOADON
--select * from CT_HOADON
--select * from GIOHANG
--select * from CT_GIOHANG
--create procedure sp_ThemChiTietHoaDon @MaSach int, @TenDangNhap varchar(50), @NgayHoaDon datetime
--as begin
--	declare @MaHoaDon int, @Gia money
--	select @Gia = Gia from SACH where MaSach = @MaSach
--	if not exists (select * from HOADON where TinhTrang = 0 and TenDangNhap = @TenDangNhap)
--	begin
--		exec sp_ThemHoaDon @TenDangNhap, @NgayHoaDon
--		select @MaHoaDon = MaHoaDon from HOADON where TinhTrang = 0
--		insert into CT_HOADON values (@MaHoaDon, @MaSach, 1, @Gia )
--	end
--	else begin
--		select top 1 @MaHoaDon = MaHoaDon from HOADON where TinhTrang = 0 and TenDangNhap = @TenDangNhap
--		if exists (select * from CT_HOADON where MaSach = @MaSach and MaHoaDon = @MaHoaDon)
--		begin
--			declare @SoLuongCu int
--			select @SoLuongCu = SoLuong from CT_HOADON where MaSach = @MaSach and MaHoaDon = @MaHoaDon
--			update CT_HOADON
--			set SoLuong = @SoLuongCu + 1
--			where MaSach = @MaSach and MaHoaDon = @MaHoaDon	
--			update CT_HOADON
--			set ThanhTien = SoLuong * @Gia
--			where MaSach = @MaSach and MaHoaDon = @MaHoaDon
--			update HOADON
--			set TongTien = (select sum(ThanhTien) from CT_HOADON where MaHoaDon = @MaHoaDon)
--			where MaHoaDon = @MaHoaDon
--		end
--		else begin
--			insert into CT_HOADON values (@MaHoaDon, @MaSach, 1, @Gia)
--		end
--	end
--end

--Cập nhật tình trạng hóa đơn
go
create procedure sp_CapNhapTinhTrangHoaDon @MaHoaDon int
as begin
	update HOADON 
	set TinhTrang = 1
	where MaHoaDon = @MaHoaDon
end

--Xóa chi tiết hóa đơn
go
create procedure sp_XoaChiTietHoaDon @MaHoaDon int, @MaSach int
as begin
	delete from CT_HOADON where MaHoaDon = @MaHoaDon and MaSach = @MaSach
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
	update  GIOHANG set TongTien = TongTien + @ThanhTien where MaGioHang = @MaGioHang
end
go
-- Tính tổng tiền khi sửa/xóa giỏ hàng
create trigger trigger_update_CTGIOHANG on CT_GIOHANG
for update, delete
as begin
	declare @TongTien money, @MaGioHang int, @ThanhTien money, @SoLuong int, @Gia money, @MaSach int
	select @SoLuong = SoLuong, @MaSach = MaSach from inserted
	select @Gia = Gia from SACH where MaSach = @MaSach
	select @MaGioHang = MaGioHang From deleted

	update CT_GIOHANG set ThanhTien = @SoLuong*@Gia

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

	update GIOHANG set TongTien = @TongTien where MaGioHang = @MaGioHang
end

go
-- Thêm sách vào giỏ hàng 
create procedure sp_ThemSachVaoGioHang @TenDangNhap varchar(50), @MaSach int
as begin
	declare @MaGioHang int, @ThanhTien money
	select @ThanhTien = Gia from SACH where MaSach = @MaSach
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
-- Thay đổi số lượng + xóa khỏi giỏ hàng
create procedure sp_ThayDoiSoLuong @MaGioHang int, @MaSach int , @SoLuong int
as begin
	if(@SoLuong = 0)
	begin 
		Delete from CT_GIOHANG where MaGioHang = @MaGioHang and MaSach = @MaSach
	end
	else begin
		declare @ThanhTien money, @Gia money
		select @Gia = Gia from SACH where MaSach = @MaSach
		set @ThanhTien = @Gia*@SoLuong
		Update CT_GIOHANG set SoLuong = @SoLuong, ThanhTien = @ThanhTien where MaSach = @MaSach
	end
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
create procedure sp_LayThongTinGioHang @TenDangNhap nvarchar(50)
as begin
	select TenSach, ThanhTien, SoLuong, Hinh, TongTien
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
	insert into DIACHI (TenNguoiNhan, SDT, DiaChi, TenDangNhap) values (@TenNguoiNhan, @SDT, @DiaChi, @TenDangNhap)
end

--exec sp_ThemDiaChi 'Bùi Văn Tình', 123456789, 'Hòa Đại - Cát Hiệp - Phù Cát - Bình Định', tinh

go
-- Lay địa chỉ theo tên đăng nhập
create proc sp_LayDiaChi @TenDangNhap varchar(50)
as begin
	select * from DIACHI where TenDangNhap = @TenDangNhap
end

--exec sp_LayDiaChi tinh
go
create trigger trigger_update_DIACHI on DIACHI
for update, delete
as begin
	declare @MaDiaChi int
	select @MaDiaChi = MaDiaChi from deleted

	if exists (select MaDiaChi from HOADON where MaDiaChi = @MaDiaChi)
	begin
		ROLLBACK TRAN
	end
end

go
-- Xóa địa chỉ
create proc sp_SuaDiaChi @MaDiaChi int
as begin
	delete from DIACHI where MaDiaChi = @MaDiaChi
end

--Them sach
create PROC  sp_ThemSach (@MaLoaiSach int,
	@TenSach nvarchar (50),
	@Gia money,
	@MoTa nvarchar(2000),
	@Hinh nvarchar (200),@CurrentID int output)
as
begin try

if(exists(select * from SACH where TenSach=@TenSach and MaLoaiSach=@MaLoaiSach))
begin
set @CurrentID=0
return
end
insert into SACH values(@MaLoaiSach,@TenSach,@Gia,@MoTa,@Hinh);
set @CurrentID=@@IDENTITY
end try
begin catch
set @CurrentID=0
end catch


--Cap nhat sach
create PROC sp_CapNhatSach (@MaSach int ,@MaLoaiSach int,
	@TenSach nvarchar (50),
	@Gia money,
	@MoTa nvarchar(2000),
	@Hinh nvarchar (200),@CurrentID int output)
as
begin try
if(not exists(select * from SACH where MaSach=@MaSach and MaLoaiSach=@MaLoaiSach))
begin
set @CurrentID=0
return
end
Update  SACH  set MaLoaiSach=@MaLoaiSach,TenSach=@TenSach,Gia=@Gia,MoTa=@MoTa,Hinh=@Hinh where MaSach=@MaSach;
set @CurrentID=1
end try
begin catch
set @CurrentID=0
end catch
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

--Xoa loai sach

create PROC sp_XoaLoaiSach @MaLoaiSach int,@CurrentID int output
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

--Them loai sach
create PROC sp_ThemLoaiSach(@TenLoaiSach nvarchar(50),@Hinh nvarchar(200),@CurrentID int output)
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
--Sua loai sach

create PROC sp_CapNhatLoaiSach( @MaLoaiSach int,@TenLoaiSach nvarchar(50),@Hinh nvarchar(200),@CurrentID int output)
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

 