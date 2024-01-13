
GO
CREATE FUNCTION FuncSearchBalcao ( @Nome varchar(255) ) RETURNS TABLE
AS
	RETURN (SELECT * FROM Balcão WHERE CHARINDEX(@Nome, NomeEstação) > 0)

GO

-- drop Function FuncSearchEstacoes
-- select * from FuncSearchBalcao ('a')

GO
CREATE FUNCTION FuncSearchEstacoes ( @Nome varchar(255) ) RETURNS TABLE
AS
	RETURN (SELECT * FROM Estação WHERE CHARINDEX(@Nome, Nome) > 0)

GO
-- drop Function FuncSearchEstacoes
-- select * from FuncSearchEstacoes ('a')

go 

Create FUNCTION ListComboios () RETURNS TABLE
AS 
	RETURN (SELECT ID, Revisor_ID AS Revisor, Condutor_ID AS Condutor, count(Carruagem.Comboio_ID) AS Carruagens, sum(Carruagem.N_lugares) as Lugares FROM (Comboio left join Carruagem ON Comboio.ID = Carruagem.Comboio_ID) GROUP BY ID, Revisor_ID, Condutor_ID )
GO

Create FUNCTION ListCarruagens () RETURNS TABLE
AS 
	RETURN (SELECT * FROM Carruagem )
GO

-- drop Function ListComboios
-- select * from ListComboios ()
-- select * from ListCarruagens ()
--	select * FROM (Comboio left join Carruagem ON Comboio.ID = Carruagem.Comboio_ID)
-- select * from Comboio

CREATE FUNCTION BilhetesVW () RETURNS TABLE
AS 
	RETURN(
	SELECT
	   Bilhete.ID ,
	   Bilhete.EstaçãoPartida,
	   Bilhete.EstaçãoChegada,
	   ViajaComBilhete.NUM_CC,
	   Passageiro.FName,
	   Passageiro.Num_Tel
	FROM
	    
	    (Bilhete
	      JOIN
	         ViajaComBilhete
	         ON Bilhete.ID = ViajaComBilhete.ID_Bilhete 
	      JOIN
	         Passageiro 
	         ON ViajaComBilhete.NUM_CC = Passageiro.Num_CC 
	         )
	WHERE Passageiro.Num_tel is not Null)
GO 


GO
CREATE FUNCTION FindTicketsByCC (@CC INT) RETURNS TABLE 
AS
    
	RETURN (SELECT   Bilhete.ID ,
                     Bilhete.EstaçãoPartida,
                     Bilhete.EstaçãoChegada,
                     ViajaComBilhete.NUM_CC,
                     Passageiro.FName,
                     Passageiro.Num_Tel
			FROM Bilhete
                JOIN
                ViajaComBilhete
                ON Bilhete.ID = ViajaComBilhete.ID_Bilhete 
                JOIN
                Passageiro 
                ON ViajaComBilhete.NUM_CC = Passageiro.Num_CC 
			WHERE Passageiro.Num_CC = @CC
			)
GO


GO
CREATE FUNCTION FindTicketsById (@id INT) RETURNS TABLE 
AS
    
	RETURN (SELECT  EstaçãoPartida, EstaçãoChegada, Passageiro.Num_CC, Passageiro.FName,Passageiro.LName
			FROM 
			Bilhete 
			join
			ViajaComBilhete 
			on Bilhete.ID =ViajaComBilhete.ID_Bilhete
			join 
			Passageiro
			on Passageiro.Num_CC = ViajaComBilhete.NUM_CC 
            where Bilhete.id =@id)
GO

Create FUNCTION ListTipos () RETURNS TABLE
AS 
	return (SELECT ID , Cargo FROM TipoFunc)
go

CREATE FUNCTION GetEstacoes ( ) RETURNS TABLE
AS
	RETURN (SELECT Nome AS Estações FROM Estação )

GO

CREATE FUNCTION GetParagens (@id int ) RETURNS TABLE
AS
	RETURN (SELECT Estação AS Paragens FROM FazParagem where TrajetoID =@id )

GO



go
CREATE FUNCTION GetHorário (@partida varchar(250), @chegada varchar(250)) returns table 
as 
	
		return(
		select * from
		(select ID , COUNT(FazParagem.TrajetoID)  as Numero, HoraChegada,HoraSaida,EstaçãoPartida,EstaçãoChegada from (Trajeto join FazParagem on ID = TrajetoID ),HorárioTrajeto where (Estação = @chegada or Estação = @partida )  GROUP BY ID, HoraChegada,HoraSaida,EstaçãoPartida,EstaçãoChegada ) as Nome where Numero >1 )
	
go
-- drop Function GetHorário
create Function GetHorasTrajeto (@id int) returns table
as 
	return (
		select EstaçãoChegada, EstaçãoPartida ,HoraSaida,HoraChegada from (select * from Trajeto, HorárioTrajeto where TrajetoID = ID ) as nn where ID = @id
	)
go

-- drop Function GetHorasTrajeto