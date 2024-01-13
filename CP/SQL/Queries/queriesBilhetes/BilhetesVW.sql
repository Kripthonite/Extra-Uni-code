
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
WHERE Passageiro.Num_tel is not Null
     
   
  