--Creacion de la tabla VideoJuegos
CREATE TABLE Videojuegos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Compañia VARCHAR(255),
    AñoLanzamiento INT,
    Precio DECIMAL(10, 2),
    Puntaje DECIMAL(3, 2) DEFAULT 0,
    FechaActualizacion DATETIME,
    Usuario VARCHAR(255)
);

--Creacion de la tabla Calificaciones
CREATE TABLE Calificaciones (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nickname VARCHAR(255),
    VideojuegoId INT FOREIGN KEY REFERENCES Videojuegos(Id),
    Puntuacion DECIMAL(3, 2),
    FechaActualizacion DATETIME,
    Usuario VARCHAR(255)
);