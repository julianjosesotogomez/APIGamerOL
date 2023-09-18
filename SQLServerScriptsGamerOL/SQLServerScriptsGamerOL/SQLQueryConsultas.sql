--CONSULTAS

SELECT * FROM Calificaciones
SELECT * FROM VideoJuegos

--STORED PROCEDURE

EXECUTE GenerarCalificaciones @cantidad = 1000000, @CodigoError = 0, @MensajeError = NULL


ALTER LOGIN sa
WITH PASSWORD = 'Blink3027@';