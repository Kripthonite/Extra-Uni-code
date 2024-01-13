
GO
CREATE PROCEDURE CreateEstacao(@NomeEsta��o VARCHAR(255), @N_Linhas int , @N_Plataformas INT)
		AS
		BEGIN

			 INSERT INTO Esta��o VALUES(@NomeEsta��o, @N_Linhas, @N_Plataformas);
			 PRINT 'Sucess'

		END 
GO
/*
-- DROP PROCEDURE CreateEstacao
DECLARE @NomeEsta��o VARCHAR(255) ;
set @NomeEsta��o = 'Aveiro';
DECLARE @N_Linhas INT;
DECLARE @N_Plataformas INT;
SET @N_Plataformas = 2;
SET @N_Linhas = 2;
EXEC CreateEstacao @NomeEsta��o,@N_Linhas,@N_Plataformas*/


GO
CREATE PROCEDURE CreateBalcao(@NomeEsta��o VARCHAR(255), @N_Balcao int , @N_Funcionario INT)
		AS
		BEGIN

			 INSERT INTO Balc�o VALUES(@N_Balcao, @NomeEsta��o, @N_Funcionario);
			 PRINT 'Sucess'

		END 
GO

-- DROP PROCEDURE CreateBalcao

GO
CREATE PROCEDURE CreateComboio(@Revisor int , @Condutor INT)
		AS
		BEGIN

			 INSERT INTO Comboio VALUES(@Revisor, @Condutor);
			 PRINT 'Sucess'

		END 
GO


/*DECLARE @Revisor INT;
DECLARE @Condutor INT;
SET @Condutor = null;
SET @Revisor = null;
exec CreateComboio @Revisor,@Condutor 
select * from Comboio
select * from Funcion�rio
DELETE FROM Comboio where id=5
DROP PROCEDURE CreateComboio */


GO
CREATE PROCEDURE alterComboio(@ID Int,@Revisor int , @Condutor INT)
AS
	BEGIN

			DECLARE @Revisor_old AS int;  
			DECLARE @Condutor_old AS int;  

			SELECT @Revisor_old = Revisor_ID, @Condutor_old = Condutor_ID
			FROM Comboio
			WHERE Comboio.ID = @ID;

	
			UPDATE Comboio SET Revisor_ID = @Revisor WHERE ID = @ID;
			PRINT 'Revisor updated with success '  

			UPDATE Comboio SET Condutor_ID = @Condutor  WHERE ID = @ID;
				PRINT 'Condutor updated with success '  
	
		 


	END
go
-- drop procedure alterComboio
/*DECLARE @Revisor INT;
DECLARE @Condutor INT;
DECLARE @ID INT;
SET @Condutor = 10002;
SET @ID = 6;
SET @Revisor = 10002;
exec alterComboio @ID, @Revisor,@Condutor

select * from Comboio
*/

go 
CREATE PROCEDURE CreateCarruagem(@ComboioID int , @NLugares INT)
		AS
		BEGIN

			 INSERT INTO Carruagem VALUES(@ComboioID, @NLugares);
			 PRINT 'Success'

		END 
go
GO

CREATE PROCEDURE RemoveCarruagem (@comboioid int , @ncarruagem int)

    
AS
BEGIN
	DELETE FROM Carruagem
	WHERE Comboio_id  = @comboioid AND N_Carruagem = @ncarruagem;
END

	
GO
GO

CREATE PROCEDURE RemoveComboio (@id int)

    
AS
BEGIN
	DELETE FROM Comboio
	WHERE ID  = @id;
END

	
GO

GO

CREATE PROCEDURE AddNewClient (@numcc VARCHAR(8), @fname VARCHAR(50), @mname VARCHAR(50) , @lname VARCHAR(50) , @num_tel VARCHAR(9) , @data_nascimento Date) 

    
AS
BEGIN
	INSERT INTO Passageiro
	VALUES (@numcc , @fname , @mname , @lname , @num_tel , @data_nascimento)
END

	
GO

GO

CREATE PROCEDURE AddBilhete (@numcc VARCHAR(8), @partida VARCHAR(255), @chegada VARCHAR(255),@output VARCHAR(255) output ) 
    
AS
BEGIN
	IF NOT EXISTS(
		SELECT * 
		FROM Passageiro
		WHERE Num_CC = @numcc)
		BEGIN
			set @output = 'No such Passenger'
		END
	ELSE
		BEGIN
			
			DECLARE @ID as int
			SET @ID= (SELECT ID FROM Bilhete WHERE Esta��oPartida=@partida AND Esta��oChegada = @chegada)
			INSERT INTO ViajaComBilhete VALUES(@ID ,@numcc)
			DECLARE @idstr VARCHAR(10) 
			SET @idstr =  (SELECT CONVERT(varchar(10),@ID) as Num2)
			set @output = (SELECT CONCAT('Passager Added, Bilhete ID is ' , @idstr))
		END
	
	
	
END

	
GO

-- drop procedure AddBilhete

GO

CREATE PROCEDURE RemoveClient (@numcc VARCHAR(8))

    
AS
BEGIN
	DELETE FROM Passageiro
	WHERE Num_CC = @numcc;
END

	
GO

GO

CREATE PROCEDURE UpdateBilhete (@numcc VARCHAR(8), @partida VARCHAR(255), @chegada VARCHAR(255) , @idBilhete int,@output varchar(250) OUTPUT) 
	
    
AS
BEGIN
	
	IF NOT EXISTS(
		SELECT * 
		FROM Passageiro
		WHERE Num_CC = @numcc)
		BEGIN
			set @output = 'No such Passenger'
		END
	ELSE
		BEGIN
			DELETE FROM ViajaComBilhete WHERE (ID_Bilhete = @idBilhete AND NUM_CC = @numcc)
			update Bilhete set Esta��oChegada = @chegada, Esta��oPartida = @partida where ID = @idBilhete
			INSERT INTO ViajaComBilhete VALUES(@idBilhete ,@numcc)
			set @output = 'Ticket Updated'
		END
	
	
	
END

	
GO
-- drop procedure UpdateBilhete
GO

CREATE PROCEDURE AddNewEmployee ( @id int , @fname VARCHAR(50), @mname VARCHAR(50) , @lname VARCHAR(50) , @salario int , @data_nascimento Date, @num_tel VARCHAR(9) , @morada VARCHAR(250) , @funcid int) 

    
AS
BEGIN
	INSERT INTO Funcion�rio
	VALUES (@id ,  @fname , @mname , @lname ,@salario,  @data_nascimento , @num_tel , @morada , @funcid)
END

	
GO
GO

CREATE PROCEDURE CreateFunc (@idFunc int, @Func VARCHAR(50),@output VARCHAR(250) OUTPUT)
	
    
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM TipoFunc WHERE ID = @idFunc)
		BEGIN
			INSERT INTO TipoFunc
			VALUES (@idFunc , @Func)
			set @output = ''
		END
	ELSE
		BEGIN
			
			set @output = 'Ja existe cargo com esse id'
		END
	
	
END
--drop procedure CreateFunc
GO

CREATE PROCEDURE RemoveEmployee (@id VARCHAR(8))

    
AS
BEGIN
	DELETE FROM Funcion�rio
	WHERE ID  = @id;
END

	
GO

CREATE PROCEDURE CreateTrajecto (@partida varchar(250),@chegada varchar(250),@output VARCHAR(250) OUTPUT , @id int OUTPUT)
AS
	BEGIN
		IF (( EXISTS(SELECT * FROM Esta��o WHERE Nome = @chegada)) and ( EXISTS (SELECT * FROM Esta��o WHERE Nome = @partida)))
			BEGIN
				INSERT INTO Trajeto VALUES (@partida,@chegada) set @id =  SCOPE_IDENTITY()  
				set @output = ''

			END
		ELSE 
			BEGIN 
				set @output = 'N�o exite essa paragem de chegada ou partida'
			END 
	END

GO

-- drop procedure CreateTrajecto 


CREATE PROCEDURE CreateFazParagem (@ID int,@estacao varchar(250))
as
	begin 
		INSERT INTO FazParagem VALUES (@ID,@estacao)  
	end 

go

CREATE PROCEDURE RemoveTrajecto ( @id int )
AS
	BEGIN
		delete from Trajeto where ID = @id
	END

GO

CREATE PROCEDURE GETPartidaChegada ( @id int, @partida varchar(250) output,@chegada varchar(250) output)
AS
	BEGIN
		set @partida = (select Esta��oPartida from Trajeto where ID = @id)
		set @chegada = (select Esta��oChegada from Trajeto where ID = @id)

	END

GO