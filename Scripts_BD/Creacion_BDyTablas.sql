CREATE DATABASE FACTURA_EJEMPLO
GO
use FACTURA_EJEMPLO

CREATE TABLE PersonaFiscal(
	idPersona INT PRIMARY KEY IDENTITY NOT NULL,
	nombre VARCHAR(30) NOT NULL,
	apellido  VARCHAR(30) NOT NULL,
	rfc VARCHAR(20) NOT NULL,
	razon_social  VARCHAR(30) NOT NULL,
	direccion  VARCHAR(30) NOT NULL,
	fecha_nacimiento  VARCHAR(30) NOT NULL,
	telefono  VARCHAR(10) NOT NULL,
	email  VARCHAR(30) NOT NULL,
	categoria  VARCHAR(30) NOT NULL,
	tipo_persona VARCHAR(10) NOT NULL,
	)

CREATE TABLE Factura(
	idFactura INT PRIMARY KEY IDENTITY NOT NULL,
	idEmisor INT NOT NULL,
	idReceptor INT NOT NULL,
	fecha  DATE NOT NULL,
	facturaXML XML,
	CONSTRAINT FK_idEmisor FOREIGN KEY (idEmisor) REFERENCES PersonaFiscal(idPersona),
	CONSTRAINT FK_idReceptor FOREIGN KEY (idReceptor) REFERENCES PersonaFiscal(idPersona)
	)

CREATE TABLE Producto(
	idProducto INT PRIMARY KEY IDENTITY NOT NULL,
	nombre VARCHAR(30) NOT NULL,
	precio  DECIMAL NOT NULL,
	stock INT NOT NULL
	)

CREATE TABLE Detalle(
    idDetalle INT IDENTITY NOT NULL ,
	idFactura INT NOT NULL,
	idProducto INT NOT NULL,
	cantidad  INT NOT NULL,
	precio DECIMAL NOT NULL,
	PRIMARY KEY (idDetalle, idFactura),
	CONSTRAINT FK_idProducto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)
	)