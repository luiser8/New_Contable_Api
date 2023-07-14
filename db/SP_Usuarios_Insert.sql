SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE SP_Usuarios_Insert
	@Nombres VARCHAR(255) = NULL,
	@Apellidos VARCHAR(255) = NULL,
	@Correo VARCHAR(155) = NULL,
	@CuentaLocal VARCHAR(155) = NULL,
	@Contrasena VARCHAR(255) = NULL,
	@TokenAcceso NTEXT = NULL,
	@TokenRefresco NTEXT = NULL,
	@TokenCreado DATETIME = NULL,
	@TokenExpiracion DATETIME = NULL,
	--UsuarioRol
	@IdRol INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			DECLARE @SCOPEIDENTITY INT;
			INSERT INTO Usuarios (Nombres, Apellidos, Correo, CuentaLocal, Contrasena, TokenAcceso, TokenRefresco, TokenCreado, TokenExpiracion, FechaSistema, Activo)
			VALUES(@Nombres, @Apellidos, @Correo, @CuentaLocal, @Contrasena, @TokenAcceso, @TokenRefresco, @TokenCreado, @TokenExpiracion, getdate(), 1);
				SET @SCOPEIDENTITY = SCOPE_IDENTITY();
				IF @IdRol != 0
					INSERT INTO UsuarioRol(IdUsuario, IdRol)
						VALUES(@SCOPEIDENTITY, @IdRol);
							SELECT @SCOPEIDENTITY AS IdUsuario
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
