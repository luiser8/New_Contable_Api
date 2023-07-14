SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_CentroCostos_Select
	@IdCentroCosto INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @IdCentroCosto = 0
				SELECT IdCentroCosto, Descripcion, FechaSistema, Activo FROM CentroCostos
			IF @IdCentroCosto != 0
				SELECT IdCentroCosto, Descripcion, FechaSistema, Activo FROM CentroCostos
					WHERE IdCentroCosto = @IdCentroCosto
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
