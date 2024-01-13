GO

CREATE PROCEDURE RemoveCarruagem (@comboioid int , @ncarruagem int)

    
AS
BEGIN
	DELETE FROM Carruagem
	WHERE Comboio_id  = @comboioid AND N_Carruagem = @ncarruagem;
END

	
GO

