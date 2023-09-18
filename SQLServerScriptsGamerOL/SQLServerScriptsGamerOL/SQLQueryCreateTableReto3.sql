--Creacion de la tabla Usuario
CREATE TABLE Usuario
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    NombreUsuario NVARCHAR(100),
    CorreoElectronico NVARCHAR(100),
    Contrasena NVARCHAR(100),
	FechaRegistro DATETIME,
);