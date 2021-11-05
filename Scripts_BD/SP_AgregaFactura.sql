use FACTURA_EJEMPLO
go
alter PROC sp_AgregarFactura
(
	
	@idEmisor INT,
	@idReceptor INT,
	@idProducto INT,
	@cantidad INT,
	@precio DECIMAL

)

AS
Declare @idFactura INT
BEGIN 
	
			INSERT INTO Factura
				VALUES ( 
						@idEmisor ,@idReceptor,GETDATE(), NULL 
						)
			SET @idFactura = @@IDENTITY
			INSERT INTO Detalle
				VALUES (
						@idFactura, @idProducto, @cantidad, @precio
						)
		select 0
	
END

