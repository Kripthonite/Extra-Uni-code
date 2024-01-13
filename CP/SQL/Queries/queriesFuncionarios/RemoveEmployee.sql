GO

CREATE PROCEDURE RemoveEmployee (@id VARCHAR(8))

    
AS
BEGIN
	DELETE FROM Funcionário
	WHERE ID  = @id;
END

	
GO