GO

CREATE PROCEDURE AddNewEmployee ( @id int , @fname VARCHAR(50), @mname VARCHAR(50) , @lname VARCHAR(50) , @salario int , @data_nascimento Date, @num_tel VARCHAR(9) , @morada VARCHAR(250) , @funcid int) 

    
AS
BEGIN
	INSERT INTO Funcionário
	VALUES (@id ,  @fname , @mname , @lname ,@salario,  @data_nascimento , @num_tel , @morada , @funcid)
END

	
GO

