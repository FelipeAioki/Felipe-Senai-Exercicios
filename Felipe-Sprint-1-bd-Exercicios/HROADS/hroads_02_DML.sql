USE Senai_Hroads_Manha;

INSERT INTO Classes (Nome) 
VALUES				('Bárbaro')
		   		   ,('Cruzado')
				   ,('Caçadora')
				   ,('Monge')
				   ,('Necromante')
				   ,('Feitiçeiro')
				   ,('Arcanista');
				   
INSERT INTO TipoHabilidades (Nome) 
VALUES						('Ataque')
							,('Defesa')
							,('Cura')
							,('Magia');

INSERT INTO Habilidades (Nome , IdTipo)
VALUES					('Lança Mortal' ,1 )
						,('Escudo Supemo' , 2)
						,('Recupar Vida' ,3 );
	
INSERT INTO Personagens  (Nome,      IdClasse,   MaxVida,   MaxMana,   Atualizacao, Criacao)
VALUES					 ('DeuBug'    ,6,		  150,		 50		,GETDATE(),'2019-03-18')
						,('ButBug'    ,1,		  100,	     50		,GETDATE(),'2016-03-17')
						,('Fer8'      ,2,		  250,	    100		,GETDATE(),'2018-03-18');
										
INSERT INTO ClassesHabilidades (IdClasse, IdHab)
VALUES						  (1,1)
							 ,(1,2)
							 ,(2,2)
							 ,(3,1)
							 ,(4,3)
							 ,(4,2)
							 ,(5,NULL)
							 ,(6,3)
							 ,(7,NULL);


--Update do nome
UPDATE Personagens
SET Nome = 'Fer7'
WHERE IdPersonagem = 3;

--Update do Necromancer
UPDATE Classes
SET Nome = 'Necromancer'
WHERE IdClasse = 5;