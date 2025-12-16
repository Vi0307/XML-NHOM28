-- Nếu chạy lại nhiều lần: xóa database trước
DROP DATABASE IF EXISTS `QuanLyYTe`;

CREATE DATABASE `QuanLyYTe` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `QuanLyYTe`;

-- =========================
-- BẢNG CHỨC VỤ
-- =========================
CREATE TABLE `Position` (
    `MaChucVu` VARCHAR(10) PRIMARY KEY,
    `TenChucVu` VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG CA LÀM VIỆC
-- =========================
CREATE TABLE `Shift` (
    `MaCaLamViec` VARCHAR(10) PRIMARY KEY,
    `ThoiGianLamViec` VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG NHÂN VIÊN
-- =========================
CREATE TABLE `Staff` (
    `MaNhanVien` VARCHAR(10) PRIMARY KEY,
    `TenNhanVien` VARCHAR(100) NOT NULL,
    `NgaySinh` DATE,
    `DiaChi` VARCHAR(200),
    `MaLoaiChucVu` VARCHAR(10),
    `TaiKhoan` VARCHAR(50),
    `MatKhau` VARCHAR(50),
    `MaCaLamViec` VARCHAR(10),
    -- tạo index trước khi đặt foreign key là tốt, MySQL tự tạo nếu chưa có
    INDEX `idx_staff_maLoaiChucVu` (`MaLoaiChucVu`),
    INDEX `idx_staff_maCaLamViec` (`MaCaLamViec`),
    CONSTRAINT `fk_staff_position` FOREIGN KEY (`MaLoaiChucVu`) REFERENCES `Position`(`MaChucVu`) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT `fk_staff_shift` FOREIGN KEY (`MaCaLamViec`) REFERENCES `Shift`(`MaCaLamViec`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG PHÒNG KHÁM
-- =========================
CREATE TABLE `MedicalClinic` (
    `MaPhongKham` VARCHAR(10) PRIMARY KEY,
    `TenPhongKham` VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG LOẠI KHÁM BỆNH
-- =========================
CREATE TABLE `TypeOfExamination` (
    `MaLoaiKhamBenh` VARCHAR(10) PRIMARY KEY,
    `TenLoaiKhamBenh` VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG LOẠI VẬT TƯ Y TẾ
-- =========================
CREATE TABLE `TypeOfEquipment` (
    `MaLoaiVatTuYTE` VARCHAR(10) PRIMARY KEY,
    `TenLoaiVatTuYTE` VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG VẬT TƯ Y TẾ
-- =========================
CREATE TABLE `MedicalEquipment` (
    `MaVatTuYTE` VARCHAR(10) PRIMARY KEY,
    `TenVatTuYTE` VARCHAR(100) NOT NULL,
    `NgayNhap` DATE,
    `MaLoaiThietBi` VARCHAR(10),
    `SoLuong` INT,
    `Gia` DECIMAL(18,2),
    INDEX `idx_med_maLoaiThietBi` (`MaLoaiThietBi`),
    CONSTRAINT `fk_medetype` FOREIGN KEY (`MaLoaiThietBi`) REFERENCES `TypeOfEquipment`(`MaLoaiVatTuYTE`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG BỆNH NHÂN
-- =========================
CREATE TABLE `Patient` (
    `MaBenhNhan` VARCHAR(10) PRIMARY KEY,
    `TenBenhNhan` VARCHAR(100) NOT NULL,
    `NgaySinh` DATE,
    `DiaChi` VARCHAR(200),
    `SoDienThoai` VARCHAR(15),
    `Email` VARCHAR(100),
    `CanCuocCongDan` VARCHAR(20)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- BẢNG KHÁM BỆNH
-- =========================
CREATE TABLE `MedicalExamination` (
    `MaKhamBenh` VARCHAR(10) PRIMARY KEY,
    `MaNhanVien` VARCHAR(10),
    `MaPhongKham` VARCHAR(10),
    `MaLoaiKhamBenh` VARCHAR(10),
    `MaBenhNhan` VARCHAR(10),
    `NgayKham` DATE,
    `KetQua` VARCHAR(500),
    INDEX `idx_me_NhanVien` (`MaNhanVien`),
    INDEX `idx_me_PhongKham` (`MaPhongKham`),
    INDEX `idx_me_LoaiKham` (`MaLoaiKhamBenh`),
    INDEX `idx_me_BenhNhan` (`MaBenhNhan`),
    CONSTRAINT `fk_me_staff` FOREIGN KEY (`MaNhanVien`) REFERENCES `Staff`(`MaNhanVien`) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT `fk_me_clinic` FOREIGN KEY (`MaPhongKham`) REFERENCES `MedicalClinic`(`MaPhongKham`) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT `fk_me_type` FOREIGN KEY (`MaLoaiKhamBenh`) REFERENCES `TypeOfExamination`(`MaLoaiKhamBenh`) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT `fk_me_patient` FOREIGN KEY (`MaBenhNhan`) REFERENCES `Patient`(`MaBenhNhan`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- =========================
-- DATA INSERT
-- =========================

INSERT INTO `Position` (`MaChucVu`, `TenChucVu`) VALUES
('CV01', 'Bác sĩ'),
('CV02', 'Y tá'),
('CV03', 'Dược sĩ'),
('CV04', 'Kỹ thuật viên'),
('CV05', 'Lễ tân');

INSERT INTO `Shift` (`MaCaLamViec`, `ThoiGianLamViec`) VALUES
('CA1', '07:00 - 11:00'),
('CA2', '11:00 - 15:00'),
('CA3', '15:00 - 19:00'),
('CA4', '19:00 - 23:00'),
('CA5', '23:00 - 03:00');

INSERT INTO `Staff` (`MaNhanVien`, `TenNhanVien`, `NgaySinh`, `DiaChi`, `MaLoaiChucVu`, `TaiKhoan`, `MatKhau`, `MaCaLamViec`) VALUES
('NV01', 'Nguyễn Văn A', '1990-01-12', 'Hà Nội', 'CV01', 'nva', '123456', 'CA1'),
('NV02', 'Trần Thị B', '1993-03-25', 'Hồ Chí Minh', 'CV02', 'ttb', '123456', 'CA2'),
('NV03', 'Lê Văn C', '1987-07-08', 'Đà Nẵng', 'CV03', 'lvc', '123456', 'CA3'),
('NV04', 'Phạm Thị D', '1995-11-19', 'Hà Nội', 'CV04', 'ptd', '123456', 'CA4'),
('NV05', 'Hoàng Minh E', '1999-06-15', 'Hải Phòng', 'CV05', 'hme', '123456', 'CA5');

INSERT INTO `MedicalClinic` (`MaPhongKham`, `TenPhongKham`) VALUES
('PK01', 'Phòng khám nội tổng hợp'),
('PK02', 'Phòng khám nhi'),
('PK03', 'Phòng khám sản'),
('PK04', 'Phòng xét nghiệm'),
('PK05', 'Phòng cấp cứu');

INSERT INTO `TypeOfExamination` (`MaLoaiKhamBenh`, `TenLoaiKhamBenh`) VALUES
('KB01', 'Khám tổng quát'),
('KB02', 'Khám tim mạch'),
('KB03', 'Khám tiêu hóa'),
('KB04', 'Khám mắt'),
('KB05', 'Khám da liễu');

INSERT INTO `TypeOfEquipment` (`MaLoaiVatTuYTE`, `TenLoaiVatTuYTE`) VALUES
('VT01', 'Vật tư tiêu hao'),
('VT02', 'Dụng cụ y khoa'),
('VT03', 'Thiết bị phòng xét nghiệm'),
('VT04', 'Vật tư phẫu thuật'),
('VT05', 'Dụng cụ cấp cứu');

INSERT INTO `MedicalEquipment` (`MaVatTuYTE`, `TenVatTuYTE`, `NgayNhap`, `MaLoaiThietBi`, `SoLuong`, `Gia`) VALUES
('ME01', 'Bông gạc y tế', '2024-01-10', 'VT01', 500, 50000),
('ME02', 'Ống nghe', '2024-02-15', 'VT02', 50, 250000),
('ME03', 'Máy xét nghiệm máu', '2024-03-21', 'VT03', 5, 150000000),
('ME04', 'Dao mổ', '2024-03-28', 'VT04', 200, 15000),
('ME05', 'Bộ sơ cứu', '2024-04-02', 'VT05', 100, 120000);

INSERT INTO `Patient` (`MaBenhNhan`, `TenBenhNhan`, `NgaySinh`, `DiaChi`, `SoDienThoai`, `Email`, `CanCuocCongDan`) VALUES
('BN01', 'Nguyễn Thị Hoa', '1995-05-10', 'Hà Nội', '0901234567', 'hoa@gmail.com', '012345678901'),
('BN02', 'Lê Văn Nam', '1988-03-15', 'Hải Phòng', '0912345678', 'nam@gmail.com', '012345678902'),
('BN03', 'Trần Thị Lan', '2000-07-20', 'Hồ Chí Minh', '0923456789', 'lan@gmail.com', '012345678903'),
('BN04', 'Phạm Đức Huy', '1992-09-05', 'Đà Nẵng', '0934567890', 'huy@gmail.com', '012345678904'),
('BN05', 'Hoàng Minh Tuấn', '1985-12-30', 'Thanh Hóa', '0945678901', 'tuan@gmail.com', '012345678905');

INSERT INTO `MedicalExamination` (`MaKhamBenh`, `MaNhanVien`, `MaPhongKham`, `MaLoaiKhamBenh`, `MaBenhNhan`, `NgayKham`, `KetQua`) VALUES
('KB001', 'NV01', 'PK01', 'KB01', 'BN01', '2024-05-01', 'Khỏe mạnh'),
('KB002', 'NV02', 'PK02', 'KB02', 'BN02', '2024-05-02', 'Rối loạn nhịp tim nhẹ'),
('KB003', 'NV03', 'PK03', 'KB03', 'BN03', '2024-05-03', 'Viêm dạ dày'),
('KB004', 'NV04', 'PK04', 'KB04', 'BN04', '2024-05-04', 'Cận thị 1 độ'),
('KB005', 'NV05', 'PK05', 'KB05', 'BN05', '2024-05-05', 'Viêm da cơ địa');

SELECT * FROM Position;
SELECT * FROM Shift;
SELECT * FROM Staff;
SELECT * FROM MedicalClinic;
SELECT * FROM TypeOfExamination;
SELECT * FROM TypeOfEquipment;
SELECT * FROM MedicalEquipment;
SELECT * FROM Patient;
SELECT * FROM MedicalExamination;
