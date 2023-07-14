SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_CentroCostos_Edit
	@IdCentroCosto INT = NULL,
	@Descripcion VARCHAR(255) = NULL,
	@Activo BIT = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		IF @IdCentroCosto IS NOT NULL
			BEGIN
				SET NOCOUNT ON;
					UPDATE CentroCostos SET
						Descripcion = ISNULL(@Descripcion, Descripcion),
                        Activo = ISNULL(@Activo, Activo)
							WHERE IdCentroCosto = @IdCentroCosto
			END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO