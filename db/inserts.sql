INSERT INTO new_amigo_contable.dbo.Monedas
(Simbolo, Descripcion, FechaSistema, Activo)
VALUES
('VES', 'Bolivar', getdate(), 1),
('USD', 'Dolar', getdate(), 1);

INSERT INTO new_amigo_contable.dbo.Usuarios
(Nombres, Apellidos, Correo, CuentaLocal, Contrasena, TokenAcceso, TokenRefresco, TokenCreado, TokenExpiracion, FechaSistema, Activo)
VALUES
('Admin', 'Admin', 'admin@gmail.com', 'admin.user', '12345', 'TokenAcceso', 'TokenRefresco', getdate(), getdate(), getdate(), 1),
('Contador', 'Contador', 'contador@gmail.com', 'contador', '12345', 'TokenAcceso', 'TokenRefresco', getdate(), getdate(), getdate(), 1),
('Asientes', 'Contador', 'asistente.contador@gmail.com', 'asistente.contador', '12345', 'TokenAcceso', 'TokenRefresco', getdate(), getdate(), getdate(), 1)

INSERT INTO new_amigo_contable.dbo.Roles
(Codigo, Descripcion, FechaSistema, Activo)
VALUES
('ADMIN', 'Administrador', getdate(), 1),
('CONTADOR', 'Contador', getdate(), 1),
('ASISTENTE', 'Asistente contable', getdate(), 1)

INSERT INTO new_amigo_contable.dbo.Politica
(Codigo, Descripcion, Ruta, FechaSistema, Activo)
VALUES
('POL_ASIENTOS_CONTABLES', 'Asientos contables', '/asientos', getdate(), 1),
('POL_ASIENTOS_LIBRO_MAYOR', 'Libro mayor', '/libro_mayor', getdate(), 1),
('POL_ASIENTOS_BALANCE', 'Balance comprobación', '/balance', getdate(), 1),
('POL_CENTROS_COSTOS', 'Centros de costos', '/centro_costos', getdate(), 1),
('POL_PLAN_CUENTAS', 'Plan de cuentas', '/plan_cuentas', getdate(), 1),
('POL_USUARIOS', 'Usuarios', '/usuarios', getdate(), 1),
('POL_REPORTES', 'Reportes', '/reportes', getdate(), 1),
('POL_BANCOS', 'Bancos', '/bancos', getdate(), 1),
('POL_CONCILIACIONES', 'Conciliaciones', '/conciliaciones', getdate(), 1),
('POL_PERIODOS_CONTABLES', 'Período contables', '/periodos', getdate(), 1),
('POL_MONEDAS', 'Monedas', '/monedas', getdate(), 1),
('POL_AUDITORIA', 'Auditoria', '/auditoria', getdate(), 1)

INSERT INTO new_amigo_contable.dbo.RolPoliticas
(IdRol, IdPolitica, Activo)
VALUES
(1, 1, 1),
(1, 2, 1),
(1, 3, 1),
(1, 4, 1),
(1, 5, 1),
(1, 6, 1),
(1, 7, 1),
(1, 8, 1),
(1, 9, 1),
(1, 10, 1),
(1, 11, 1),
(1, 12, 1),
(2, 1, 1),
(2, 2, 1),
(2, 3, 1),
(2, 4, 1),
(2, 5, 1),
(2, 6, 1),
(2, 7, 1),
(2, 8, 1),
(2, 9, 1),
(2, 10, 1),
(2, 11, 1),
(3, 2, 1),
(3, 3, 1),
(3, 4, 1),
(3, 5, 1),
(3, 7, 1),
(3, 10, 1),
(3, 11, 1)

INSERT INTO new_amigo_contable.dbo.UsuarioRol
(IdUsuario, IdRol, Activo)
VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1)
