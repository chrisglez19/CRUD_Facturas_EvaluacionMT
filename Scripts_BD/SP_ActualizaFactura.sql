use FACTURA_EJEMPLO
GO
CREATE PROC sp_ActualizaFactura
(
	@idFactura INT,
	@idEmisor INT,
	@idReceptor INT,
	@idProducto INT,
	@cantidad INT,
	@precio DECIMAL
	

)

AS
BEGIN 
	
			UPDATE Detalle SET idProducto = @idProducto, cantidad = @cantidad, precio = @precio	
			WHERE idFactura = @idFactura
			UPDATE Factura SET idEmisor = @idEmisor ,idReceptor =@idReceptor  
			WHERE idFactura= @idFactura 
		SELECT 0
END