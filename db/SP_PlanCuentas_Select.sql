SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_PlanCuentas_Select
	@IdPlanCuenta INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @IdPlanCuenta = 0
				SELECT IdPlanCuenta, Codigo, Descripcion, FechaSistema, Activo FROM PlanCuentas
			IF @IdPlanCuenta != 0
				SELECT IdPlanCuenta, Codigo, Descripcion, FechaSistema, Activo FROM PlanCuentas
					WHERE IdPlanCuenta = @IdPlanCuenta
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
