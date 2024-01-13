
GO

CREATE PROCEDURE CreateFunc (@idFunc int, @Func VARCHAR(50)) 
	
    
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM TipoFunc WHERE ID = @idFunc)
		BEGIN
			INSERT INTO TipoFunc
			VALUES (@idFunc , @Func)
		END
	ELSE
		BEGIN
			
			PRINT 'Ja existe cargo com esse id'
		END
	
	
END	
