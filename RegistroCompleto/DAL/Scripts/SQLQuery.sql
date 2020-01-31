CREATE DATABASE RegistroPersonaDB
GO
USE RegistroPersonaDB
GO
CREATE TABLE Registro
(
	PersonaId int  primary key identity,
	Nombre varchar(30),
	Telefono varchar(13),
	Cedula varchar(13),
	Direccion varchar(max),
	FechaNacimiento datetime,

);

