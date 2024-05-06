create database COFFEE_HOUSE
go 
use COFFEE_HOUSE
go
-- Tạo bảng nhân viên
create table NHANVIEN(
 MaNV int identity primary key,
 Ho nvarchar(30) NOT NULL,
 Ten nvarchar(30) NOT NULL,
 Phai nvarchar(4) NOT NULL,
 NgaySinh date NOT NULL,
 DiaChi nvarchar(100) NOT NULL,
 SDT char(10) NOT NULL,
 Email char(50) NOT NULL,
 ChucVu nvarchar(30) NOT NULL,
 TrangThai int NOT NULL, -- quy định: 1.Enabled 0.Disabled 

 constraint CK_NV_TrangThai Check (TrangThai = 0 or TrangThai = 1),
 constraint CK_NV_phai Check (Phai = N'Nam' or Phai = N'Nữ')
)

 create table LOAI_TAIKHOAN(
 MaLoai int identity primary key,
 TenLoai nvarchar(20) NOT NULL,
 TrangThai int NOT NULL --quy định: 1.Enabled 0.Disabled -- trước khi xoá cần kiểm tra Có tồn tạo trong tài khoản thì không xoá.
 )
 create table TK_QUYEN(
 MaQuyen int identity primary key,
 TenQuyen nvarchar(20) NOT NULL,
 TrangThai int NOT NULL -- quy định  --quy định: 1.Enabled 0.Disabled -- trước khi xoá cần kiểm tra Có tồn tạo trong tài khoản, nhân viên thì không xoá.
 )


create table TAIKHOAN(

MaTK int identity primary key,
MaNV int,
Username varchar(30) NOT NULL,
MatKhau nvarchar(MAX) NOT NULL,
LoaiTK int,
Quyen int,
TrangThai int NOT NULL,

constraint CK_TK_TrangThai Check (TrangThai = 0 or TrangThai = 1),
constraint FK_TK_NV foreign key (MaNV) references NHANVIEN(MaNV),
constraint FK_TK_LOAI_TK foreign key (LoaiTK) references LOAI_TAIKHOAN(MaLoai),
constraint FK_TK_QUYEN foreign key(Quyen) references TK_QUYEN(MaQuyen)
)


create table LOAI_SANPHAM(
MaLoai int identity primary key,
TenLoai nvarchar(20) NOT NULL,
TrangThai int NOT NULL  -- quy định  --quy định: 1.Enabled 0.Disabled -- trước khi xoá cần kiểm tra Có tồn tạo trong sản phẩm thì không xoá.
)

create table SANPHAM(
MaSP int identity primary key,
Avatar varchar(MAX) NULL,
TenSP nvarchar(40) NOT NULL,
LoaiSP int,
GiaBan int,
TrangThai int NOT NULL,

constraint CK_SP_TrangThai Check (TrangThai = 0 or TrangThai = 1),
constraint FK_LOAI_SANPHAM foreign key(LoaiSP) references LOAI_SANPHAM(MaLoai)
)
create table LOAI_BAN (
MaLoai int identity primary key,
TenLoai nvarchar(30) NOT NULL,
TrangThai int NOT NULL  -- quy định  --quy định: 1.Enabled 0.Disabled -- trước khi xoá cần kiểm tra Có tồn tạo trong bàn thì không xoá.
)
create table BAN(
MaBan int identity primary key,
LoaiBan int,
TrangThai int NOT NULL , -- quy định  --quy định: 1.Enabled 0.Disabled -- trước khi xoá cần kiểm tra Có tồn tạo trong hoá đơn thì không xoá.

constraint CK_BAN_TrangThai Check (TrangThai =0 or TrangThai = 1),
constraint FK_LOAI_BAN foreign key(LoaiBan) references LOAI_BAN(MaLoai)
)
create  table KHUYENMAI(
MaGiamGia int identity primary key,
TenMaGiamGia nvarchar(20),
PhanTram float,
SoLuong int NOT NULL,
NgayBatDau date NOT NULL,
NgayKetThuc date NOT NULL,
Mota nvarchar(50) NOT NULL,
TrangThai int
)
create table HOADON (
MaHD int identity primary key,
MaNV int,
MaBan int,
MaKhuyenMai int NULL,
NgayLap date NOT NULL,
TrangThai int NOT NULL,

constraint CK_HD_TrangThai Check (TrangThai = 0 or TrangThai = 1),
constraint FK_HD_NV foreign key (MaNV) references NHANVIEN(MaNV),
constraint FK_HD_BAN foreign key (MaBan) references BAN(MaBan),

)
alter table HOADON add constraint FK_HD_KM foreign key (MaKhuyenMai) references KHUYENMAI(MaGiamGia)


create table CTHD (
MaCT int identity primary key,
MaHD int,
MaSP int,
SL int NOT NULL,

constraint FK_CT_HD foreign key (MaHD) references HOADON(MaHD),
constraint FK_CT_SP foreign key (MaSP) references SANPHAM(MaSP)
)


create table NCC (
MaNCC int identity primary key,
TenNCC nvarchar(50) NOT NULL,
XuatXu nvarchar(50) NOT NULL,
DiaChi nvarchar(100) NOT NULL,
TrangThai int NOT NULL,

constraint CK_NCC_TrangThai Check (TrangThai =0 or TrangThai = 1)
)
create table LOAI_NGUYENLIEU(
MaLoai int identity primary key,
Tenloai nvarchar(50),
TrangThai int NOT NULL  --quy định: 1.Enabled 0.Disabled -- trước khi xoá cần kiểm tra Có tồn tạo trong nguyên liệu thì không xoá.
)

create table NGUYENLIEU(
MaNL int identity primary key,
MaNCC int,
TenNL nvarchar(50) NOT NULL,
LoaiNL int,
SLTon int NOT NULL,
DVT nvarchar(30) NOT NULL,
TrangThai int NOT NULL,

constraint CK_NL_TrangThai Check (TrangThai =0 or TrangThai = 1),
constraint FK_NL_NCC foreign key (MaNCC) references NCC(MaNCC),
constraint FK_LOAI_NGUYENLIEU foreign key (LoaiNL) references LOAI_NGUYENLIEU(MaLoai) 

)

create table DONNHAPHANG(
MaDon int identity primary key,
MaNV int,
NgayLap date NOT NULL,
TrangThai int NOT NULL, -- trạng thái 1 là nhập rồi , 0 là huỷ đơn

constraint CK_DNH_TrangThai Check (TrangThai =0 or TrangThai = 1),
constraint FK_DNH_NV foreign key (MaNV) references NHANVIEN(MaNV)

)

create table CTPHIEUNHAP(
MaPN int identity primary key,
MaNL int,
MaDon int,
SL int NOT NULL,
DVT nvarchar(30) NOT NULL,
GiaNhap float,
GiamGia float

constraint FK_CT_DNH foreign key (MaDon) references DONNHAPHANG(MaDon),
constraint FK_CT_NL foreign key (MaNL) references NGUYENLIEU(MaNL)

)
--THÊM THÔNG TIN CƠ SỞ DỮ LIỆU QUÁN COFFEE HOUSE 
-- BẢNG NHÂN VIÊN
--HO,TEN,PHAI,NGAYSINH,DIACHI,SDT,EMAIL,CHUCVU,TRANGTHAI
INSERT INTO NHANVIEN VALUES(N'Nguyễn',N'Tâm',N'Nam',Convert(date,'01/09/1990',105),N'65 Huỳnh Thúc Kháng Quận 1','0147258741','nguyentam98@gmail.com',N'Nhân viên',1) --1
INSERT INTO NHANVIEN VALUES(N'Lâm Kỳ',N'An',N'Nữ',Convert(date,'25/10/2000',105),N'Lê Văn Việt Quận 9 Tp.Thủ Đức','0147884545','kyan8754@gmail.com',N'Quản lý',1) --2
INSERT INTO NHANVIEN VALUES(N'Lê Lâm',N'Thanh Phúc',N'Nam',Convert(date,'19/12/1989',105),N'An Dương Vương Quận 6','0147200689','thanhphuc9853@gmail.com',N'Nhân viên',0) --3
INSERT INTO NHANVIEN VALUES(N'Nguyễn Thanh',N'Danh',N'Nam',Convert(date,'20/10/2002',105),N'Ký Con Quận 10 ','0522258741','thanhdanh758@gmail.com',N'Quản lý',1) --4
INSERT INTO NHANVIEN VALUES(N'Phạm Gia',N'Hân',N'Nữ',Convert(date,'11/10/1999',105),N'Đường 3654 Tân Kỳ Tân Quý Quận Bình Tân','0986358741','giahan09@gmail.com',N'Quản lý',1) --5
INSERT INTO NHANVIEN VALUES(N'Trần Cẩm',N'Hương',N'Nữ',Convert(date,'16/03/2003',105),N'Đường Lê Quý Đôn Quận 6','0183558895','camhuong8993@gmail.com',N'Nhân viên',1) --6
INSERT INTO NHANVIEN VALUES(N'Lâm Y',N'Chính',N'Nữ',Convert(date,'20/11/2004',105),N'Đường Trần Hưng Đạo Quận 1','0931258741','ychinh992@gmail.com',N'Nhân viên',1)--7
INSERT INTO NHANVIEN VALUES(N'Nguyễn Gia',N'Hưng',N'Nam',Convert(date,'02/03/1999',105),N'Đường 667 Quận 12','0147278259','hung883@gmail.com',N'Nhân viên',0) --8
INSERT INTO NHANVIEN VALUES(N'Lý Thị',N'Nga',N'Nữ',Convert(date,'25/12/1991',105),N' Đường Nguyễn Đình Chiểu Quận 8','0478958741','thinga221@gmail.com',N'Nhân viên',1)--9
INSERT INTO NHANVIEN VALUES(N'Lê Ngọc',N'Văn',N'Nam',Convert(date,'04/08/2005',105),N'21 Tân Quy Quận 7','0789458741','ngocvan212@gmail.com',N'Nhân viên',1)--10
--BẢNG LOẠI TÀI KHOẢN 
--MaLoai,TenLoai,TrangThai
INSERT INTO LOAI_TAIKHOAN VALUES(N'Quản lý',1) --1
INSERT INTO LOAI_TAIKHOAN VALUES(N'Nhân viên',1) --2

--BẢNG TK_QUYEN
--MaQuyen,TenQuyen,TrangThai
INSERT INTO TK_QUYEN VALUES(N'Full Control',1) --1
INSERT INTO TK_QUYEN VALUES(N'Half Control',1) --2

-- Thêm thông tin bảng TAIKHOAN 
--MATK,MANV,Username,MatKhau,LoaiTK,Quyen,TrangThai
--Bảng TAIKHOAN 2-2 LÀ NHÂN VIÊN, 1-1 LÀ QUẢN LÍ

INSERT INTO TAIKHOAN VALUES (1,'NguyenTam01','1BBD886460827015E5D605ED44252251',2,2,1)
INSERT INTO TAIKHOAN VALUES (2,'LamAn02','1BBD886460827015E5D605ED44252251',1,1,1)
INSERT INTO TAIKHOAN VALUES (3,'LePhuc03','1BBD886460827015E5D605ED44252251',2,2,0)
INSERT INTO TAIKHOAN VALUES (4,'NguyenDanh04','1BBD886460827015E5D605ED44252251',1,1,1)
INSERT INTO TAIKHOAN VALUES (5,'PhamHan05','1BBD886460827015E5D605ED44252251',1,1,1)
INSERT INTO TAIKHOAN VALUES (6,'TranHuong06','1BBD886460827015E5D605ED44252251',2,2,1)
INSERT INTO TAIKHOAN VALUES (7,'LamChinh07','1BBD886460827015E5D605ED44252251',2,2,1)
INSERT INTO TAIKHOAN VALUES (8,'NguyenHung08','1BBD886460827015E5D605ED44252251',2,2,0)
INSERT INTO TAIKHOAN VALUES (9,'LyNga09','1BBD886460827015E5D605ED44252251',2,2,1)
INSERT INTO TAIKHOAN VALUES (10,'LeVan10','1BBD886460827015E5D605ED44252251',2,2,1)

-- THÊM THÔNG TIN BẢNG LOAI_BAN
--MaBan, TenBan,
INSERT INTO LOAI_BAN VALUES (N'Bàn gỗ thông',1)--1
INSERT INTO LOAI_BAN VALUES (N'Bàn nhựa tái chế',1)--2
INSERT INTO LOAI_BAN VALUES (N'Bàn đá',1)--3
INSERT INTO LOAI_BAN VALUES (N'Bàn tre',1)--4
INSERT INTO LOAI_BAN VALUES (N'Bàn sắt',1)--5

-- THÊM THÔNG TIN BẢNG BÀN (LoaiBan, TrangThai)
INSERT INTO BAN VALUES(1,1) --1
INSERT INTO BAN VALUES(2,0)--2 -- BỎ
INSERT INTO BAN VALUES(3,1)--3
INSERT INTO BAN VALUES(4,0)--4 -- BỎ
INSERT INTO BAN VALUES(5,1)--5
INSERT INTO BAN VALUES(1,1)--6
INSERT INTO BAN VALUES(1,1)--7
INSERT INTO BAN VALUES(1,1)--8
INSERT INTO BAN VALUES(2,1)--9
INSERT INTO BAN VALUES(3,1)--10
INSERT INTO BAN VALUES(2,1)--11
INSERT INTO BAN VALUES(3,1)--12
INSERT INTO BAN VALUES(4,1)--13
INSERT INTO BAN VALUES(5,1)--14

--THÊM THÔNG TIN BẢNG KHUYENMAI(TenMaGiamGia,PhanTram,SoLuong,NgayBatDau,NgayKetThuc,MoTa,TrangThai)
INSERT INTO KHUYENMAI VALUES(N'MAGIAM20',0.2,20,Convert(date,'16/03/2024',105),Convert(date,'19/07/2024',105),N'áp dụng cho hoá đơn',1)--1-- áp dụng cho hóa đơn
INSERT INTO KHUYENMAI VALUES(N'MAGIAM30',0.3,10,Convert(date,'12/02/2024',105),Convert(date,'15/03/2024',105),N'áp dụng cho hoá đơn',1)--2--áp dụng cho hóa đơn
INSERT INTO KHUYENMAI VALUES(N'XUANSUMVAY',0.1,25,Convert(date,'10/02/2024',105),Convert(date,'19/02/2024',105),N'áp dụng cho sản phẩm',1)--3 --áp dụng cho hóa đơn
INSERT INTO KHUYENMAI VALUES(N'VALATINE',0.15,10,Convert(date,'13/03/2024',105),Convert(date,'14/03/2024',105),N'áp dụng cho hoá đơn',0)--4
INSERT INTO KHUYENMAI VALUES(N'GIAIPHONG',0.2,20,Convert(date,'28/04/2024',105),Convert(date,'02/05/2024',105),N'áp dụng cho hoá đơn',1)--5
INSERT INTO KHUYENMAI VALUES(N'NHANHTAY',0.2,20,Convert(date,'01/03/2024',105),Convert(date,'01/06/2024',105),N'áp dụng cho sản phẩm',1)--6--áp dụng cho sản phẩm

--THÊM THÔNG TIN BẢNG HOADON(MaNV,MaBan,MaKhuyenMai,NgayLap,TrangThai) Trạng thái 0.Disabled(Trả rồi) 1.Enabled(Chưa trả)
INSERT INTO HOADON VALUES (1,1,6,Convert(date,'16/03/2024',105),0)--1
INSERT INTO HOADON VALUES (2,3,3,Convert(date,'11/02/2024',105),1)--2
INSERT INTO HOADON VALUES (3,5,3,Convert(date,'10/02/2024',105),0)--3
INSERT INTO HOADON VALUES (4,6,NULL,Convert(date,'01/03/2024',105),1)--4
INSERT INTO HOADON VALUES (5,7,6,Convert(date,'03/03/2024',105),1)--5
INSERT INTO HOADON VALUES (6,8,NULL,Convert(date,'02/03/2024',105),1)--6
INSERT INTO HOADON VALUES (7,9,NULL,Convert(date,'02/03/2024',105),1)--7
INSERT INTO HOADON VALUES (5,10,6,Convert(date,'10/03/2024',105),1)--8
INSERT INTO HOADON VALUES (1,11,NULL,Convert(date,'14/02/2024',105),1)--9
INSERT INTO HOADON VALUES (1,12,6,Convert(date,'12/03/2024',105),1)--10
INSERT INTO HOADON VALUES (2,13,NULL,Convert(date,'11/02/2024',105),1)--11
INSERT INTO HOADON VALUES (3,14,NULL,Convert(date,'08/03/2024',105),1)--12
INSERT INTO HOADON VALUES (10,1,NULL,Convert(date,'09/03/2024',105),1)--13
INSERT INTO HOADON VALUES (9,5,NULL,Convert(date,'13/03/2024',105),1)--14


-- THÊM THÔNG TIN BẢNG LOAI_SANPHAM(MaLoai,TenLoai,TrangThai)
INSERT INTO LOAI_SANPHAM VALUES(N'Trà Sữa',1)--1
INSERT INTO LOAI_SANPHAM VALUES(N'Trà Trái Cây',1)--2
INSERT INTO LOAI_SANPHAM VALUES(N'Trà Olong',1)--3
INSERT INTO LOAI_SANPHAM VALUES(N'Coffee',1)--4
INSERT INTO LOAI_SANPHAM VALUES(N'Coffee Đường Đen',1)--5
INSERT INTO LOAI_SANPHAM VALUES(N'Yourgut',1)--6

-- THÊM THÔNG TIN BẢNG LOAI_NGUYENLIEU(MaLoai,TenLoai,TrangThai)
INSERT INTO LOAI_NGUYENLIEU VALUES(N'Đường',1)--1
INSERT INTO LOAI_NGUYENLIEU VALUES(N'Coffee',1)--2
INSERT INTO LOAI_NGUYENLIEU VALUES(N'Trà',1)--3
INSERT INTO LOAI_NGUYENLIEU VALUES(N'Yourgut',1)--4
INSERT INTO LOAI_NGUYENLIEU VALUES(N'Sữa',1)--5

-- THÊM THÔNG TIN BẢNG NCC(MaNCC,TenNCC,XuatXu,DiaChi,TrangThai) 0.Disabled(Không cung cấp nữa),1.Enabled(Còn cung cấp)
INSERT INTO NCC VALUES(N'Cty Quang Hải',N'Việt Nam',N'356 KCN Thủ Dầu 1 Bình Dương',1)--1
INSERT INTO NCC VALUES(N'Vườn Vải Y Nhê',N'Trung Quốc',N' KCN Bắc Hải Kiến Nam',0)--2
INSERT INTO NCC VALUES(N'Cty Sữa Đặc VMN',N'Việt Nam',N'KCN Công Nghệ Cao Quận 9 TP.Thủ Đức',1)--3
INSERT INTO NCC VALUES(N'Coffee Lounge Company',N'Hoa Kì',N'Amberllinger NewYork City',1)--4
INSERT INTO NCC VALUES(N'Cty Trà Hoa Thảo',N'Việt Nam',N'2344 KCN Bình Thạnh A Bình Dương',1)--5
INSERT INTO NCC VALUES(N'Cty Đường Nam Hải Yến',N'Việt Nam',N'8992 Thạnh Hóa tỉnh Long An',1)--6

--THÊM THÔNG TIN BẢNG SẢN PHẨM(MaSP,TenSP,LoaiSP,GiaBan,TrangThai)
INSERT INTO SANPHAM VALUES(N'img/coffeeden.jfif',N'Coffee Đen',4,15000,1)--1
INSERT INTO SANPHAM VALUES(N'img/coffee.jpg',N'Coffee Sữa',4,18000,1)--2
INSERT INTO SANPHAM VALUES(N'img/coffeesuatuoi.png',N'Coffee Sữa Tươi',4,20000,1)--3
INSERT INTO SANPHAM VALUES(N'img/trasuathai.png',N'Trà Sữa Truyền Thống',1,25000,1)--4
INSERT INTO SANPHAM VALUES(N'img/trasua.jpg',N'Trà Sữa Thái Xanh',1,25000,1)--5
INSERT INTO SANPHAM VALUES(N'img/traduongden.png',N'Trà Sữa Thái Đỏ',1,25000,1)--6
INSERT INTO SANPHAM VALUES(N'img/machiato.png',N'Trà Sữa Machiato',1,28000,1)--7
INSERT INTO SANPHAM VALUES(N'img/thaido.png',N'Trà Dâu Tươi',2,18000,1)--8
INSERT INTO SANPHAM VALUES(N'img/travai.png',N'Trà Vải',2,18000,1)--9
INSERT INTO SANPHAM VALUES(N'img/traolongxanh.jpg',N'Trà Olong Xanh',3,21000,1)--10
INSERT INTO SANPHAM VALUES(N'img/olongden.jfif',N'Trà Olong Đen',3,21000,1)--11
INSERT INTO SANPHAM VALUES(N'img/coffeeduongden.png',N'Coffee Sữa Đường Đen',5,28000,1)--12
INSERT INTO SANPHAM VALUES(N'img/yogurt.png',N'Yourgut Việt Quốc',6,30000,1)--13

-- THÊM THÔNG TIN BẢNG NGUYENLIEU(MaNCC,TenNL,LoaiNL,SLT,DVT,TrangThai)
INSERT INTO NGUYENLIEU VALUES (6,N'Đường Đen',1,30,N'Kg',1)
INSERT INTO NGUYENLIEU VALUES (4,N'Coffee Buôn Mê',2,10,N'Hộp',1)
INSERT INTO NGUYENLIEU VALUES (5,N'Trà Olong',3,20,N'Gói',1)
INSERT INTO NGUYENLIEU VALUES (4,N'Yourgut Brobie',4,2,N'Chai',1)
INSERT INTO NGUYENLIEU VALUES (3,N'Sữa Tươi',5,1,N'Thùng',1)
INSERT INTO NGUYENLIEU VALUES (3,N'Sữa Đặc',1,20,N'Lon',1)

--THÊM THÔNG TIN DONNHAPHANG (MaNV,NgayLap,TrangThai)
INSERT INTO DONNHAPHANG VALUES (1,Convert(date,'01/09/2024',105),1)--1
INSERT INTO DONNHAPHANG VALUES (2,Convert(date,'02/10/2024',105),0)--2--huỷ đơn(hàng đc trả lại mà không nhập vào hệ thống (tức là số lượng NGUYENLIEU không tăng ))
INSERT INTO DONNHAPHANG VALUES (5,Convert(date,'01/11/2024',105),1)--3
INSERT INTO DONNHAPHANG VALUES (6,Convert(date,'02/08/2024',105),1)--4
INSERT INTO DONNHAPHANG VALUES (10,Convert(date,'03/03/2024',105),1)--5
INSERT INTO DONNHAPHANG VALUES (4,Convert(date,'04/11/2024',105),0)--6 -- huỷ đơn -- nhập bổ sung nhưng huỷ đơn
INSERT INTO DONNHAPHANG VALUES (6,Convert(date,'02/06/2024',105),1)--7
INSERT INTO DONNHAPHANG VALUES (10,Convert(date,'01/07/2024',105),1)--8
-- THÊM THÔNG TIN BẢNG CTPHIEUNHAP(MaNL, MaDon, SL, DVT, GiaNhap, GiamGia)

INSERT INTO CTPHIEUNHAP VALUES (1,1,10,N'Kg',30000,0)
INSERT INTO CTPHIEUNHAP VALUES (2,2,20,N'Hộp',40000,0.1)
INSERT INTO CTPHIEUNHAP VALUES (3,3,5,N'Gói',48000,0.1)
INSERT INTO CTPHIEUNHAP VALUES (4,4,10,N'Chai',18000,0)
INSERT INTO CTPHIEUNHAP VALUES (5,5,10,N'Thùng',50000,0)
INSERT INTO CTPHIEUNHAP VALUES (6,6,5,N'Lon',22000,0.2)
INSERT INTO CTPHIEUNHAP VALUES (2,7,8,N'Hộp',40000,0)
INSERT INTO CTPHIEUNHAP VALUES (3,8,8,N'Gói',48000,0.1)
INSERT INTO CTPHIEUNHAP VALUES (3,8,2,N'Gói',48000,0.1)

--THÊM THÔNG TIN BẢNG CTHD (MaHD,MaSP,SL)
INSERT INTO CTHD VALUES (1,1,1)
INSERT INTO CTHD VALUES (1,2,2)
INSERT INTO CTHD VALUES (2,5,1)
INSERT INTO CTHD VALUES (2,6,1)
INSERT INTO CTHD VALUES (2,7,1)
INSERT INTO CTHD VALUES (5,10,2)
INSERT INTO CTHD VALUES (5,11,2)
INSERT INTO CTHD VALUES (5,12,1)
INSERT INTO CTHD VALUES (6,8,2)
INSERT INTO CTHD VALUES (6,9,1)
INSERT INTO CTHD VALUES (6,1,3)
INSERT INTO CTHD VALUES (6,2,1)
INSERT INTO CTHD VALUES (9,2,1)
INSERT INTO CTHD VALUES (10,11,1)
INSERT INTO CTHD VALUES (11,3,1)
INSERT INTO CTHD VALUES (12,7,2)
INSERT INTO CTHD VALUES (13,9,3)
INSERT INTO CTHD VALUES (14,6,2)
INSERT INTO CTHD VALUES (7,4,2)
INSERT INTO CTHD VALUES (7,10,1)
INSERT INTO CTHD VALUES (8,12,2)
INSERT INTO CTHD VALUES (8,13,1)
INSERT INTO CTHD VALUES (4,12,1)
INSERT INTO CTHD VALUES (4,2,1)
INSERT INTO CTHD VALUES (4,7,1)




Select * from SANPHAM














