GO

CREATE PROCEDURE AddNewClient (@numcc VARCHAR(8), @fname VARCHAR(50), @mname VARCHAR(50) , @lname VARCHAR(50) , @num_tel VARCHAR(9) , @data_nascimento Date) 

    
AS
BEGIN
	INSERT INTO Passageiro
	VALUES (@numcc , @fname , @mname , @lname , @num_tel , @data_nascimento)
END

	
GO
--EXEC AddNewClient '87654321','Mariana','Rebelo','Costa','936083800','1995-08-03';
--select * From Passageiro;

			