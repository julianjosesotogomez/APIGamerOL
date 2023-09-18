ALTER PROCEDURE GenerarCalificaciones
    @cantidad INT = 0,
    @CodigoError INT OUTPUT,
    @MensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    -- Validar si el valor ingresado en @cantidad es válido
    IF @cantidad <= 0
    BEGIN
        SET @CodigoError = 1
        SET @MensajeError = 'El valor ingresado en @cantidad no es válido.'
        RETURN
    END

    -- Variables locales
    DECLARE @i INT = 1

    -- Bucle para generar las calificaciones solicitadas
    WHILE @i <= @cantidad
    BEGIN
        -- Generar aleatoriamente el Nickname del jugador
        DECLARE @Nickname NVARCHAR(30)
        --SET @Nickname = LEFT(CAST(NEWID() AS NVARCHAR(30)), 30)
		SET @Nickname = LEFT(CONCAT(CHAR(65 + RAND() * 26), -- Letra aleatoria mayúscula (A-Z)
									CHAR(97 + RAND() * 26), -- Letra aleatoria minúscula (a-z)
									CAST(RAND() * 10 AS INT), -- Número aleatorio de hasta 6 dígitos
									CAST(RAND() * 10 AS INT), -- Número aleatorio de hasta 6 dígitos
									CHAR(97 + RAND() * 26) -- Letra aleatoria minúscula (a-z)
							), 30);

        -- Generar aleatoriamente la Puntuación entre 0 y 5 con máximo dos decimales
        DECLARE @Puntuacion DECIMAL(3, 2)
        SET @Puntuacion = ROUND(RAND() * 5, 2)

        -- Asignar aleatoriamente el identificador de algún videojuego existente
        DECLARE @VideojuegoId INT
        SET @VideojuegoId = ABS(CHECKSUM(NEWID())) % (SELECT MAX(Id) FROM Videojuegos) + 1

        -- Insertar la calificación generada en la entidad Calificaciones
        INSERT INTO Calificaciones (Nickname, VideojuegoId, Puntuacion)
        VALUES (@Nickname, @VideojuegoId, @Puntuacion)

        SET @i = @i + 1
    END

    -- Retornar valores exitosos
    SET @CodigoError = 0
    SET @MensajeError = NULL
END