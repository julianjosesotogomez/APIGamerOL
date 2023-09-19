--CONSULTAS

SELECT * FROM Calificaciones
SELECT * FROM VideoJuegos
SELECT * FROM Usuario

--STORED PROCEDURE

EXECUTE GenerarCalificaciones @cantidad = 30, @CodigoError = 0, @MensajeError = NULL


