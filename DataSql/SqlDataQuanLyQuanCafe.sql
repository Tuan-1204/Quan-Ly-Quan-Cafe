GO
USE QuanLyQuanCafe
GO


-- Bảng bàn ăn
CREATE TABLE TableFood (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    status NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- trống hoặc có người
);
GO

-- Bảng tài khoản
CREATE TABLE Account (
    UserName NVARCHAR(100) PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL DEFAULT N'TuanAnhFood',
    PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
    Type INT NOT NULL DEFAULT 0 -- 1: admin, 0: user
);
GO

-- Bảng danh mục món ăn
CREATE TABLE FoodCategory (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
);
GO  

-- Bảng món ăn
CREATE TABLE Food (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    idCategory INT NOT NULL,
    price FLOAT NOT NULL DEFAULT 0,
    FOREIGN KEY (idCategory) REFERENCES FoodCategory(id)
);
GO

-- Bảng hoá đơn
CREATE TABLE Bill (
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATETIME NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATETIME NULL,
    idTable INT NOT NULL,
    status INT NOT NULL DEFAULT 0, -- 1: đã thanh toán, 0: chưa thanh toán
    FOREIGN KEY (idTable) REFERENCES TableFood(id)
);
GO

-- Bảng chi tiết hoá đơn
CREATE TABLE BillInfo (
    id INT IDENTITY PRIMARY KEY,
    idBill INT NOT NULL,
    idFood INT NOT NULL,
    count INT NOT NULL DEFAULT 0,
    FOREIGN KEY (idBill) REFERENCES Bill(id),
    FOREIGN KEY (idFood) REFERENCES Food(id)
);
GO
