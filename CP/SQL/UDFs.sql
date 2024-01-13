
GO
CREATE FUNCTION FuncSearchBalcao ( @Nome varchar(255) ) RETURNS TABLE
AS
	RETURN (SELECT * FROM Balc�o WHERE CHARINDEX(@Nome, NomeEsta��o) > 0)

GO

-- drop Function FuncSearchEstacoes
-- select * from FuncSearchBalcao ('a')

GO
CREATE FUNCTION FuncSearchEstacoes ( @Nome varchar(255) ) RETURNS TABLE
AS
	RETURN (SELECT * FROM Esta��o WHERE CHARINDEX(@Nome, Nome) > 0)

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
	   Bilhete.Esta��oPartida,
	   Bilhete.Esta��oChegada,
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
                     Bilhete.Esta��oPartida,
                     Bilhete.Esta��oChegada,
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
    
	RETURN (SELECT  Esta��oPartida, Esta��oChegada, Passageiro.Num_CC, Passageiro.FName,Passageiro.LName
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
	RETURN (SELECT Nome AS Esta��es FROM Esta��o )

GO

CREATE FUNCTION GetParagens (@id int ) RETURNS TABLE
AS
	RETURN (SELECT Esta��o AS Paragens FROM FazParagem where TrajetoID =@id )

GO



go
CREATE FUNCTION GetHor�rio (@partida varchar(250), @chegada varchar(250)) returns table 
as 
	
		return(
		select * from
		(select ID , COUNT(FazParagem.TrajetoID)  as Numero, HoraChegada,HoraSaida,Esta��oPartida,Esta��oChegada from (Trajeto join FazParagem on ID = TrajetoID ),Hor�rioTrajeto where (Esta��o = @chegada or Esta��o = @partida )  GROUP BY ID, HoraChegada,HoraSaida,Esta��oPartida,Esta��oChegada ) as Nome where Numero >1 )
	
go
-- drop Function GetHor�rio
create Function GetHorasTrajeto (@id int) returns table
as 
	return (
		select Esta��oChegada, Esta��oPartida ,HoraSaida,HoraChegada from (select * from Trajeto, Hor�rioTrajeto where TrajetoID = ID ) as nn where ID = @id
	)
go

-- drop Function GetHorasTrajeto