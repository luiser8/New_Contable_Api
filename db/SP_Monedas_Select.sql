SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Monedas_Select
	@IdMoneda INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @IdMoneda = 0
				SELECT IdMoneda, Simbolo, Descripcion, FechaSistema, Activo FROM Monedas
			IF @IdMoneda != 0
				SELECT IdMoneda, Simbolo, Descripcion, FechaSistema, Activo FROM Monedas
					WHERE IdMoneda = @IdMoneda
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
