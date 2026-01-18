create database Net201_Lab03_Bai01
go
use Net201_Lab03_Bai01
go
create table Products(
	Id int primary key,
	Name nvarchar(50),
	Color varchar(20),
	UnitPrice decimal,
	AvailableQuantity bit,
	CratedDate datetime);

insert into Products values
(1, N'Sản phẩm 1', 'Red', 100.5, 1, '2024-01-01'),
(2, N'Sản phẩm 2', 'Blue', 200.0, 0, '2024-02-15'),
(3, N'Sản phẩm 3', 'Green', 150.75, 1, '2024-03-10'),
(4, N'Sản phẩm 4', 'Yellow', 300.0, 1, '2024-04-05'),
(5, N'Sản phẩm 5', 'Black', 250.25, 0, '2024-05-20');