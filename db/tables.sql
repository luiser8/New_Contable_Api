CREATE TABLE PeriodosContables
(
    IdPeriodoContable INT IDENTITY(1,1) NOT NULL,
	Inicio DATETIME NOT NULL,
	Fin DATETIME NOT NULL,
	Descripcion varchar(255) NOT NULL UNIQUE,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_PeriodosContables PRIMARY KEY CLUSTERED (IdPeriodoContable ASC) ON [PRIMARY]
)

CREATE TABLE Monedas
(
    IdMoneda INT IDENTITY(1,1) NOT NULL,
	Simbolo VARCHAR(15) NOT NULL UNIQUE,
	Descripcion VARCHAR(255) NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_Monedas PRIMARY KEY CLUSTERED (IdMoneda ASC) ON [PRIMARY]
)

CREATE TABLE CentroCostos
(
    IdCentroCosto INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(255) NOT NULL UNIQUE,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_CentroCosto PRIMARY KEY CLUSTERED (IdCentroCosto ASC) ON [PRIMARY]
)

CREATE TABLE PlanCuentas
(
    IdPlanCuenta INT IDENTITY(1,1) NOT NULL,
    Codigo VARCHAR(115) NOT NULL UNIQUE,
	Descripcion VARCHAR(255) NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_PlanCuentas PRIMARY KEY CLUSTERED (IdPlanCuenta ASC) ON [PRIMARY]
)

CREATE TABLE AsientosContables
(
    IdAsiento INT IDENTITY(1,1) NOT NULL,
	IdPeriodoContable INT NOT NULL,
	FechaAsiento DATETIME NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_AsientosContables PRIMARY KEY CLUSTERED (IdAsiento ASC) ON [PRIMARY],
	FOREIGN KEY (IdPeriodoContable) REFERENCES PeriodosContables(IdPeriodoContable)
)

CREATE TABLE AsientosContablesDetalles
(
    IdAsientoDetalle INT IDENTITY(1,1) NOT NULL,
	IdAsiento INT NOT NULL,
    IdPlanCuenta INT NOT NULL,
    IdCentroCosto INT NOT NULL,
	IdMoneda INT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    Tipo TINYINT NOT NULL, --Credito 1 / debito 2
    Debe DECIMAL(19,2) NULL,
    Haber DECIMAL(19,2) NULL,
    Referencia VARCHAR(255) NULL,
	FechaAsientoDetalle DATETIME NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_AsientosContablesDetalles PRIMARY KEY CLUSTERED (IdAsientoDetalle ASC) ON [PRIMARY],
	FOREIGN KEY (IdAsiento) REFERENCES AsientosContables(IdAsiento),
	FOREIGN KEY (IdPlanCuenta) REFERENCES PlanCuentas(IdPlanCuenta),
	FOREIGN KEY (IdCentroCosto) REFERENCES CentroCostos(IdCentroCosto),
	FOREIGN KEY (IdMoneda) REFERENCES Monedas(IdMoneda)
)

CREATE TABLE Usuarios
(
    IdUsuario INT IDENTITY(1,1) NOT NULL,
    Nombres VARCHAR(155) NOT NULL  ,
    Apellidos VARCHAR(155) NOT NULL  ,
    Correo VARCHAR(155) NOT NULL UNIQUE ,
    CuentaLocal VARCHAR(155) NOT NULL UNIQUE ,
    Contrasena VARCHAR(255) NOT NULL  ,
    TokenAcceso NTEXT NULL  ,
    TokenRefresco NTEXT NULL  ,
    TokenCreado DATETIME NULL ,
    TokenExpiracion DATETIME NULL ,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (IdUsuario ASC) ON [PRIMARY]
)

CREATE TABLE Roles
(
    IdRol INT IDENTITY(1,1) NOT NULL,
    Codigo VARCHAR(255) NOT NULL UNIQUE,
	Descripcion VARCHAR(255) NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (IdRol ASC) ON [PRIMARY]
)

CREATE TABLE Politica
(
    IdPolitica INT IDENTITY(1,1) NOT NULL,
    Codigo VARCHAR(255) NOT NULL UNIQUE,
	Descripcion VARCHAR(255) NOT NULL,
    Ruta VARCHAR(155) NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_Politica PRIMARY KEY CLUSTERED (IdPolitica ASC) ON [PRIMARY]
)

CREATE TABLE RolPoliticas
(
    IdRolPolitica INT IDENTITY(1,1) NOT NULL,
    IdRol INT NOT NULL,
    IdPolitica INT NOT NULL,
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_RolPolitica PRIMARY KEY CLUSTERED (IdRolPolitica ASC) ON [PRIMARY],
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
    FOREIGN KEY (IdPolitica) REFERENCES Politica(IdPolitica)
)

CREATE TABLE UsuarioRol
(
    IdUsuarioRol INT IDENTITY(1,1) NOT NULL,
    IdUsuario INT NOT NULL,
    IdRol INT NOT NULL,
	Activo BIT NOT NULL DEFAULT 1, -- 1= ACTIVO 0= INACTIVO
    CONSTRAINT PK_UsuarioRol PRIMARY KEY CLUSTERED (IdUsuarioRol ASC) ON [PRIMARY],
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
)

CREATE TABLE Auditoria
(
    IdAuditoria INT IDENTITY(1,1) NOT NULL,
    IdUsuario INT NOT NULL,
    Accion VARCHAR(15) NOT NULL,
    Tabla VARCHAR(25) NOT NULL,
    FechaSistema DATETIME NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT PK_Auditoria PRIMARY KEY CLUSTERED (IdAuditoria ASC) ON [PRIMARY],
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
)
