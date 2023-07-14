SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Auditoria_Insert
	@IdUsuario INT = NULL,
	@Accion VARCHAR(155) = NULL,
    @Tabla VARCHAR(155) = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		BEGIN
			INSERT INTO Auditoria(IdUsuario, Accion, Tabla)
			    VALUES(@IdUsuario, @Accion, @Tabla)
			        SELECT SCOPE_IDENTITY() AS IdAuditoria;
		END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO