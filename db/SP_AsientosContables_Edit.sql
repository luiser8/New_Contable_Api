SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_AsientosContables_Edit
    @UpdateOrder TINYINT = NULL, -- 1 asiento, 2 asientoDetalle
    --Asiento
	@IdAsiento INT = NULL,
	@IdPeriodoContable INT = NULL,
	@FechaAsiento VARCHAR(255) = NULL,
	@ActivoAsiento BIT = NULL,
    --AsientoDetalle
    @IdAsientoDetalle INT = NULL,
	@IdPlanCuenta INT = NULL,
	@IdCentroCosto INT = NULL,
	@IdMoneda INT = NULL,
	@Descripcion VARCHAR(255) = NULL,
    @Tipo TINYINT = NULL,
	@Debe DECIMAL = NULL,
	@Haber DECIMAL = NULL,
	@Referencia VARCHAR(155) = NULL,
	@FechaAsientoDetalle VARCHAR(255) = NULL,
    @ActivoAsientoDetalle BIT = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
            IF @UpdateOrder = 1
                IF @IdAsiento IS NOT NULL
                    BEGIN
                        SET NOCOUNT ON;
                            UPDATE AsientosContables SET IdPeriodoContable = ISNULL(@IdPeriodoContable, IdPeriodoContable),
                                FechaAsiento = ISNULL(CONVERT(DATETIME, @FechaAsiento, 103), FechaAsiento), Activo = ISNULL(@ActivoAsiento, Activo)
                            WHERE IdAsiento = @IdAsiento
                    END
            IF @UpdateOrder = 2
                IF @IdAsientoDetalle IS NOT NULL
                    BEGIN
                        SET NOCOUNT ON;
                            UPDATE AsientosContablesDetalles SET IdAsiento = ISNULL(@IdAsiento, IdAsiento),
                                IdPlanCuenta = ISNULL(@IdPlanCuenta, IdPlanCuenta), IdCentroCosto = ISNULL(@IdCentroCosto, IdCentroCosto),
                                IdMoneda = ISNULL(@IdMoneda, IdMoneda), Descripcion = ISNULL(@Descripcion, Descripcion), Tipo = ISNULL(@Tipo, Tipo),
                                Debe = ISNULL(@Debe, Debe), Haber = ISNULL(@Haber, Haber), Referencia = ISNULL(@Referencia, Referencia),
                                FechaAsientoDetalle = ISNULL(CONVERT(DATETIME, @FechaAsientoDetalle, 103), FechaAsientoDetalle), Activo = ISNULL(@ActivoAsientoDetalle, Activo)
                                    WHERE IdAsientoDetalle = @IdAsientoDetalle
                    END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO