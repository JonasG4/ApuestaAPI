CREATE DATABASE db_apuestas;

USE db_apuestas;

CREATE TABLE Usuarios(
Id int primary key NOT NULL IDENTITY(1,1),
Nombre varchar(100) NOT NULL,
Apellido varchar(100) NOT NULL,
Telefono varchar(9) NOT NULL,
CorreoElectronico varchar(200) UNIQUE NOT NULL,
Dui varchar(10) UNIQUE NOT NULL,
CreadoEn datetime DEFAULT GetDate(),
ModificadoEn datetime,
)

CREATE TABLE  Productos(
Id INT primary key NOT NULL IDENTITY(1,1),
Nombre varchar(150) NOT NULL,
Descripcion varchar(200) NOT NULL,
Precio money NOT NULL,
Anio int NOT NULL,
CreadoEn datetime DEFAULT GetDate(),
ModificadoEn datetime
)

CREATE TABLE Subastas(
Id INT primary key IDENTITY(1,1) NOT NULL,
ProductoId int,
FechaInicio datetime NOT NULL,
FechaFin datetime NOT NULL,
Estado varchar(10) NOT NULL CHECK (Estado in ('ABIERTA', 'CERRADA')),

CONSTRAINT FK_ProductoSubasta FOREIGN KEY(ProductoId) REFERENCES Productos(Id)
)

CREATE TABLE  PujasSubasta(
Id int primary key IDENTITY(1,1) NOT NULL,
UsuarioId int,
SubastaId int,
Cantidad money,
Fecha datetime NOT NULL DEFAULT GetDate(),

CONSTRAINT FK_UsuarioPujas FOREIGN KEY(UsuarioId) REFERENCES Usuarios(Id),
CONSTRAINT FK_SubastaPujas FOREIGN KEY(SubastaId) REFERENCES Subastas(Id)
)