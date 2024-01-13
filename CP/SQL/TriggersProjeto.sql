Create TRIGGER deleteComboio ON Comboio 
instead of delete
as 
	BEGIN 
		set nocount on;

		declare @ComboioID Int

		select @ComboioID = DELETED.ID from DELETED;
		
		DELETE FROM Carruagem WHERE Carruagem.Comboio_ID = @ComboioID
		delete from ComboioFazTrajeto where ComboioFazTrajeto.Comboio_ID = @ComboioID
		DELETE FROM Comboio WHERE Comboio.ID = @ComboioID

	END

go

-- drop trigger deleteComboio


CREATE TRIGGER deleteTrajeto on Trajeto
instead of delete
as 
	begin 
		set nocount on;

		declare @TrajetoID Int

		select @TrajetoID = DELETED.ID from DELETED;
		
		DELETE FROM FazParagem WHERE FazParagem.TrajetoID = @TrajetoID
		delete from HorárioTrajeto where HorárioTrajeto.TrajetoID = @TrajetoID
		DELETE FROM ComboioFazTrajeto WHERE ComboioFazTrajeto.TrajetoID = @TrajetoID
		delete from Trajeto where Trajeto.ID = @TrajetoID

	end


go




CREATE TRIGGER deleteBilhete on Bilhete
instead of delete
as 
	begin 
		set nocount on;

		declare @BilheteID Int

		select @BilheteID = DELETED.ID from DELETED;
		
		DELETE FROM ViajaComBilhete WHERE ViajaComBilhete.ID_Bilhete = @BilheteID



	end


go


CREATE TRIGGER DeleteEstação on Estação
instead of DELETE
AS 

	begin
		
		
		set nocount on;

		declare @EstacaoNome Varchar(250)

		select @EstacaoNome = DELETED.Nome from DELETED;
		
		if NOT EXISTS (SELECT * FROM Trajeto WHERE (Trajeto.EstaçãoPartida = @EstacaoNome OR Trajeto.EstaçãoChegada = @EstacaoNome ))
			BEGIN
				delete from Bilhete where EstaçãoChegada = @EstacaoNome
				delete from FazParagem where Estação = @EstacaoNome
				delete from Balcão where Balcão.NomeEstação = @EstacaoNome

				delete from Estação where Nome = @EstacaoNome
				
			END
		ELSE
			BEGIN 
				RAISERROR('Cannot Delete from this table because a Trajeto exists that depends on it',1,1)
				ROLLBACK
				print 'Cannot Delete from this table because a Trajeto exists that depends on it'
			END
	end

go

CREATE TRIGGER deletePassageiro on Passageiro
instead of delete
as
	begin 
		set nocount on;

		declare @Numcc Varchar(8)

		select @Numcc = DELETED.Num_CC from DELETED;
		
		delete from ViajaComBilhete where ViajaComBilhete.NUM_CC = @Numcc
		delete from Passageiro where Num_CC = @Numcc

	end

go


create trigger DeleteTipoFunc on TipoFunc
instead of delete
as 
	begin

		set nocount on;

		declare @FuncID int

		select @FuncID = DELETED.ID from DELETED;
		
		if not exists (select * from Funcionário where Funcionário.FuncID = @FuncID)
			BEGIN
				DELETE FROM TipoFunc WHERE ID = @FuncID
			END
		ELSE
			BEGIN 
				RAISERROR('Cannot Delete from this table because there are Funcionários with this function',1,1)
				ROLLBACK
				print 'Cannot Delete from this table because there are Funcionários with this function'
			END

	end

go

