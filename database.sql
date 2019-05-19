USE master
GO
CREATE DATABASE QLKD_DONGHO
GO
USE QLKD_DONGHO
GO
CREATE TABLE NGUOI_DUNG
(
	ID				INT					IDENTITY(1,1),
	NAME			VARCHAR(30)			NOT NULL,
	PASS			VARCHAR(50)			NOT NULL,
	HOTEN			NVARCHAR(50)		NOT NULL,
	NGAYSINH		DATE					NULL,
	DIACHI			NVARCHAR(100)			NULL,
	SDT				VARCHAR(10)			NOT NULL,
	TRANGTHAI		BIT					DEFAULT 1,
	IS_SUPER_USER	BIT					DEFAULT 0,
	PRIMARY KEY(ID)
)
GO
CREATE TABLE QUYEN_LOI
(
	ID				INT					IDENTITY(1,1),
	LOAIHINH		VARCHAR(30)			NOT NULL,
	NOIDUNG			NVARCHAR(100)			NULL,
	PRIMARY KEY(ID)
)
GO
CREATE TABLE PHAN_QUYEN
(
	ID				INT					IDENTITY(1,1),
	ID_NGUOIDUNG	INT					NOT NULL,
	ID_QUYENLOI		INT					NOT NULL,
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_NGUOIDUNG) REFERENCES NGUOI_DUNG(ID) ON DELETE CASCADE,
	FOREIGN KEY(ID_QUYENLOI) REFERENCES QUYEN_LOI(ID) ON DELETE CASCADE
)
GO
CREATE TABLE BAI_VIET
(
	ID				INT					IDENTITY(1,1),
	TEN				NVARCHAR(250)		NOT NULL,
	HINH			VARCHAR(500)			NULL,
	ND_TOMTAT		NVARCHAR(500)			NULL,
	NOIDUNG			NVARCHAR(MAX)			NULL,
	NGAYDANG		DATE					NULL,
	LOAITIN			VARCHAR(10)				NULL,
	ID_NGUOIDUNG	INT					NOT NULL,
	DUYET			BIT					DEFAULT 0,
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_NGUOIDUNG) REFERENCES NGUOI_DUNG(ID) ON DELETE CASCADE
)
GO
CREATE TABLE SLIDE
(
	ID				INT					IDENTITY(1,1),
	HINH			VARCHAR(500)		NOT NULL,
	LOGAN			NVARCHAR(200)			NULL,
	PRIMARY KEY(ID)
)
GO
CREATE TABLE HANG_SX
(
	ID				INT					IDENTITY(1,1),
	TEN				NVARCHAR(30)		NOT NULL,
	LOGO			VARCHAR(500)			NULL,
	GIOITHIEU		NVARCHAR(4000)			NULL,
	PRIMARY KEY(ID)
)
GO
CREATE TABLE KIEU_MAY
(
	ID				INT					IDENTITY(1,1),
	TEN				VARCHAR(50)			NOT NULL,
	GHICHU			NVARCHAR(100)			NULL,
	PRIMARY KEY(ID)
)
GO
CREATE TABLE DONG_HO
(
	ID				INT					IDENTITY(1,1),
	MAUMA			VARCHAR(30)			NOT NULL,	
	KICHCO			FLOAT					NULL,
	DODAY			FLOAT					NULL,
	CHATLIEU_VO		NVARCHAR(30)			NULL,
	CHATLIEU_DAY	NVARCHAR(30)			NULL,
	CHATLIEU_KINH	NVARCHAR(30)			NULL,
	DOCHIEUNUOC		INT						NULL,
	BAOHANH			NVARCHAR(20)			NULL,						
	DONGIA			INT				NOT NULL,
	NGAYDANG		DATE					NULL,
	ID_HANGSX		INT					NOT NULL,	
	GIAMGIA			INT						NULL,
	ID_KIEUMAY		INT					NOT NULL,	
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_HANGSX) REFERENCES HANG_SX(ID) ON DELETE CASCADE,
	FOREIGN KEY(ID_KIEUMAY) REFERENCES KIEU_MAY(ID) ON DELETE CASCADE
)
GO
CREATE TABLE HINH_ANH
(
	ID				INT					IDENTITY(1,1),
	URL				VARCHAR(500)		NOT NULL,
	ID_DONGHO		INT					NOT NULL,
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_DONGHO) REFERENCES DONG_HO(ID) ON DELETE CASCADE
)
GO
CREATE TABLE KHACH_HANG
(
	ID				INT					IDENTITY(1,1),
	HOTEN			NVARCHAR(50)		NOT NULL,	
	NGAYSINH		DATE					NULL,
	DIACHI			NVARCHAR(100)			NULL,
	SDT				VARCHAR(10)			NOT NULL,
	EMAIL			VARCHAR(100)			NULL,
	PASS			VARCHAR(50)				NULL,
	PRIMARY KEY(ID)
)
GO
CREATE TABLE LUOT_LIKE
(
	ID				INT					IDENTITY(1,1),
	ID_KHACHHANG	INT					NOT NULL,
	ID_DONGHO		INT					NOT NULL,
	TRANGTHAI		BIT						NULL,
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_KHACHHANG) REFERENCES KHACH_HANG(ID) ON DELETE CASCADE,
	FOREIGN KEY(ID_DONGHO) REFERENCES DONG_HO(ID) ON DELETE CASCADE
)
GO
CREATE TABLE DON_HANG
(
	ID				INT					IDENTITY(1,1),
	SO_DH			VARCHAR(14)			NOT NULL,
	ID_KHACHHANG	INT						NULL,
	TONGTIEN		INT					NOT NULL,
	GHICHU			TEXT					NULL,
	DUYET			BIT					DEFAULT 0,
	NGAYDAT			DATE					NULL,
	NGAYGIAO		DATE					NULL,
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_KHACHHANG) REFERENCES KHACH_HANG(ID) ON DELETE CASCADE
)
GO
CREATE TABLE DAT_HANG
(
	ID				INT					IDENTITY(1,1),
	ID_DONGHO		INT					NOT NULL,
	ID_DONHANG		INT					NOT NULL,
	SOLUONG			INT					NOT NULL,
	DONGIA			INT				NOT NULL,
	GIAGIAM			INT				NOT NULL,
	THANHTIEN		INT				NOT NULL,
	PRIMARY KEY(ID),
	FOREIGN KEY(ID_DONGHO) REFERENCES DONG_HO(ID) ON DELETE CASCADE,
	FOREIGN KEY(ID_DONHANG) REFERENCES DON_HANG(ID) ON DELETE CASCADE
)
GO
SET DATEFORMAT DMY
GO
INSERT INTO NGUOI_DUNG VALUES('admin','admin',N'Phạm Thị Bảo Phương','15/12/1993',N'346/B4 Phan Văn Trị, P.13, Q.Bình Thạnh, TPHCM','0924645654',1,1)
INSERT INTO NGUOI_DUNG VALUES('nhanvien1','nhanvien1',N'Đặng Ngọc Sơn','23/05/1994',N'112/5A Trần Quý Cáp, P.7, Q.Bình Thạnh, TPHCM','0924645644',1,0)
INSERT INTO NGUOI_DUNG VALUES('nhanvien2','nhanvien2',N'Võ Đông Hà','08/08/1995',N'353/1 Nguyễn Văn Đậu, P.3, Q.Bình Thạnh, TPHCM','092565655',1,0)
GO
INSERT INTO QUYEN_LOI VALUES('ThemSP',N'Thêm sản phẩm')
INSERT INTO QUYEN_LOI VALUES('SửaSP',N'Sửa sản phẩm')
INSERT INTO QUYEN_LOI VALUES('XóaSP',N'Xóa sản phẩm')
INSERT INTO QUYEN_LOI VALUES('ThemNH',N'Thêm hãng')
INSERT INTO QUYEN_LOI VALUES('SuaNH',N'Sửa hãng')
INSERT INTO QUYEN_LOI VALUES('XoaNH',N'Xóa hãng')
INSERT INTO QUYEN_LOI VALUES('ThemKM',N'Thêm kiểu máy')
INSERT INTO QUYEN_LOI VALUES('SuaKM',N'Sửa kiểu máy')
INSERT INTO QUYEN_LOI VALUES('XoaKM',N'Xóa kiểu máy')
INSERT INTO QUYEN_LOI VALUES('ThemBV',N'Thêm bài viết')
INSERT INTO QUYEN_LOI VALUES('SuaBV',N'Sửa bài viết')
INSERT INTO QUYEN_LOI VALUES('XoaBV',N'Xóa bài viết')
INSERT INTO QUYEN_LOI VALUES('ThemNV',N'Thêm nhân viên')
INSERT INTO QUYEN_LOI VALUES('SuaNV',N'Sửa nhân viên')
INSERT INTO QUYEN_LOI VALUES('XoaNV',N'Xóa nhân viên')
INSERT INTO QUYEN_LOI VALUES('ThemSL',N'Thêm slide')
INSERT INTO QUYEN_LOI VALUES('SuaSL',N'Sửa slide')
INSERT INTO QUYEN_LOI VALUES('XoaSL',N'Xóa slide')
INSERT INTO QUYEN_LOI VALUES('SuaDH',N'Sửa đơn hàng')
INSERT INTO QUYEN_LOI VALUES('XoaDH',N'Xóa đơn hàng')
GO
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'50 thương hiệu đồng hồ thế giới','\Static\Storage\News\tt1.jpg','15/3/2019','TT',2)
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'Bộ sưu tập đồng hồ mới và chất','\Static\Storage\News\tt2.jpg','21/4/2019','TT',3)
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'Bộ sưu tập đeo là hợp','\Static\Storage\News\tt3.jpg','10/3/2019','TT',1)
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'Quà tặng kỷ niệm ngày cưới','\Static\Storage\News\qt1.jpg','1/4/2019','QT',3)
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'Món quà dành cho phụ nữ','\Static\Storage\News\qt2.jpg','20/10/2018','QT',2)
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'Chỉnh máy tránh hư hỏng động cơ','\Static\Storage\News\hd1.jpg','26/4/2019','HD',2)
INSERT INTO BAI_VIET(TEN,HINH,NGAYDANG,LOAITIN,ID_NGUOIDUNG) VALUES(N'Nên lựa chọn Citizen hay Seiko?','\Static\Storage\News\hd2.jpg','13/02/2019','HD',3)
GO
INSERT INTO SLIDE(HINH,LOGAN) VALUES ('\Static\Storage\Slide\banner1.jpg',N'Sang trọng, độc đáo')
INSERT INTO SLIDE(HINH,LOGAN) VALUES ('\Static\Storage\Slide\banner2.jpg',N'Mạnh mẽ, cuốn hút')
INSERT INTO SLIDE(HINH,LOGAN) VALUES ('\Static\Storage\Slide\banner3.jpg',N'Đơn giản, tinh tế')
GO
INSERT INTO HANG_SX(LOGO,TEN,GIOITHIEU) VALUES ('\Static\Storage\Brand\logoCitizen.jpg','Citizen',N'Đồng hồ Citizen Eco-Drive là công nghệ hấp thụ ánh sáng từ bất cứ đâu để chuyển hóa thành điện năng, thậm chí là đèn huỳnh quang hay ánh nến. Sử dụng năng lượng ánh sáng không còn xa lạ trong thời đại công nghệ hiện nay. Nhưng khi các hãng khác còn loay hoay với pin mặt trời thì Citizen đã tiên phong trong việc sử dụng ánh sáng nhân tạo. Đột phá này giúp bạn quẳng gánh lo hết pin, hết năng lượng dù có tới bất kỳ nơi đâu.')
INSERT INTO HANG_SX(LOGO,TEN,GIOITHIEU) VALUES ('\Static\Storage\Brand\logoFossil.jpg','Fossil',N'Là một tập đoàn chuyên sản xuất và thiết kế đồng hồ, phụ kiện thời trang, trang sức của Mỹ đặt trụ sở ở Texas. Bằng cách hợp tác với các nhà sản xuất bộ máy Nhật Bản, Thụy Sĩ,… Fossil thiết kế – sản xuất đồng hồ mang hiệu của riêng mình và cho rất nhiều thương hiệu khác.')
INSERT INTO HANG_SX(LOGO,TEN,GIOITHIEU) VALUES ('\Static\Storage\Brand\logoOmega.jpg','Omega',N'Omega là một trong những thương hiệu đồng hồ lớn nhất Thuỵ Sĩ, với bề dày kinh nghiệm hơn cả 100 năm. Omega ngày càng khẳng định được vị trí cũng như thương hiệu của mình từ những chiếc đồng hồ sang trọng chất lượng tốt và mẫu mã thiết kế vô cùng tinh xảo.')
INSERT INTO HANG_SX(LOGO,TEN,GIOITHIEU) VALUES ('\Static\Storage\Brand\logoRolex.jpg','Rolex',N'Câu chuyện của Rolex bắt đầu khi nhà sáng lập Hans Wilsdorf đã tạo ra chiếc đồng hồ đeo tay chống thấm nước đầu tiên - Oyster - và đã phát triển một bộ sưu tập những chiếc đồng hồ đã trở thành biểu tượng của quy trình công nghệ chế tác đồng hồ.')
INSERT INTO HANG_SX(LOGO,TEN,GIOITHIEU) VALUES ('\Static\Storage\Brand\logoSeiko.jpg','Seiko',N'Đồng hồ Seiko nam quartz, Automatic đa dạng phong cách và thiết kế. Mua đồng hồ Seiko chính hãng với giá từ 3 triệu đồng tại Xwatch, phân khúc bình dân đến cao cấp cho bạn thỏa sức lựa chọn. Đồng hồ Seiko - Thương hiệu đồng hồ số 1 Nhật Bản!')
INSERT INTO HANG_SX(LOGO,TEN,GIOITHIEU) VALUES ('\Static\Storage\Brand\logoTissot.jpg','Tissot',N'Tissot là thương hiệu đồng hồ sang trọng nổi tiếng tại Thụy Sỹ, doanh số bán hàng của đồng hồ Tissot đạt đến con số “khổng lồ” và luôn đứng top đầu của tập đoàn Swatch Group. Tại Việt Nam, đồng hồ Tissot nói chung và dòng đồng hồ Tissot 1853 chính hãng nói riêng là niềm mơ ước của rất nhiều khách hàng. Nét đặc trưng của đồng hồ Tissot chính là sự pha lẫn giữa cổ điển và hiện đại, đã tạo nên những mẫu đồng hồ Tissot nam sang trọng, mạnh mẽ và đồng hồ Tissot nữ thanh lịch, cuốn hút.')
GO
INSERT INTO KIEU_MAY(TEN) VALUES ('Automatic')
INSERT INTO KIEU_MAY(TEN) VALUES ('Eco-Drive')
INSERT INTO KIEU_MAY(TEN) VALUES ('Quartz')
GO
INSERT INTO DONG_HO VALUES ('BL5551-06L',43,12,N'Titanium',N'Dây da',N'Sapphire',100,N'1 năm',10125000,'15/4/2019',0,1,2,1)
INSERT INTO DONG_HO VALUES ('BU2055-08X',43,12,N'Thép không gỉ',N'Dây vải',N'Sapphire',100,N'1 năm',6280000,'2/4/2019',2,1,2,0)
INSERT INTO DONG_HO VALUES ('ES3838',43,12,N'Titanium',N'Dau da',N'Sapphire',100,N'1 năm',15125000,'23/4/2019',0,2,2,1)
INSERT INTO DONG_HO VALUES ('FS4735',44,10,N'Thép không gỉ',N'Dây da',N'Sapphire',100,N'2 năm',3950000,'10/4/2019',3,2,3,0)
INSERT INTO DONG_HO VALUES ('212.30.41.20.01.003',41,12,N'Thép không gỉ',N'Thép không gỉ',N'Mặt kính cứng',300,N'2 năm',101956700,'28/4/2019',5,3,3,1)
INSERT INTO DONG_HO VALUES ('212.30.41.20.03.001',41,20,N'Thép không gỉ',N'Thép không gỉ',N'Sapphire',300,N'2 năm',111190000,'21/3/2019',3,3,1,0)
INSERT INTO DONG_HO VALUES ('116900BKAO',40,12,N'Thép không gỉ',N'Thép không gỉ',N'Mặt kính cứng',100,N'2 năm',145592700,'22/4/2019',0,4,1,1)
INSERT INTO DONG_HO VALUES ('126300BLS0',40,12,N'Thép không gỉ',N'Thép không gỉ',N'Sapphire',100,N'2 năm',194780700,'20/2/2019',3,4,1,0)
INSERT INTO DONG_HO VALUES ('SNZH53',40,11,N'Thép không gỉ',N'Thép không gỉ',N'Sapphire',100,N'2 năm',6525700,'5/5/2019',0,5,1,1)
INSERT INTO DONG_HO VALUES ('SNZF15',40,11,N'Thép không gỉ',N'Thép không gỉ',N'Sapphire',100,N'2 năm',6925700,'5/4/2019',0,5,1,0)
INSERT INTO DONG_HO VALUES ('T006.407.16.033.00',43,12,N'Thép không gỉ',N'Dây da',N'Sapphire',100,N'2 năm',10425300,'8/5/2019',2,6,1,1)
INSERT INTO DONG_HO VALUES ('T086.408.11.056.00',43,12,N'Thép không gỉ',N'Thép không gỉ',N'Sapphire',100,N'2 năm',12455300,'12/3/2019',0,6,1,0)
GO
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Citizen\Citizen-1-1.jpg',1)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Citizen\Citizen-1-2.jpg',1)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Citizen\Citizen-1-3.jpg',1)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Citizen\Citizen-2-1.jpg',2)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Citizen\Citizen-2-2.jpg',2)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Citizen\Citizen-2-3.jpg',2)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Fossil\Fossil-1-1.jpg',3)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Fossil\Fossil-1-2.jpg',3)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Fossil\Fossil-1-3.jpg',3)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Fossil\Fossil-2-1.jpg',4)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Fossil\Fossil-2-2.jpg',4)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Fossil\Fossil-2-3.jpg',4)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Omega\Omega-1-1.jpg',5)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Omega\Omega-1-2.jpg',5)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Omega\Omega-1-3.jpg',5)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Omega\Omega-2-1.jpg',6)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Omega\Omega-2-2.jpg',6)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Omega\Omega-2-3.jpg',6)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Rolex\Rolex-1-1.jpg',7)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Rolex\Rolex-1-2.jpg',7)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Rolex\Rolex-1-3.jpg',7)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Rolex\Rolex-2-1.jpg',8)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Rolex\Rolex-2-2.jpg',8)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Rolex\Rolex-2-3.jpg',8)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Seiko\Seiko-1-1.jpg',9)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Seiko\Seiko-1-2.jpg',9)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Seiko\Seiko-1-3.jpg',9)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Seiko\Seiko-2-1.jpg',10)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Seiko\Seiko-2-2.jpg',10)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Seiko\Seiko-2-3.jpg',10)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Tissot\Tissot-1-1.jpg',11)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Tissot\Tissot-1-2.jpg',11)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Tissot\Tissot-1-3.jpg',11)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Tissot\Tissot-2-1.jpg',12)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Tissot\Tissot-2-2.jpg',12)
INSERT INTO HINH_ANH VALUES ('\Static\Storage\Tissot\Tissot-2-3.jpg',12)
GO


