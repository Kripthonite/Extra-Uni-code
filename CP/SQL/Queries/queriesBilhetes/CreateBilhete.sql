GO

CREATE PROCEDURE AddBilhete (@numcc VARCHAR(8), @partida VARCHAR(255), @chegada VARCHAR(255)) 
	
    
AS
BEGIN
	IF NOT EXISTS(
		SELECT * 
		FROM Passageiro
		WHERE Num_CC = @numcc)
		BEGIN
			PRINT 'No such Passenger'
		END
	ELSE
		BEGIN
			
			DECLARE @ID as int
			SET @ID= 
			(SELECT ID FROM Bilhete WHERE (EstaçãoPartida = @partida AND EstaçãoChegada = @chegada)); 
			INSERT INTO ViajaComBilhete VALUES(@ID ,@numcc)
		END
	
	
	
END

	
GO

--EXEC AddBilhete '12345678','Aveiro' , 'Ovar';
--SELECT * FROM ViajaComBilhete;
 --SELECT * FROM Bilhete;
 --SELECT TOP 1 Bilhete.ID  FROM Bilhete ORDER BY ID DESC 
