create database Net201_Lab01
go
use Net201_Lab01
go
create table AccountUser(
	UserId int primary key,
	Username varchar(50),
	Email varchar(50),
	Password varchar(50)
);