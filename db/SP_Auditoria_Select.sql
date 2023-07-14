SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Auditoria_Select
	@IdAuditoria INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @IdAuditoria = 0
				SELECT IdAuditoria, IdUsuario, Accion, Tabla, FechaSistema FROM Auditoria
			IF @IdAuditoria != 0
				SELECT IdAuditoria, IdUsuario, Accion, Tabla, FechaSistema FROM Auditoria
					WHERE IdAuditoria = @IdAuditoria
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
