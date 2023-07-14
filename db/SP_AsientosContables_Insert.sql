SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_AsientosContables_Insert
    @InsertOrder TINYINT = NULL, -- 1 asiento, 2 asientoDetalle
    --Asiento
	@IdPeriodoContable INT = NULL,
	@FechaAsiento VARCHAR(255) = NULL,
    --Asiento detalle
    @IdAsiento INT = NULL,
	@IdPlanCuenta INT = NULL,
	@IdCentroCosto INT = NULL,
	@IdMoneda INT = NULL,
	@Descripcion VARCHAR(255) = NULL,
    @Tipo TINYINT = NULL,
	@Debe DECIMAL = NULL,
	@Haber DECIMAL = NULL,
	@Referencia VARCHAR(155) = NULL,
	@FechaAsientoDetalle VARCHAR(255) = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		IF @IdPeriodoContable IS NOT NULL AND @FechaAsiento IS NOT NULL
            IF @InsertOrder = 1
                BEGIN
                    INSERT INTO AsientosContables(IdPeriodoContable, FechaAsiento)
                    VALUES(@IdPeriodoContable, CONVERT(DATETIME, @FechaAsiento, 103))
                    SELECT SCOPE_IDENTITY() AS IdAsiento;
                END
            IF @InsertOrder = 2
                IF @IdAsiento IS NOT NULL
                    BEGIN
                        INSERT INTO AsientosContablesDetalles
                            (IdAsiento, IdPlanCuenta, IdCentroCosto, IdMoneda, Descripcion, Tipo, Debe, Haber, Referencia, FechaAsientoDetalle)
                        VALUES(@IdAsiento, @IdPlanCuenta, @IdCentroCosto, @IdMoneda, @Descripcion, @Tipo, @Debe, @Haber, @Referencia, CONVERT(DATETIME, @FechaAsientoDetalle, 103))
                        SELECT SCOPE_IDENTITY() AS IdAsientoDetalle;
                    END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO