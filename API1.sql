/****** Object:  Database [API1]    Script Date: 27/1/2023 10:05:09 ******/
CREATE DATABASE API1;
use API1;

/****** Object:  Table [dbo].[persona]    Script Date: 27/1/2023 10:05:10 ******/
CREATE TABLE persona(
	id int primary key identity(1,1),
	nombre varchar(50) not null,
	edad int not null
)