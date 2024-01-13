GO

CREATE PROCEDURE RemoveComboio (@id int)

    
AS
BEGIN
	DELETE FROM Comboio
	WHERE ID  = @id;
END

	
GO