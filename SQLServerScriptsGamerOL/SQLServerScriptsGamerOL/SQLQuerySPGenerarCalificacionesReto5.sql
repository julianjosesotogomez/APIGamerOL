ALTER PROCEDURE GenerarCalificaciones
    @cantidad INT = 0,
    @CodigoError INT OUTPUT,
    @MensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    -- Validar si el valor ingresado en @cantidad es v�lido
    IF @cantidad <= 0
    BEGIN
        SET @CodigoError = 1
        SET @MensajeError = 'El valor ingresado en @cantidad no es v�lido.'
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
		SET @Nickname = LEFT(CONCAT(CHAR(65 + RAND() * 26), -- Letra aleatoria may�scula (A-Z)
									CHAR(97 + RAND() * 26), -- Letra aleatoria min�scula (a-z)
									CAST(RAND() * 10 AS INT), -- N�mero aleatorio de hasta 6 d�gitos
									CAST(RAND() * 10 AS INT), -- N�mero aleatorio de hasta 6 d�gitos
									CHAR(97 + RAND() * 26) -- Letra aleatoria min�scula (a-z)
							), 30);

        -- Generar aleatoriamente la Puntuaci�n entre 0 y 5 con m�ximo dos decimales
        DECLARE @Puntuacion DECIMAL(3, 2)
        SET @Puntuacion = ROUND(RAND() * 5, 2)

        -- Asignar aleatoriamente el identificador de alg�n videojuego existente
        DECLARE @VideojuegoId INT
        SET @VideojuegoId = ABS(CHECKSUM(NEWID())) % (SELECT MAX(Id) FROM Videojuegos) + 1

        -- Insertar la calificaci�n generada en la entidad Calificaciones
        INSERT INTO Calificaciones (Nickname, VideojuegoId, Puntuacion)
        VALUES (@Nickname, @VideojuegoId, @Puntuacion)

        SET @i = @i + 1
    END

    -- Retornar valores exitosos
    SET @CodigoError = 0
    SET @MensajeError = NULL
END