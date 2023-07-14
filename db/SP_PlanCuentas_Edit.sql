SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_PlanCuentas_Edit
	@IdPlanCuenta INT = NULL,
	@Codigo VARCHAR(15) = NULL,
	@Descripcion VARCHAR(255) = NULL,
	@Activo BIT = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		IF @IdPlanCuenta IS NOT NULL
			BEGIN
				SET NOCOUNT ON;
					UPDATE PlanCuentas SET Codigo = ISNULL(@Codigo, Codigo),
						Descripcion = ISNULL(@Descripcion, Descripcion), Activo = ISNULL(@Activo, Activo)
							WHERE IdPlanCuenta = @IdPlanCuenta
			END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO