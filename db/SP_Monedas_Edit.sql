SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Monedas_Edit
	@IdMoneda INT = NULL,
	@Simbolo VARCHAR(15) = NULL,
	@Descripcion VARCHAR(255) = NULL,
	@Activo BIT = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		IF @IdMoneda IS NOT NULL
			BEGIN
				SET NOCOUNT ON;
					UPDATE Monedas SET Simbolo = ISNULL(@Simbolo, Simbolo),
						Descripcion = ISNULL(@Descripcion, Descripcion), Activo = ISNULL(@Activo, Activo)
							WHERE IdMoneda = @IdMoneda
			END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO