DROP DATABASE IF EXISTS emprendimiento;
CREATE DATABASE emprendimiento;
------------------------------------------------------------------------------------------------
USE emprendimiento;
------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Producto;
CREATE TABLE Producto (

   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   CodigoProducto VARCHAR(50) UNIQUE NOT NULL,
   Nombre TEXT NOT NULL,
   Descripcion TEXT

);

SELECT * FROM Producto;

------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Proveedor;
CREATE TABLE Proveedor (

   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   CodigoProveedor TEXT NOT NULL,
   Nombre TEXT NOT NULL,
   Direccion TEXT NOT NULL,
   Contacto TEXT NOT NULL 

);

SELECT * FROM Proveedor;

------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Sucursal;
CREATE TABLE Sucursal (

   Id INT NOT NULL IDENTITY(1,1),
   CodigoSucursal VARCHAR(50) UNIQUE NOT NULL,
   Nombre TEXT NOT NULL,
   Ubicacion TEXT NOT NULL,
   PRIMARY KEY (Id)

);

SELECT * FROM Sucursal;

------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Bodega;
CREATE TABLE Bodega (

   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   CodigoBodega VARCHAR(50) UNIQUE NOT NULL,
   CodigoSucursal VARCHAR(50) NOT NULL,
   Nombre TEXT NOT NULL
   FOREIGN KEY (CodigoSucursal) REFERENCES Sucursal(CodigoSucursal)
);

SELECT * FROM Bodega;

------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Estante;
CREATE TABLE Estante (

   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   CodigoEstante VARCHAR(50) UNIQUE NOT NULL,
   CodigoBodega VARCHAR(50) NOT NULL,
   Nombre TEXT NOT NULL
   FOREIGN KEY (CodigoBodega) REFERENCES Bodega (CodigoBodega)
);

SELECT * FROM Estante;

------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Inventario;
CREATE TABLE Inventario (

   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   Nombre TEXT NOT NULL,
   CodigoEstante VARCHAR(50) NOT NULL,
   CodigoBodega VARCHAR(50) NOT NULL,
   CodigoProducto VARCHAR(50) NOT NULL,
   Cantidad INT DEFAULT 0 NOT NULL,
   Fecha  DATETIME,
   Estado TEXT,
   FOREIGN KEY (CodigoBodega) REFERENCES Bodega (CodigoBodega),
   FOREIGN KEY (CodigoProducto) REFERENCES Producto (CodigoProducto),
   FOREIGN KEY (CodigoEstante) REFERENCES Estante (CodigoEstante)

);

SELECT * FROM Inventario;

------------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS Auditorias;
CREATE TABLE Auditorias (

   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   Usuario VARCHAR(50) NOT NULL,
   Accion VARCHAR(50) NOT NULL,
   Fecha DATETIME NOT NULL

);

SELECT * FROM Auditorias;