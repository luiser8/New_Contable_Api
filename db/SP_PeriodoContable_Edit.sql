SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_PeriodoContable_Edit
	@IdPeriodoContable INT = NULL,
	@Inicio VARCHAR(155) = NULL,
    @Fin VARCHAR(155) = NULL,
	@Descripcion VARCHAR(255) = NULL,
	@Activo BIT = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		IF @IdPeriodoContable IS NOT NULL
			BEGIN
				SET NOCOUNT ON;
					UPDATE PeriodosContables SET
                        Inicio = ISNULL(CONVERT(DATETIME, @Inicio, 103), Inicio),
                        Fin = ISNULL(CONVERT(DATETIME, @Fin, 103), Fin),
						Descripcion = ISNULL(@Descripcion, Descripcion),
                        Activo = ISNULL(@Activo, Activo)
							WHERE IdPeriodoContable = @IdPeriodoContable
			END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO