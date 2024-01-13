GO

CREATE PROCEDURE AddComboio ( @condutorid int , @revisorid int ) 

    
AS
BEGIN
	INSERT INTO Comboio
	VALUES (@condutorid ,  @revisorid )
END

	
GO



			