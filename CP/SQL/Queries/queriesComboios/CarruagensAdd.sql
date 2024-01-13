GO

CREATE PROCEDURE AddCarruagem ( @comboioid int , @nlugares int) 

    
AS
BEGIN
	INSERT INTO Carruagem
	VALUES (@comboioid , @nlugares)
END

	
