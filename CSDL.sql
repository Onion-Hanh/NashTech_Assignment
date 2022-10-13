CREATE DATABASE QL_BANTHUOC
GO
USE QL_BANTHUOC
GO
CREATE TABLE CHUCVU
(
	MACHUCVU CHAR(6) NOT NULL,
	TENCHUCVU NVARCHAR(100),
	CONSTRAINT PK_CHUCVU PRIMARY KEY (MACHUCVU)
)
CREATE TABLE NHANVIEN
(
	MANV CHAR(6) NOT NULL,
	HOVATEN NVARCHAR(50),
	GIOITINH NVARCHAR(3),
	DIACHI NVARCHAR(200),
	EMAIL CHAR(50),
	SDT CHAR(10),
	HINHANH NVARCHAR(200),
	TAIKHOAN CHAR(20),
	MATKHAU CHAR(20),
	MACHUCVU CHAR(6),
	CONSTRAINT PK_NHANVIEN PRIMARY KEY (MANV),
	CONSTRAINT FK_NHANVIEN_CHUCVU FOREIGN KEY (MACHUCVU) REFERENCES CHUCVU(MACHUCVU)
)
CREATE TABLE LOAITHUOC
(
	MALT CHAR(6) NOT NULL,
	TENLT NVARCHAR(200),
	CONSTRAINT PK_DANHMUCTHUOC PRIMARY KEY (MALT)
)
CREATE TABLE THUOC
(
	MATHUOC CHAR(6) NOT NULL,
	TENTHUOC NVARCHAR(200),
	HAMLUONG CHAR(20),
	CONGDUNG NVARCHAR(200),
	MOTA NVARCHAR(200),
	HINHANH NVARCHAR(200),
	SOLUONG INT,
	GIANHAP FLOAT,
	GIABAN FLOAT,
	CREATEDDATE DATE,
	UPDATEDDATE DATE,
	MALT CHAR(6),
	CONSTRAINT PK_THUOC PRIMARY KEY (MATHUOC),
	CONSTRAINT FK_THUOC_LOAITHUOC FOREIGN KEY(MALT) REFERENCES LOAITHUOC(MALT)
)
CREATE TABLE KHACHHANG
(
	MAKH CHAR(6) NOT NULL,
	TENKH NVARCHAR(200),
	DIACHI NVARCHAR(200),
	SDT CHAR(10),
	GIOITINH NVARCHAR(3),
	MATKHAU CHAR(20),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY (MAKH)
)
/*Thêm dữ liệu*/
INSERT INTO CHUCVU
VALUES
('CV0001',N'Nhân viên kế toán'),
('CV0002',N'Nhân viên thiết kế'),
('CV0003',N'Quản lý'),
('CV0004',N'Admin')
INSERT INTO NHANVIEN
VALUES
('NV0001',N'Nguyễn Văn A',N'Nam',N'Bến Tre','A@gmail.com','0123456789','vana.png','vana','123','CV0001'),
('NV0002',N'Lê Thị B',N'Nữ',N'Bình Phước','B@gmail.com','0123456788','thib.png','thib','1234','CV0002'),
('NV0003',N'Trần Công C',N'Nam',N'Long An','C@gmail.com','0123456787','congc.png','congc','12345','CV0003'),
('NV0004',N'Huỳnh Ngọc D',N'Nữ',N'Quảng Ninh','D@gmail.com','0123456786','ngocd.png','ngocd','123456','CV0004')
INSERT INTO LOAITHUOC
VALUES
('LT0001',N'Thuốc tuần hoàn máu não'),
('LT0002',N'Thuốc kháng sinh, kháng virut'),
('LT0003',N'Thuốc giảm đau, kháng viêm'),
('LT0004',N'Thuốc đường tiêu hóa'),
('LT0005',N'Thuốc cầm máu'),
('LT0006',N'Dầu nóng, thuốc bôi - xịt ngoài da'),
('LT0007',N'Thuốc ho, long đờm'),
('LT0008',N'Thuốc bổ, vitamin và khoáng chất'),
('LT0009',N'Dung dịch sát trùng'),
('LT0010',N'Thuốc trị gút - xương khớp'),
('LT0011',N'Thuốc tim mạch'),
('LT0012',N'Thuốc giãn cơ'),
('LT0013',N'Thuốc gan mật'),
('LT0014',N'Thuốc da liễu'),
('LT0015',N'Thuốc chống dị ứng (Kháng Histamin)'),
('LT0016',N'Thuốc nhỏ mắt, tra mắt'),
('LT0017',N'Thuốc tai mũi họng')

SET DATEFORMAT DMY
INSERT INTO THUOC
VALUES
('TH0001', N'Thuốc trung hòa acid dạ dày Anticid','Calci carbonat 500mg', N'Tăng tiết acid dạ dày, ợ nóng, khó tiêu, ợ chua.',N'1 Lọ 500 viên','hinh1.png',1,400000,450000,'2020-08-12','2020-10-15','LT0004'),
('TH0002', N'Thuốc giảm đau, kháng viêm Cataflam','Diclofenac 25mg', N'Điều trị ngắn hạn các tình trạng cấp tính: đau sau chấn thương, viêm và sưng do bong gân, đau sau phẫu thuật, đau và/hoặc viêm trong phụ khoa như đau bụng kinh tiên phát hoặc viêm phần phụ',N'Hộp 10 viên','hinh2.png',2,35000,40000,'2019-03-05','2020-01-10','LT0003'),
('TH0003', N'Thuốc giảm đau, hạ sốt Panadol Extra','Cafein 65mg', N'Điều trị đau nhẹ đến vừa và hạ sốt: Đau đầu, đau cơ, đau bụng kinh, đau họng, đau cơ xương, sốt và đau sau khi tiêm vacxin, đau sau khi nhổ răng.',N'Hộp 5 vỉ, mỗi vỉ 10 viên','hinh3.png',3,200000,225000,'2018-09-20','2018-10-10','LT0003'),
('TH0004', N'Thuốc nhỏ mắt Osla chai','Natri 0.033g', N'Mỏi mắt, ngứa mắt, khô rát mắt, cay mắt, xốn (cộm) mắt, đỏ mắt, mờ mắt, chảy nước mắt, mắt khó chịu. Rửa mắt để loại các vật lạ, làm sạch ghèn rỉ mắt. Phòng ngừa các bệnh đau mắt. ',N'1 Hộp 1 chai','hinh19.png',4,10000,19000,'2021-12-05','2022-01-13','LT0016'),
('TH0005', N'Viên sủi bổ sung vitamin C','Kem 10mg', N'Dự phòng và điều trị thiếu hụt vitamin C và kẽm.',N'1 lọ 10 viên','hinh4.png',5,30000,44000,'2019-05-05','2019-07-17','LT0008'),
('TH0006', N'Hoạt huyết dưỡng não Traphaco','Cao kho 5mg', N'Phòng và điều trị các bệnh sau: suy giảm trí nhớ, căng thẳng thần kính, kém tập trung. Thiểu năng tuần hoàn não, hội chứng tiền đình: đau đầu, hoa mắt.',N'1 hộp 1 vỉ','hinh5.png',6,15000,23000,'2020-12-12','2020-04-12','LT0001'),
('TH0007', N'Thuốc chống co thắt cơ trơn No-Spa Forte','Drotaverin 80mg', N'Co thắt cơ trơn trong những bệnh lý đường mật. Co thắt cơ trơn trong những bệnh lý đường niệu. Co thắt cơ trơn hệ tiêu hoá. Đau bụng kinh',N'Hộp 2 vỉ, mỗi vỉ 10 viên.','hinh6.png',7,23000,30000,'2022-02-02','2022-05-07','LT0004'),
('TH0008', N'Kem bôi trị viêm da, nấm Stadgentri',' Gentamicin 10mg', N'Điều trị các bệnh về da có đáp ứng với corticosteroid khi có biến chứng nhiễm trùng do vi khuẩn (nhạy cảm với gentamicin) và nấm .',N'1 hộp 1 tuýp','hinh7.png',8,5000,9000,'2018-05-04','2018-10-11','LT0014'),
('TH0009', N'Thuốc cầm máu Transamin 500mg','Tranexamic 500mg', N'Điều trị xu hướng chảy máu được coi như liên quan tới tăng tiêu fibrin (bệnh bạch huyết, thiếu máu không tái tạo, ban xuất huyết, v.v, và chảy máu bất thường trong phẫu thuật.',N'Hộp 10 vỉ, mỗi vỉ 10 viên.','hinh8.png',9,360000,430000,'2020-11-11','2020-12-08','LT0005'),
('TH0010', N'Thuốc cầm máu Transamin 250mg','Tranexamic 250mg', N'Điều trị xu hướng chảy máu do tăng tiêu fibrin toàn thân trong những trường hợp sau: bệnh bạch cầu, thiếu máu bất sản, ban xuất huyết, chảy máu bất thường sau phẫu thuật.',N' Hộp 10 vỉ, mỗi vỉ 10 viên.','hinh9.png',10,200000,267000,'2019-08-20','2019-12-09','LT0005'),
('TH0011', N'Kem bôi giảm đau Neoticabalm ','Methyl Salicylate', N'Giảm đau, giảm sưng, kháng viêm trong chấn thương. Đau cơ, đau khớp, bong gân, tan máu bầm, vết chích do côn trùng gây ra, đau & mỏi cơ do hoạt động.',N'1 Hộp 1 Tuýp','hinh10.png',11,11000,18000,'2021-12-05','2021-12-30','LT0006'),
('TH0012', N'Thuốc xịt mũi trị viêm mũi, viêm xoang Otilin ','Xylometazolin 15mg', N'Viêm mũi cấp hoặc mạn tính, viêm xoang, cảm lạnh, cảm mạo hoặc dị ứng đường hô hấp trên, đau đầu hoặc viêm tai giữa cấp liên quan tới sung huyết mũi.',N'Hộp 1 lọ 15ml.','hinh11.png',12,12000,19000,'2019-05-23','2019-10-24','LT0017'),
('TH0013', N'Thuốc giảm đau, hạ sốt Acemol','Paracetamol 325mg', N'Hạ sốt và giảm đau trong các trường hợp: Cảm cúm, sốt, đau nhức.',N'Chai 40 viên','hinh12.png',13,7000,12000,'2019-10-10','2020-02-22','LT0003'),
('TH0014', N'Thuốc bổ sung canxi cho bé Calcium Corbiere ','Calci 0.550g', N'Thiếu canxi, có nhu cầu canxi cao, bổ sung canxi trong hỗ trợ mất canxi xương ở người lớn tuổi.',N'Hộp 3 vỉ, mỗi vỉ 10 ống, mỗi ống 5ml.','hinh13.png',14,100000,120000,'2020-04-26','2021-02-12','LT0008'),
('TH0015', N'Thuốc trị cao huyết áp, đau thắt ngực Betaloc Zok','Metoprolol 25mg', N'Điều trị tăng huyết áp, đau thắt ngực, loạn nhịp tim, suy tim cơ bản, rối loạn chức năng tim, phòng ngừa tử vong do tim và tái nhồi máu sau cơn nhồi máu cơ tim cấp.',N'Hộp 10 viên','hinh14.png',15,40000,48000,'2021-01-29','2021-10-28','LT0011'),
('TH0016', N'Dung dịch sát khuẩn Povidine','Povidon iodin 10g', N'Sát khuẩn để giúp ngăn ngừa nhiễm khuẩn ở vết cắt, vết trầy và vết bỏng nhỏ. Sát khuẩn da trước khi phẫu thuật.Giúp giảm các vi khuẩn có khả năng gây nhiễm trùng da.',N'Hộp 1 Chai 8ml.','hinh15.png',16,2000,6000,'2022-05-05','2022-08-05','LT0009'),
('TH0017', N'Thuốc giãn cơ Pharmaclofen','Baclofen 10mg', N'Giảm dấu hiệu và triệu chứng của tình trạng co cứng do đa xơ cứng, tổn thương tủy sống và các bệnh khác liên quan tủy sống.',N'Chai 100 viên','hinh16.png',17,250000,277000,'2020-11-20','2021-03-20','LT0012'),
('TH0018', N'Thuốc chống dị ứng Telfast HD','Fexofenadin 180mg', N'Điều trị Viêm mũi dị ứng ở người lớn và trẻ em từ 12 tuổi trở lên. Mày đay vô căn mạn tính: Thuốc làm giảm ngứa và số lượng dát mày đay một cách đáng kể.',N'Hộp 10 viên.','hinh17.png',18,60000,75000,'2021-09-09','2021-12-20','LT0015'),
('TH0019', N'Thuốc kháng sinh Curam','Amoxicilin 875mg', N'Nhiễm khuẩn xoang và tai giữa; nhiễm khuẩn đường hô hấp; nhiễm khuẩn đường tiết niệu; nhiễm khuẩn da và mô mềm; nhiễm khuẩn xương và khớp.',N'Hộp 10 viên.','hinh18.png',19,70000,90000,'2021-02-02','2021-12-12','LT0002')

INSERT INTO KHACHHANG
VALUES
('KH0001',N'Nguyễn Văn A',N'Thành phố Hồ Chí Minh','0916248855',N'Nam','123'),
('KH0002',N'Nguyễn Thị B',N'Thành phố Hồ Chí Minh','0916248854',N'Nữ','1234')

/*STORE PROCEDURE*/
CREATE PROCEDURE THUOCTHEOLOAI
(
	@MALT CHAR(6)
)
AS
BEGIN
SELECT MATHUOC, TENTHUOC, THUOC.MALT, TENLT
FROM THUOC INNER  JOIN LOAITHUOC ON THUOC.MALT=LOAITHUOC.MALT
WHERE THUOC.MALT=@MALT
END

EXEC THUOCTHEOLOAI 'LT0001'