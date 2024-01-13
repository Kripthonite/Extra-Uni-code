GO

CREATE PROCEDURE UpdateBilhete (@numcc VARCHAR(8), @partida VARCHAR(255), @chegada VARCHAR(255) , @idBilhete int) 
	
    
AS
BEGIN
	DELETE FROM ViajaComBilhete WHERE (ID_Bilhete = @idBilhete AND NUM_CC = @numcc)
	IF NOT EXISTS(
		SELECT * 
		FROM Passageiro
		WHERE Num_CC = @numcc)
		BEGIN
			PRINT 'No such Passenger'
		END
	ELSE
		BEGIN
			update Bilhete set EstaçãoChegada = @partida, EstaçãoPartida = @chegada where ID = @idBilhete
			INSERT INTO ViajaComBilhete VALUES(@idBilhete ,@numcc)
		END
	
	
	
END

	
GO