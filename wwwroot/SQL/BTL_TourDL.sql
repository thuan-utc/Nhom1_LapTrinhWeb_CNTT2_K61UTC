
use [TourManagement]
create table DaiLy(
	MaDaiLy int identity not null primary key,
	TenDaiLy nvarchar(300) not null,
	SDT nvarchar(20) not null,
	DiaChi nvarchar(100) not null,
	isDeleted int default 0,
)
create table KhachHang(
	MaKH int identity not null primary key,
	TenKH nvarchar(30) not null,
	SoCMND nvarchar(20) not null,
	SDT nvarchar(20) not null,
	DiaChi nvarchar(100) not null,
	AnhKH nvarchar(100) not null,
	isDeleted int default 0,
)
create table NhanVien(
	MaNV int identity not null primary key,
	MaDaiLy int ,
	TenNV nvarchar(30) not null,
	SDT nvarchar(20) not null,
	ChucVu nvarchar(20) not null,
	DiaChi nvarchar(100) not null,
	AnhNV nvarchar(300) not null,
	isDeleted int default 0,
	constraint fk_NhanVien_DaiLy foreign key (MaDaiLy) references DaiLy(MaDaiLy) 
)

create table Tour(
	MaTour int identity not null primary key,
	MaNV int ,
	MaDaiLy int,
	TenTour nvarchar(30) not null,
	Diadiem nvarchar(50) not null,
	ChiTietLT nvarchar(500) not null,
	NgayBD datetime not null,
	NgayKT datetime not null,
	NoiKhoiHanh nvarchar(200) not null,
	AnhTour nvarchar(300) not null,
	Gia money,
	Active int default 0,
	isDeleted int default 0,
	constraint fk_Tour_NhanVien foreign key (MaNV) references NhanVien(MaNV),
	constraint fk_Tour_DaiLy foreign key (MaDaiLy) references NhanVien(MaDaiLy),
)
create table HoaDon(
	MaHD int identity primary key not null,
	MaDaiLy int ,
	MaTour int ,
	MaKH int ,
	TongTien money ,
	isDeleted int default 0,
	CreatedDate DATETIME DEFAULT GETDATE(),
	constraint fk_HoaDon_DaiLy foreign key (MaDaiLy) references DaiLy(MaDaiLy), 
	constraint fk_HoaDon_Tour foreign key (MaTour) references Tour(MaTour), 
	constraint fk_HoaDon_KhachHang foreign key (MaKH) references KhachHang(MaKH) 
)
create table CTHD(
	MaCTHD int identity not null,
	MaHD int not null,
	NgayTao datetime default current_timestamp,
	Gia money,
	SoVe int,
	isDeleted int default 0,
	constraint fk_CTHD_HoaDon foreign key (MaHD) references HoaDon(MaHD)
)
create table TaiKhoan(
	id int identity primary key not null,
	taikhoan nvarchar(30) not null,
	matkhau nvarchar(30) not null,
	email nvarchar(30) not null,
	loai nvarchar(20) not null,
	MaDaiLy int ,
	MaKH int ,
	isDeleted int default 0,
	constraint fk_TaiKhoan_DaiLy foreign key (MaDaiLy) references DaiLy(MaDaiLy), 
	constraint fk_TaiKhoan_KhachHang foreign key (MaKH) references KhachHang(MaKH), 
)

create table CTTour(
	MaCTTour int identity not null,
	MaTour int not null,
	ThoiGian nvarchar(30) not null,
	PhuongTien nvarchar(40) not null,
	ĐiemTQ nvarchar(100),
	AmThuc nvarchar(200) not null,
	KhachSan nvarchar(40) not null,
	DoiTuongTH nvarchar(50) not null,
	UuDai nvarchar(20),
	CONSTRAINT fk_CTTour_Tour FOREIGN KEY (MaTour) REFERENCES Tour(MaTour)
)
insert into CTTour(MaTour,ThoiGian,PhuongTien,AmThuc,KhachSan,DoiTuongTH)values
(18,N'3 ngày 2 đêm',N'Máy bay, Xe du lịch',N'Buff sáng, Theo thực đơn, Đặc sản địa phương',N'Khách sạn 4 sao',N'Gia đình nhiều thế hệ'),
(19,N'2 ngày 1 đêm',N'Máy bay, Xe du lịch',N'Buff sáng, Theo thực đơn, Đặc sản địa phương',N'Khách sạn 4 sao',N'Các cặp đôi'),
(20,N'6 ngày 5 đêm',N'Máy bay, Xe du lịch',N'Buff sáng, Theo thực đơn, Đặc sản địa phương',N'Khách sạn 4 sao',N'Gia đình nhiều thế hệ'),
(21,N'6 ngày 5 đêm',N'Máy bay, Xe du lịch',N'Buff sáng, Theo thực đơn, Đặc sản địa phương',N'Khách sạn 4 sao',N'Gia đình nhiều thế hệ'),
(22,N'4 ngày 3 đêm',N'Máy bay, Xe du lịch',N'Buff sáng, Theo thực đơn, Đặc sản địa phương',N'Khách sạn 4 sao',N'Gia đình nhiều thế hệ')




--user(Khachhang,doitac,admin)
-- + bang authority (user_name,pass, role(admin, user, cooperator) => ddawng nhap vao => dua vao role => link to page cua no

--Insert Đại lý
insert into DaiLy (TenDaiLy,SDT,DiaChi) values 
(N'Công ty cổ phần Việt Nam Booking','19004798',N'Số 190-192 Trần Quý, P.6, Q.11, TP. Hồ Chí Minh'),
(N'Công ty du lịch BestPrice','02473072605',N'57 Trần Quốc Toản, phường Trần Hưng Đạo, Hoàn Kiếm'),
(N'Công ty Tam Vương Group với thương hiệu VietAir.tv','02473073399',N'Số 12, Đường Trung Yên 6, Cầu Giấy, Hà Nội'),
(N'Công ty RDT Việt Nam với thương hiệu AloTrip.vn','02438688800',N'Số 17, Đường Lương Định Của, quận Đống Đa, Hà Nội'),
(N'Công ty Cổ phần Du lịch và Dịch vụ Hy Vọng','02438240809',N'112 Hai Bà Trưng, quận Hoàn Kiếm, Hà Nội'),
(N'Saigon Tourist','02838251507',N'45 Lê Thánh Tôn, Quận 1, TP. Hồ Chí Minh'),
(N'Công ty Ánh Dương','0862671700',N'712 Lũy Bán Bích, Phường Tân Thành, Quận Tân Phú, TP. Hồ Chí Minh'),
(N'Công ty cổ phần du lịch quốc tế ALO TOUR','19006856',N'Số 190-192 Trần Quý, P.6, Q.11, TP. Hồ Chí Minh'),
(N'Ngôi Nhà Phương Nam','0901384599',N'987 Phạm Văn Bạch , P12, Q.Gò Vấp,  TP. Hồ Chí Minh'),
(N'Vlink','02873004078',N' 06 Phan Chu Trinh, P.Tân Thành, Q.Tân Phú, TP. Hồ Chí Minh')


--Insert Khách hàng
insert into KhachHang(TenKH,SoCMND,SDT,DiaChi,AnhKH) values 
(N'Trần Mai Anh','036204889567','0971833578',N'Hà Nội','NV01'),
(N'Nguyễn Quốc Hưng','036204892603','0829328732',N'Hà Nội','NV02'),
(N'Ông Cao Thắng','036202007865','0985789466',N'Nam Định','NV03'),
(N'Nguyễn Quỳnh Ngọc','036205009704','0356478450',N'Thái Bình','NV04'),
(N'Trần Văn Vinh','036201009764','0362025641',N'Bắc Giang','NV05'),
(N'Trần Văn Hát','036202005671','0985678888',N'Hà Nội','NV06'),
(N'Nguyễn Thị Loan','036102006756','0914645555',N'Sài Gòn','NV07'),
(N'Vũ Thành Đạt','036204259703','0911686868',N'TP. Hồ Chí Minh','NV08'),
(N'Phạm Thuỳ Huê','036104889234','0382868686',N'TP. Hồ Chí Minh','NV09'),
(N'Hứa Đức Cảnh','036202006785','0971833026',N'Sài Gòn','NV10')
--Insert Nhân viên
insert into NhanVien (MaDaiLy,TenNV,SDT,ChucVu,DiaChi,AnhNV) values (3,N'Nguyễn Thu Hà','0838765789','HDV',N'Hà Nội','NV01'),
(4,N'Trần Văn Vinh','0011165324','HDV',N'Nam Định','NV02'),
(5,N'Nguyễn Ánh Ngọc','0353231048','HDV',N'Bắc Giang','NV03'),
(6,N'Trịnh Kim Anh','0986785264','HDV',N'Phú Thọ','NV04'),
(7,N'Kiều Minh Tuấn','0567893563','HDV',N'Thái Bình','NV05'),
(8,N'Lý Thu Nhai','0785637921','HDV',N'Quảng Ninh','NV06'),
(9,N'Nguyễn Văn Vinh','0368249655','HDV',N'Nam Định','NV07'),
(10,N'Phạm Hữu Phúc','0358639672','HDV',N'Vĩnh Phúc','NV08'),
(11,N'Trần Hoàng Lam','0569342673','HDV',N'Hà Nội','NV09'),
(2,N'Trần Hoàng Trọng','0569342673','HDV',N'Hà Nam','NV10')

--Insert Tour
insert into Tour (TenTour,ChiTietLT,NgayBD,NgayKT,AnhTour) values 
(N'Tour team building gala dinner 2 ngày 1 đêm Phan Thiết Tà Cú | Bàu Trắng – Mũi Né – Lâu Đài Rượu Vang',N'Lịch trình','2023/02/19','2023/02/21','Tour01'),
(N'Tour Cha Diệp Mẹ Nam Hải 1 ngày 1 đêm: Cánh đồng điện gió – Chùa Dơi',N'Lịch trình','2023/02/18','2023/02/19','Tour2'),
(N'Tour Núi Tà Cú – Mũi Né – KDL Bầu Trắng – Phan Thiết 2N1Đ | Khám phá vùng đất tiểu sa mạc',N'Lịch trình','2023/02/19','2023/02/21','Tour03'),
(N'Tour Đà Lạt 3 ngày 3 đêm | Hành trình “săn mây” tham quan các địa điểm cực HOT',N'Lịch trình','2023/02/19','2023/02/21','Tour04'),
(N'Tour du lịch Tết 2024 TP.HCM – Phú Quốc 3N2Đ | Du xuân khám phá Đảo Ngọc',N'Lịch trình','2023/02/19','2023/02/21','Tour05'),
(N'Tour du lịch Campuchia – Koh Rong – Samloem 4N3Đ | Tận hưởng kì nghỉ tuyệt vời tại thiên đường biển đảo',N'Lịch trình','2023/02/19','2023/02/21','Tour06'),
(N'Tour Đồng Tháp 1 Ngày: Khám phá Làng hoa Sa Đéc – Vườn quýt hồng Lai Vung – Kiến An Cung',N'Lịch trình','2023/02/19','2023/02/21','Tour07'),
(N'Tour du lịch Tết TP.HCM – Đà Nẵng – Bà Nà Hills – Hội An – Huế 4N3Đ | Xuân trên miền đất di sản',N'Lịch trình','2023/02/19','2023/02/21','Tour08')



--inser Hoa Don
insert into HoaDon (TongTien) values (10000000)

-- insert CTHD
insert into CTHD (MaHD,NgayTao,Gia,SoVe) values(1,'2023/04/01',1000000,10)


--insert TaiKhoan 
insert into TaiKhoan(taikhoan,matkhau,email,loai) values 
('nbtuan','123456',N'tuan@gmail.com','admin'),
('ndthuan','123456',N'thuan@gmail.com','cooperator'),
('tbquoc','123456',N'quoc@gmail.com','cooperator'),
('ntphuong','123456',N'phuong@gmail.com','customer'),
('ntnhung','123456',N'nhung@gmail.com','customer'),
('cmquan','123456',N'quan@gmail.com','customer')







