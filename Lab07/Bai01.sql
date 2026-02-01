-- T?o Database
CREATE DATABASE [Net201_Lab07_Bai01];
GO
USE [Net201_Lab07_Bai01];
GO

-- T?o b?ng Students
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Email VARCHAR(100)
);
GO

-- Thêm m?t vài d? li?u m?u
INSERT INTO Students (FirstName, LastName, DateOfBirth, Email)
VALUES (N'Nguy?n', N'V?n A', '2000-01-01', 'vana@example.com');