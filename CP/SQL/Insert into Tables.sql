


-- INSERT ESTAÇÕES

INSERT INTO Estação VALUES ('São Bento',6,12);
INSERT INTO Estação VALUES ('Espinho',2,1);
INSERT INTO Estação VALUES ('Granja',2,2);
INSERT INTO Estação VALUES ('Ovar',4,8);
INSERT INTO Estação VALUES ('Aveiro',5,10);

-- SELECT * FROM Estação;

INSERT INTO TipoFunc VALUES (10322, 'Secretário' );
INSERT INTO TipoFunc VALUES (10001, 'Condutor' );
INSERT INTO TipoFunc VALUES (10002, 'Revisor' );

-- SELECT * FROM TipoFunc;

INSERT INTO Funcionário VALUES (10001,'Bruno','R' ,'Peterson',1200,'1980-2-2',918833999,'Aveiro rua tal e coiso',10322);
INSERT INTO Funcionário VALUES (10002,'Marcus','L' ,'Teles',1500,'1980-2-2',918833779,'Aveiro rua coiso e tal',10001);
INSERT INTO Funcionário VALUES (10003,'Rui','V','Luis',1500,'1980-2-2',918835999,'Porto alameda do bairro',10002);

-- SELECT * FROM Funcionário;
-- SELECT * FROM Funcionário, TipoFunc WHERE TipoFunc.ID = FuncID

INSERT INTO Balcão VALUES (1,'Aveiro',10001);


-- SELECT * FROM Balcão;
-- SELECT * FROM Balcão, Funcionário Where Balcão.FuncId = Funcionário.ID;

INSERT INTO Bilhete VALUES ('Aveiro','São Bento');
INSERT INTO Bilhete VALUES ('Aveiro','Ovar');

-- SELECT * FROM Bilhete
-- SELECT * FROM Bilhete WHERE EstaçãoChegada = 'Ovar' 
INSERT INTO Comboio VALUES (10002 , 10003 );
INSERT INTO Carruagem VALUES(1,2); 
INSERT INTO Trajeto VALUES('Aveiro' , 'São Bento');
INSERT INTO ComboioFazTrajeto VALUES(1,1000);



