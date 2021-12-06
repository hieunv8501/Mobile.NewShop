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
	MaLoaiSach int primary key,
	TenLoaiSach varchar(50),
	Hinh varchar(100),
)
create table SACH
(
	MaSach int primary key,
	MaLoaiSach int,
	TenSach varchar(50),
	Gia money,
	MoTa nvarchar(50),
	Hinh varchar(100),
)

create table HOADON 
(
	MaHoaDon int primary key,
	TenDangNhap varchar(50),
	NgayHoaDon datetime,
	TongTien money,
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

alter table HOADON add constraint fk_HOADON_TAIKHOAN foreign key (TenDangNhap) references TAIKHOAN(TenDangNhap)
alter table CT_HOADON add constraint fk_CTHOADON_HOADON foreign key (MaHoaDon) references HOADON(MaHoaDon)
alter table CT_HOADON add constraint fk_CTHOADON_SACH foreign key (MaSach) references SACH(MaSach)
alter table SACH add constraint fk_SACH_LOAISACH foreign key (MaLoaiSach) references LOAISACH(MaLoaiSach)


insert into TAIKHOAN values ('hieu', '1' , N'Hiếu', '0123456789'), ('hau', '1', N'Hậu', '0987654321'), ('tinh', '1', N'Tình', '0984221251')
insert into LOAISACH values (1, 'Loaisach1', 'Loaisach1.jpg'), 
			(2, 'Loaisach2', 'Loaisach2.jpg'), 
			(3, 'Loaisach3', 'Loaisach3.jpg')
insert into SACH values (1, 1, 'TenSach1', 500, N'Mô tả TenSach1', 'sach1.jpg'), 
			(2, 1, 'TenSach2', 1000, N'Mô tả TenSach2', 'sach2.jpg'),
			(3, 2, 'TenSach3', 100, N'Mô tả TenSach3', 'sach3.jpg'), 
			(4, 2, 'TenSach4', 1500, N'Mô tả TenSach4', 'sach4.jpg'),
			(5, 2, 'TenSach5', 3000, N'Mô tả TenSach5', 'sach5.jpg'),
			(6, 3, 'TenSach6', 1500, N'Mô tả TenSach6', 'sach6.jpg')

create procedure sp_LayDanhSachTaiKhoan
as begin
	select * from TAIKHOAN
end



create procedure sp_LayDanhSachLoaiSach
as begin
	select * from LOAISACH
end



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

create procedure sp_LayHoaDonTheoTenDangNhap @TenDangNhap varchar(50)
as begin
	select MaHoaDon, HOADON.TenDangNhap, NgayHoaDon, TongTien, TinhTrang
	from HOADON join TAIKHOAN on HOADON.TenDangNhap = TAIKHOAN.TenDangNhap
	where TAIKHOAN.TenDangNhap = @TenDangNhap
end


create procedure sp_LayCTHDTheoMaHoaDon @MaHoaDon int
as begin
	select *
	from CT_HOADON 
	where MaHoaDon = @MaHoaDon
end


alter procedure sp_LayCTHDTheoMaHoaDon @MaHoaDon int
as begin
	select MaHoaDon, SACH.TenSach, SoLuong, SACH.Gia, ThanhTien, SACH.Hinh
	from CT_HOADON join SACH on CT_HOADON.MaSach = SACH.MaSach
	where MaHoaDon = @MaHoaDon
end


create procedure sp_ThemTaiKhoan @TenDangNhap varchar(50), @MatKhau varchar(50), @TenKhachHang nvarchar(50), @SoDienThoai varchar(10)
as begin
	insert into TAIKHOAN values(@TenDangNhap, @MatKhau, @TenKhachHang, @SoDienThoai)
end


create procedure sp_ThemHoaDon @TenDangNhap varchar(50), @NgayHoaDon datetime
as begin
	declare @MaHoaDon int
	set @MaHoaDon = 1
	while @MaHoaDon in (select MaHoaDon from HOADON)
		set @MaHoaDon = @MaHoaDon + 1
	insert into HOADON values (@MaHoaDon, @TenDangNhap, @NgayHoaDon, 0, 0)
end


create procedure sp_ThemChiTietHoaDon @MaSach int, @TenDangNhap varchar(50), @NgayHoaDon datetime
as begin
	declare @MaHoaDon int, @Gia money
	select @Gia = Gia from SACH where MaSach = @MaSach
	if not exists (select * from HOADON where TinhTrang = 0 and TenDangNhap = @TenDangNhap)
	begin
		exec sp_ThemHoaDon @TenDangNhap, @NgayHoaDon
		select @MaHoaDon = MaHoaDon from HOADON where TinhTrang = 0
		insert into CT_HOADON values (@MaHoaDon, @MaSach, 1, @Gia)
	end
	else begin
		select top 1 @MaHoaDon = MaHoaDon from HOADON where TinhTrang = 0 and TenDangNhap = @TenDangNhap
		if exists (select * from CT_HOADON where MaSach = @MaSach and MaHoaDon = @MaHoaDon)
		begin
			declare @SoLuongCu int
			select @SoLuongCu = SoLuong from CT_HOADON where MaSach = @MaSach and MaHoaDon = @MaHoaDon
			update CT_HOADON
			set SoLuong = @SoLuongCu + 1
			where MaSach = @MaSach and MaHoaDon = @MaHoaDon	
			update CT_HOADON
			set ThanhTien = SoLuong * @Gia
			where MaSach = @MaSach and MaHoaDon = @MaHoaDon
			update HOADON
			set TongTien = (select sum(ThanhTien) from CT_HOADON where MaHoaDon = @MaHoaDon)
			where MaHoaDon = @MaHoaDon
		end
		else begin
			insert into CT_HOADON values (@MaHoaDon, @MaSach, 1, @Gia)
		end
	end
end


create procedure sp_CapNhapTinhTrangHoaDon @MaHoaDon int
as begin
	update HOADON 
	set TinhTrang = 1
	where MaHoaDon = @MaHoaDon
end


create procedure sp_XoaChiTietHoaDon @MaHoaDon int, @MaSach int
as begin
	delete from CT_HOADON where MaHoaDon = @MaHoaDon and MaSach = @MaSach
end



create trigger trigger_insert_cthoadon on CT_HOADON
for insert as begin
	declare @MaHoaDon int, @MaSach int, @SoLuong int, @Gia money, @TongTienCu money
	select @MaHoaDon = MaHoaDon, @MaSach = MaSach, @SoLuong = SoLuong from inserted
	select @TongTienCu = TongTien from HOADON where MaHoaDon = @MaHoaDon
	select @Gia = Gia from SACH where MaSach = @MaSach
	update HOADON 
	set TongTien = @TongTienCu + (@SoLuong * @Gia)
	where MaHoaDon = @MaHoaDon
end


create trigger trigger_delete_cthoadon on CT_HOADON
for delete
as begin
	declare @MaHoaDon int, @ThanhTien money, @TongTienCu money
	select @MaHoaDon = MaHoaDon, @ThanhTien = ThanhTien from deleted
	select @TongTienCu = TongTien from HOADON where MaHoaDon = @MaHoaDon
	update HOADON 
	set TongTien = @TongTienCu - @ThanhTien
	where MaHoaDon = @MaHoaDon
	if not exists (select * from CT_HOADON where MaHoaDon = @MaHoaDon)
	begin
		delete from HOADON where MaHoaDon = @MaHoaDon
	end
end
