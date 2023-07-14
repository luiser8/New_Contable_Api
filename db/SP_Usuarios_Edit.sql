SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Usuarios_Edit
	@IdUsuario INT = NULL,
	@Nombres VARCHAR(255) = NULL,
	@Apellidos VARCHAR(255) = NULL,
	@Correo VARCHAR(155) = NULL,
	@CuentaLocal VARCHAR(155) = NULL,
	@Contrasena VARCHAR(255) = NULL,
	@TokenAcceso NTEXT = NULL,
	@TokenRefresco NTEXT = NULL,
	@TokenCreado VARCHAR(255) = NULL,
	@TokenExpiracion VARCHAR(255) = NULL,
	@Activo BIT = NULL
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		IF @IdUsuario IS NOT NULL
			BEGIN
				SET NOCOUNT ON;
					UPDATE Usuarios SET Nombres = ISNULL(@Nombres, Nombres), Apellidos = ISNULL(@Apellidos, Apellidos), Correo = ISNULL(@Correo, Correo),
						CuentaLocal = ISNULL(@CuentaLocal, CuentaLocal), Contrasena = ISNULL(@Contrasena, Contrasena), TokenAcceso = ISNULL(@TokenAcceso, TokenAcceso),
                        TokenRefresco = ISNULL(@TokenRefresco, TokenRefresco), TokenCreado = ISNULL(CONVERT(DATETIME, @TokenCreado, 103), TokenCreado),
                        TokenExpiracion = ISNULL(CONVERT(DATETIME, @TokenExpiracion, 103), TokenExpiracion), Activo = ISNULL(@Activo, Activo)
							WHERE IdUsuario = @IdUsuario
			END
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
	END CATCH;
END
GO