
GO

CREATE PROCEDURE RemoveClient (@numcc VARCHAR(8))

    
AS
BEGIN
	DELETE FROM Passageiro
	WHERE Num_CC = @numcc;
END

	
GO

--EXEC RemoveClient '12345678';
--	SELECT * FROM Passageiro;
