use FACTURA_EJEMPLO
GO
CREATE PROC sp_EliminaFactura
(
	@idFactura INT
)

AS
BEGIN 
	

			DELETE FROM Detalle WHERE idFactura = @idFactura
			DELETE FROM Factura WHERE  idFactura= @idFactura
		
		SELECT 0
END
