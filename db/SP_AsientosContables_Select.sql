SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_AsientosContables_Select
	@FechaDesde VARCHAR(155) = NULL,
	@FechaHasta VARCHAR(155) = NULL,
	@IdPeriodoContable INT = NULL,
	@Tipo TINYINT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @Tipo = 1
				SELECT
				   ACD.IdAsientoDetalle
				  ,AC.IdAsiento AS NroComprobante
				  ,AC.IdPeriodoContable
				  ,P.Descripcion AS PeriodoContable
				  ,ACD.IdPlanCuenta
				  ,PC.Codigo AS CodPlanCuenta
				  ,PC.Descripcion AS PlanCuenta
				  ,ACD.IdCentroCosto
				  ,CC.Descripcion AS CentroCosto
				  ,ACD.IdMoneda
				  ,M.Descripcion AS Moneda
				  ,ACD.Descripcion
                  ,ACD.Tipo
				  ,ACD.Debe
				  ,ACD.Haber
				  ,ACD.Referencia
				  ,AC.FechaAsiento
				  ,ACD.FechaAsientoDetalle
				  ,AC.FechaSistema
				  ,ACD.Activo AS AsientoActivo
					  FROM AsientosContables AC
						INNER JOIN AsientosContablesDetalles ACD ON AC.IdAsiento = ACD.IdAsiento
						INNER JOIN PeriodosContables P ON AC.IdPeriodoContable = P.IdPeriodoContable
						INNER JOIN PlanCuentas PC ON ACD.IdPlanCuenta = PC.IdPlanCuenta
						INNER JOIN CentroCostos CC ON ACD.IdCentroCosto = CC.IdCentroCosto
						INNER JOIN Monedas M ON ACD.IdMoneda = M.IdMoneda
						  WHERE AC.FechaAsiento BETWEEN CONVERT(DATETIME, @FechaDesde, 103)
								AND CONVERT(DATETIME, @FechaHasta, 103)
								AND AC.IdPeriodoContable = @IdPeriodoContable
							        ORDER BY AC.IdAsiento

			IF @Tipo = 2
				SELECT PC.Codigo AS CodCuenta, PC.Descripcion AS DescripcionCuenta,
				AC.IdAsiento AS NroComprobante, AC.IdPeriodoContable, P.Descripcion AS PeriodoContable,
				ACD.Descripcion AS DescripcionAsiento, ACD.FechaAsientoDetalle,
				SUM(ACD.Debe) AS TotalDebe, SUM(ACD.Haber) AS TotalHaber,
					SUM(ACD.Debe) - SUM(ACD.Haber) As Saldo,
						(SELECT SUM(Debe - Haber) FROM AsientosContablesDetalles WHERE IdPlanCuenta = ACD.IdPlanCuenta) AS SaldoTotal,
							AC.Activo AS AsientoActivo, ACD.Activo AS AsientoDetalleActivo
					FROM AsientosContablesDetalles ACD
						INNER JOIN AsientosContables AC ON AC.IdAsiento = ACD.IdAsiento
						INNER JOIN PeriodosContables P ON AC.IdPeriodoContable = P.IdPeriodoContable
						INNER JOIN PlanCuentas PC ON ACD.IdPlanCuenta = PC.IdPlanCuenta
						  WHERE AC.FechaAsiento BETWEEN CONVERT(DATETIME, @FechaDesde, 103)
								AND CONVERT(DATETIME, @FechaHasta, 103)
								AND AC.IdPeriodoContable = @IdPeriodoContable
							GROUP BY PC.Codigo, PC.Descripcion, AC.IdAsiento, AC.IdPeriodoContable, P.Descripcion, ACD.Descripcion, ACD.FechaAsientoDetalle,
							ACD.IdPlanCuenta, ACD.IdPlanCuenta, AC.Activo, ACD.Activo;

			IF @Tipo = 3
				SELECT ACD.IdPlanCuenta, PC.Codigo AS CodCuenta, PC.Descripcion AS DescripcionCuenta,
					SUM(ACD.Debe) - SUM(ACD.Haber) As Saldo, AC.Activo AS AsientoActivo
					FROM AsientosContablesDetalles ACD
						INNER JOIN AsientosContables AC ON AC.IdAsiento = ACD.IdAsiento
						INNER JOIN PeriodosContables P ON AC.IdPeriodoContable = P.IdPeriodoContable
						INNER JOIN PlanCuentas PC ON ACD.IdPlanCuenta = PC.IdPlanCuenta
						  WHERE AC.FechaAsiento BETWEEN CONVERT(DATETIME, @FechaDesde, 103)
								AND CONVERT(DATETIME, @FechaHasta, 103)
								AND AC.IdPeriodoContable = @IdPeriodoContable
							GROUP BY ACD.IdPlanCuenta, PC.Codigo, PC.Descripcion, AC.Activo;

		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END