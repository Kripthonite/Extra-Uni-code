GO
CREATE FUNCTION FindTicketsById (@id INT) RETURNS TABLE 
AS
    
	RETURN (SELECT   *
			FROM Bilhete
            where Bilhete.id =@id)
GO

--SELECT * FROM FindTicketsByID(1);