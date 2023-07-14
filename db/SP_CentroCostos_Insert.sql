SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_CentroCostos_Insert
	@Descripcion VARCHAR(255) = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		BEGIN
			INSERT INTO CentroCostos(Descripcion)
			    VALUES(@Descripcion)
			        SELECT SCOPE_IDENTITY() AS IdCentroCosto;
		END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO