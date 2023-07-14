SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Usuarios_Select
	@IdUsuario INT = NULL,
    @CuentaLocal VARCHAR(155) = NULL,
	@Contrasena VARCHAR(255) = NULL,
    @Tipo TINYINT = NULL --1 todos, 2 por id, 3 login, 4 con rol, 5 con politicas
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @IdUsuario = 0 AND @Tipo = 1
				SELECT IdUsuario, Nombres, Apellidos, Correo, CuentaLocal, FechaSistema, Activo
					FROM Usuarios;
			IF @IdUsuario != 0 AND @Tipo = 2
				SELECT IdUsuario, Nombres, Apellidos, Correo, CuentaLocal, FechaSistema, Activo
					FROM Usuarios WHERE IdUsuario = @IdUsuario
			IF @Tipo = 3
            	SELECT IdUsuario, Nombres, Apellidos, Correo, CuentaLocal, TokenAcceso, TokenRefresco, TokenCreado, TokenExpiracion, FechaSistema, Activo
				FROM Usuarios
					WHERE CuentaLocal = @CuentaLocal AND Contrasena = @Contrasena
            IF @IdUsuario != 0 AND @Tipo = 4
				SELECT u.IdUsuario,
						ur.IdRol,
							r.Codigo AS CodRol, r.Descripcion AS DesRol, r.Activo AS ActRol
						FROM UsuarioRol ur
							INNER JOIN Usuarios u ON u.IdUsuario = ur.IdUsuario
							INNER JOIN Roles r ON r.IdRol = ur.IdRol
							WHERE u.IdUsuario = @IdUsuario
			IF @IdUsuario != 0 AND @Tipo = 5
					SELECT p.IdPolitica, p.Codigo AS CodPolitica,
						p.Descripcion AS DesPolitica, p.Ruta AS RutaPolitica,
						p.Activo AS ActPolitica
						FROM UsuarioRol ur
							INNER JOIN Usuarios u ON u.IdUsuario = ur.IdUsuario
							INNER JOIN Roles r ON r.IdRol = ur.IdRol
							INNER JOIN RolPoliticas rp ON rp.IdRol = ur.IdRol
							INNER JOIN Politica p ON p.IdPolitica = rp.IdPolitica
							WHERE u.IdUsuario = @IdUsuario
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END