CREATE DATABASE QuanLyYTe;
GO

USE QuanLyYTe;
GO

-- =========================
-- BẢNG CHỨC VỤ
-- =========================
CREATE TABLE Position (
    MaChucVu NVARCHAR(10) PRIMARY KEY,
    TenChucVu NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- BẢNG CA LÀM VIỆC
-- =========================
CREATE TABLE Shift (
    MaCaLamViec NVARCHAR(10) PRIMARY KEY,
    ThoiGianLamViec NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- BẢNG NHÂN VIÊN
-- =========================
CREATE TABLE Staff (
    MaNhanVien NVARCHAR(10) PRIMARY KEY,
    TenNhanVien NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    MaLoaiChucVu NVARCHAR(10),
    TaiKhoan NVARCHAR(50),
    MatKhau NVARCHAR(50),
    MaCaLamViec NVARCHAR(10),
    FOREIGN KEY (MaLoaiChucVu) REFERENCES Position(MaChucVu),
    FOREIGN KEY (MaCaLamViec) REFERENCES Shift(MaCaLamViec)
);
GO

-- =========================
-- BẢNG PHÒNG KHÁM
-- =========================
CREATE TABLE MedicalClinic (
    MaPhongKham NVARCHAR(10) PRIMARY KEY,
    TenPhongKham NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- BẢNG LOẠI KHÁM BỆNH
-- =========================
CREATE TABLE TypeOfExamination (
    MaLoaiKhamBenh NVARCHAR(10) PRIMARY KEY,
    TenLoaiKhamBenh NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- BẢNG LOẠI VẬT TƯ Y TẾ
-- =========================
CREATE TABLE TypeOfEquipment (
    MaLoaiVatTuYTE NVARCHAR(10) PRIMARY KEY,
    TenLoaiVatTuYTE NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- BẢNG VẬT TƯ Y TẾ
-- =========================
CREATE TABLE MedicalEquipment (
    MaVatTuYTE NVARCHAR(10) PRIMARY KEY,
    TenVatTuYTE NVARCHAR(100) NOT NULL,
    NgayNhap DATE,
    MaLoaiThietBi NVARCHAR(10),
    SoLuong INT,
    Gia DECIMAL(18, 2),
    FOREIGN KEY (MaLoaiThietBi) REFERENCES TypeOfEquipment(MaLoaiVatTuYTE)
);
GO

-- =========================
-- BẢNG BỆNH NHÂN
-- =========================
CREATE TABLE Patient (
    MaBenhNhan NVARCHAR(10) PRIMARY KEY,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    CanCuocCongDan NVARCHAR(20)
);
GO

-- =========================
-- BẢNG KHÁM BỆNH
-- =========================
CREATE TABLE MedicalExamination (
    MaKhamBenh NVARCHAR(10) PRIMARY KEY,
    MaNhanVien NVARCHAR(10),
    MaPhongKham NVARCHAR(10),
    MaLoaiKhamBenh NVARCHAR(10),
    MaBenhNhan NVARCHAR(10),
    NgayKham DATE,
    KetQua NVARCHAR(500),
    FOREIGN KEY (MaNhanVien) REFERENCES Staff(MaNhanVien),
    FOREIGN KEY (MaPhongKham) REFERENCES MedicalClinic(MaPhongKham),
    FOREIGN KEY (MaLoaiKhamBenh) REFERENCES TypeOfExamination(MaLoaiKhamBenh),
    FOREIGN KEY (MaBenhNhan) REFERENCES Patient(MaBenhNhan)
);
GO

-- BẢNG CHỨC VỤ
INSERT INTO Position (MaChucVu, TenChucVu) VALUES
('CV01', N'Bác sĩ'),
('CV02', N'Y tá'),
('CV03', N'Dược sĩ'),
('CV04', N'Kỹ thuật viên'),
('CV05', N'Lễ tân');
GO

--BẢNG CA LÀM VIỆC
INSERT INTO Shift (MaCaLamViec, ThoiGianLamViec) VALUES
('CA1', N'07:00 - 11:00'),
('CA2', N'11:00 - 15:00'),
('CA3', N'15:00 - 19:00'),
('CA4', N'19:00 - 23:00'),
('CA5', N'23:00 - 03:00');
GO


--BẢNG NHÂN VIÊN
INSERT INTO Staff (MaNhanVien, TenNhanVien, NgaySinh, DiaChi, MaLoaiChucVu, TaiKhoan, MatKhau, MaCaLamViec)
VALUES
('NV01', N'Nguyễn Văn A', '1990-01-12', N'Hà Nội', 'CV01', 'nva', '123456', 'CA1'),
('NV02', N'Trần Thị B', '1993-03-25', N'Hồ Chí Minh', 'CV02', 'ttb', '123456', 'CA2'),
('NV03', N'Lê Văn C', '1987-07-08', N'Đà Nẵng', 'CV03', 'lvc', '123456', 'CA3'),
('NV04', N'Phạm Thị D', '1995-11-19', N'Hà Nội', 'CV04', 'ptd', '123456', 'CA4'),
('NV05', N'Hoàng Minh E', '1999-06-15', N'Hải Phòng', 'CV05', 'hme', '123456', 'CA5');
GO


--BẢNG PHÒNG KHÁM
INSERT INTO MedicalClinic (MaPhongKham, TenPhongKham) VALUES
('PK01', N'Phòng khám nội tổng hợp'),
('PK02', N'Phòng khám nhi'),
('PK03', N'Phòng khám sản'),
('PK04', N'Phòng xét nghiệm'),
('PK05', N'Phòng cấp cứu');
GO


--BẢNG LOẠI KHÁM BỆNH
INSERT INTO TypeOfExamination (MaLoaiKhamBenh, TenLoaiKhamBenh) VALUES
('KB01', N'Khám tổng quát'),
('KB02', N'Khám tim mạch'),
('KB03', N'Khám tiêu hóa'),
('KB04', N'Khám mắt'),
('KB05', N'Khám da liễu');
GO


--BẢNG LOẠI VẬT TƯ Y TẾ
INSERT INTO TypeOfEquipment (MaLoaiVatTuYTE, TenLoaiVatTuYTE) VALUES
('VT01', N'Vật tư tiêu hao'),
('VT02', N'Dụng cụ y khoa'),
('VT03', N'Thiết bị phòng xét nghiệm'),
('VT04', N'Vật tư phẫu thuật'),
('VT05', N'Dụng cụ cấp cứu');
GO


--BẢNG VẬT TƯ Y TẾ
INSERT INTO MedicalEquipment (MaVatTuYTE, TenVatTuYTE, NgayNhap, MaLoaiThietBi, SoLuong, Gia)
VALUES
('ME01', N'Bông gạc y tế', '2024-01-10', 'VT01', 500, 50000),
('ME02', N'Ống nghe', '2024-02-15', 'VT02', 50, 250000),
('ME03', N'Máy xét nghiệm máu', '2024-03-21', 'VT03', 5, 150000000),
('ME04', N'Dao mổ', '2024-03-28', 'VT04', 200, 15000),
('ME05', N'Bộ sơ cứu', '2024-04-02', 'VT05', 100, 120000);
GO

--BẢNG BỆNH NHÂN
INSERT INTO Patient (MaBenhNhan, TenBenhNhan, NgaySinh, DiaChi, SoDienThoai, Email, CanCuocCongDan)
VALUES
('BN01', N'Nguyễn Thị Hoa', '1995-05-10', N'Hà Nội', '0901234567', 'hoa@gmail.com', '012345678901'),
('BN02', N'Lê Văn Nam', '1988-03-15', N'Hải Phòng', '0912345678', 'nam@gmail.com', '012345678902'),
('BN03', N'Trần Thị Lan', '2000-07-20', N'Hồ Chí Minh', '0923456789', 'lan@gmail.com', '012345678903'),
('BN04', N'Phạm Đức Huy', '1992-09-05', N'Đà Nẵng', '0934567890', 'huy@gmail.com', '012345678904'),
('BN05', N'Hoàng Minh Tuấn', '1985-12-30', N'Thanh Hóa', '0945678901', 'tuan@gmail.com', '012345678905');
GO


--BẢNG KHÁM BỆNH
INSERT INTO MedicalExamination (MaKhamBenh, MaNhanVien, MaPhongKham, MaLoaiKhamBenh, MaBenhNhan, NgayKham, KetQua)
VALUES
('KB001', 'NV01', 'PK01', 'KB01', 'BN01', '2024-05-01', N'Khỏe mạnh'),
('KB002', 'NV02', 'PK02', 'KB02', 'BN02', '2024-05-02', N'Rối loạn nhịp tim nhẹ'),
('KB003', 'NV03', 'PK03', 'KB03', 'BN03', '2024-05-03', N'Viêm dạ dày'),
('KB004', 'NV04', 'PK04', 'KB04', 'BN04', '2024-05-04', N'Cận thị 1 độ'),
('KB005', 'NV05', 'PK05', 'KB05', 'BN05', '2024-05-05', N'Viêm da cơ địa');
GO


Select * from Position
go

Select * from Shift
go

Select * from Staff
go

Select * from MedicalClinic
go

Select * from TypeOfExamination
go

Select * from TypeOfEquipment
go

Select * from MedicalEquipment
go

Select * from Patient
go

Select * from MedicalExamination
go
