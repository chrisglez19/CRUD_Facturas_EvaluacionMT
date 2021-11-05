use FACTURA_EJEMPLO
GO
CREATE PROC sp_InsertPersonaFiscal
(
	@nombre VARCHAR(30), 
	@apellido  VARCHAR(30),
	@rfc VARCHAR(20),
	@razon_social  VARCHAR(30),
	@direccion  VARCHAR(30),
	@fecha_nacimiento  VARCHAR(30),
	@telefono  VARCHAR(10),
	@email  VARCHAR(30),
	@categoria  VARCHAR(30),
	@tipo_persona VARCHAR(10)
)

AS
BEGIN 
	

			INSERT INTO PersonaFiscal
				VALUES ( 
						@nombre, @apellido, @rfc , @razon_social,@direccion,@fecha_nacimiento ,@telefono ,@email ,@categoria ,@tipo_persona
						)
				
 
		SELECT 0
END
