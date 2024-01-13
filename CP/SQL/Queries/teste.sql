/*SELECT 
    *
FROM
    information_schema.tables;*/

    --SELECT Bilhete.ID INTO @Result FROM Bilhete ORDER BY ID DESC LIMIT 1
    --EXEC AddBilhete '12345678','Ovar' , 'Granja';
    --SELECT * FROM Bilhete;
     --SELECT * FROM ViajaComBilhete;
    --EXEC AddBilhete '12345678','Aveiro' , 'Ovar';
    --INSERT INTO Bilhete VALUES ('Ovar','Granja');
    --EXEC AddNewClient '12345678','Miguel','Rebelo','Costa','939293901','1995-08-03';
    -- EXEC UpdateBilhete '87654321' , 'Aveiro' , 'São Bento' , 2; 
    --SELECT * FROM ViajaComBilhete;
    --EXEC AddBilhete '87654321','Aveiro' , 'Ovar';
    --EXEC CreateFunc 10001 ,'cao';
    --SELECT * FROM TipoFunc;
    --AddNewEmployee ( @id int , @fname VARCHAR(50), @mname VARCHAR(50) , @lname VARCHAR(50) , @salario int , @data_nascimento Date, @num_tel VARCHAR(9) , @morada VARCHAR(250) , @funcid int) 
   --EXEC AddNewEmployee 3500, 'Roberto' , 'Garcia' , 'Luiz' , 650 , '1970-03-11', '924559432' , 'Rua dos perdidos' , 1001;
   --SELECT * FROM Funcionário;
   --EXEC RemoveEmployee 3500;
   --SELECT * FROM Funcionário
   --INSERT INTO Comboio VALUES(10001,10002);
   --SELECT * FROM Comboio
   --EXEC AddCarruagem 1 ,400
   --SELECT * FROM Carruagem
   --EXEC RemoveCarruagem 1 , 1000;
   --EXEC AddComboio  10001 , 10002 
   --SELECT * From Funcionário
  -- SELECT * FROM TipoFunc
  --EXEC RemoveComboio 2
  --EXEC UpdateComboio 1 , null , null
  --INSERT INTO Comboio VALUES(10001 , 10002)
  --INSERT INTO Carruagem VALUES(2,300)
  --SELECT * FROM (Comboio 
 -- JOIN Carruagem ON Comboio.ID = Carruagem.Comboio_ID)
  --SELECT * FROM Carruagem
--ALTER TABLE Funcionário
--ADD CONSTRAINT chk_age CHECK (datediff( YY, Data_Nascimento, getdate()) > 16);
--SELECT * FROM TipoFunc;
--EXEC AddNewEmployee 3500, 'Roberto' , 'Garcia' , 'Luiz' , 650 , '2000-03-11', '924559432' , 'Rua dos perdidos' , 10001;
 -- SELECT * FROM TipoFunc
 --procedimento para criar trigger de num de lugares
--INSERT INTO Comboio VALUES (10002 , 10003 ) 1
--SELECT * From Comboio 

--INSERT INTO Carruagem VALUES(1,2) 2
 --INSERT INTO Trajeto VALUES('Aveiro' , 'São Bento') 3
-- SELECT * FROM Trajeto;
-- INSERT INTO ComboioFazTrajeto VALUES(1,1000) 4
--SELECT * FROM ComboioFazTrajeto;
--SELECT * FROM ()
--------------------------------------------------------------
--SET @idBil = (SELECT Bilhete.ID FROM (Bilhete JOIN Trajeto ON (Bilhete.EstaçãoChegada = Trajeto.EstaçãoChegada AND Bilhete.EstaçãoPartida = Trajeto.EstaçãoPartida)));
--SET @idtraj = (SELECT Trajeto.ID FROM (Bilhete JOIN Trajeto ON (Bilhete.EstaçãoChegada = Trajeto.EstaçãoChegada AND Bilhete.EstaçãoPartida = Trajeto.EstaçãoPartida)));
--SET @idComb = (SELECT Comboio_ID FROM ComboioFazTrajeto WHERE TrajetoID = @idtraj);
DECLARE @oi as VARCHAR(255)

--EXEC CreateCarruagem 1 , 1


--SELECT * FROM ViajaComBilhete;

--EXEC AddNewClient '12345687','la','da','Son','939293902','1995-02-03';
--SELECT * FROM Passageiro;
--EXEC AddBilhete  '12345687' , 'Aveiro' , 'São Bento'  , @oi;
--EXEC AddNewClient '12345887','la','da','pai','939293902','1995-02-03';



