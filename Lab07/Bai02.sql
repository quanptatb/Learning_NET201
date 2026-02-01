-- 1. Tạo Database
CREATE DATABASE Net201_Lab07_Bai02;
GO
USE Net201_Lab07_Bai02;
GO

-- 2. Tạo bảng Orders
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL
);
GO

-- 3. Tạo bảng OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
    ProductId INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL
);
GO

-- 4. Tạo Stored Procedures

-- 1. Tạo SP Thêm đơn hàng (Đây là cái bạn đang thiếu)
CREATE PROCEDURE sp_CreateOrder
    @OrderDate DATETIME,
    @CustomerName NVARCHAR(100),
    @TotalAmount DECIMAL(18,2),
    @ProductId INT,
    @ProductName NVARCHAR(100),
    @Quantity INT,
    @UnitPrice DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewOrderId INT;

    -- Thêm vào bảng Orders
    INSERT INTO Orders (OrderDate, CustomerName, TotalAmount)
    VALUES (@OrderDate, @CustomerName, @TotalAmount);

    -- Lấy ID vừa sinh ra
    SET @NewOrderId = SCOPE_IDENTITY();

    -- Thêm vào bảng OrderDetails
    INSERT INTO OrderDetails (OrderId, ProductId, ProductName, Quantity, UnitPrice)
    VALUES (@NewOrderId, @ProductId, @ProductName, @Quantity, @UnitPrice);
END;
GO

-- 2. Tạo SP Xóa đơn hàng (Chạy luôn để tránh lỗi khi bạn test nút Xóa)
CREATE PROCEDURE sp_DeleteOrder
    @OrderId INT
AS
BEGIN
    DELETE FROM OrderDetails WHERE OrderId = @OrderId;
    DELETE FROM Orders WHERE OrderId = @OrderId;
END;
GO

-- 3. Tạo SP Lấy danh sách (Cho trang Index)
CREATE PROCEDURE sp_GetOrders
AS
BEGIN
    SELECT * FROM Orders ORDER BY OrderDate DESC;
END;
GO

-- 4. Tạo SP Lấy chi tiết (Cho trang Details)
CREATE PROCEDURE sp_GetOrderDetails
    @OrderId INT
AS
BEGIN
    SELECT * FROM OrderDetails WHERE OrderId = @OrderId;
END;
GO