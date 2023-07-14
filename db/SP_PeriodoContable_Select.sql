SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_PeriodoContable_Select
	@IdPeriodoContable INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @IdPeriodoContable = 0
				SELECT IdPeriodoContable, Inicio, Fin, Descripcion, FechaSistema, Activo FROM PeriodosContables
			IF @IdPeriodoContable != 0
				SELECT IdPeriodoContable, Inicio, Fin, Descripcion, FechaSistema, Activo FROM PeriodosContables
					WHERE IdPeriodoContable = @IdPeriodoContable
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
