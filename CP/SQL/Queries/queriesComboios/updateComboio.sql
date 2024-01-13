GO

CREATE PROCEDURE UpdateComboio (@id int, @condutorid int , @revisorid int) 
	
    
AS
BEGIN
	 IF NOT EXISTS(SELECT * FROM Comboio WHERE ID = @id)
		BEGIN
			PRINT 'No such Train'

		END
	ELSE
		BEGIN
			IF(@condutorid is  NUll and @revisorid is NULL)
				BEGIN
					PRINT 'Have To make changes to personnel'
				END
			IF(@condutorid is NOT NUll and @revisorid is NULL)
				BEGIN 
					UPDATE Comboio
					SET Condutor_ID = @condutorid  
					WHERE ID = @id;
				END
			IF(@condutorid is  NUll and @revisorid is NOT  NULL)
				BEGIN
					UPDATE Comboio
					SET  Revisor_ID = @revisorid 
					WHERE ID = @id;
				END
			IF (@condutorid is NOT NUll and @revisorid is NOT  NULL)
				BEGIN
					UPDATE Comboio
					SET Condutor_ID = @condutorid , Revisor_ID = @revisorid 
					WHERE ID = @id;
				END
					
		
			
			
				
	
		END
	
	
	
END

	
GO