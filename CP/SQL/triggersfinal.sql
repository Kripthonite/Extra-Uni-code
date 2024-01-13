CREATE TRIGGER bilheteviaj
ON ViajaComBilhete
AFTER INSERT
AS
	BEGIN
		


		DECLARE @a as int
		DECLARE @b as int
		DECLARE @c as int
		DECLARE @d as int
		DECLARE @total as int
		DECLARE @tktsold as int
		DECLARE @idBil as int
		DECLARE @idtraj as int
		DECLARE @idComb as int 
		DECLARE @num_cc as VARCHAR (8)
		SET @num_cc = (SELECT NUM_CC FROM inserted);
		SET @idBil = (SELECT ID_Bilhete FROM inserted);
		SET @idtraj = (SELECT Trajeto.ID 
					   FROM ((Bilhete JOIN Trajeto ON (Bilhete.EstaçãoChegada = Trajeto.EstaçãoChegada AND Bilhete.EstaçãoPartida = Trajeto.EstaçãoPartida)))
					   WHERE Bilhete.ID = @idBil );
		SET @idComb = (SELECT Comboio_ID FROM ComboioFazTrajeto WHERE TrajetoID = @idtraj);

		SELECT  @a = Comboio.ID , @b = Comboio.Condutor_ID, @c= Comboio.Revisor_ID , @d =   COUNT(*) , @total= SUM(N_lugares) 
		FROM (Comboio 
		JOIN Carruagem ON Comboio.ID = Carruagem.Comboio_ID)
		WHERE Comboio_ID= @idComb
		GROUP by Comboio.ID , Comboio.Condutor_ID , Comboio.Revisor_ID ;



		SET @tktsold = (SELECT Count(*)[BilhetesVendidos] FROM ViajaComBilhete WHERE ID_Bilhete = @idBil);
		if(@total < @tktsold )
			BEGIN
				DELETE FROM ViajaComBilhete  where ID_Bilhete = @idBil AND NUM_CC = @num_cc
				print 'Comboio esgotado. Bilhete eliminado' 
			END
			
	END