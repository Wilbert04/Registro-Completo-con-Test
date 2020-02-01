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

CREATE TABLE Inscripcion
(
	InscripcionId int primary key identity,
	Fecha datetime,
	PersonaId int,
	Comentario varchar(30),
	Monto varchar(15),
	Balance varchar(15),
);

