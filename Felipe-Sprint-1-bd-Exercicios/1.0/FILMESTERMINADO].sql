
--Cria um banco de dados, chamado Filmes;
CREATE Database Filmes;

--Define o Banco de dados "Filmes" como o que será utilizado
Use Filmes;

Create table Generos
(
	IdGenero	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) NOT NULL
);

-- Criar tabela Filmesm com duas chaves, id filme e idgenero
Create table Filmes
(
	IdFilme		INT PRIMARY KEY IDENTITY
	,IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
	,Titulo		VARCHAR(200)	NOT NULL
);


-- Inserir dados na coluna 'Nome'
INSERT INTO Generos (Nome)
VALUES				('Ação')
				   ,('Aventura');

INSERT INTO Filmes (Titulo, IdGenero)
VALUES				('Rambo', 1)
				   ,('Ghost', 2)
				   ,('Vingadores',1)
				   ,('Mogli', 2);

UPDATE Filmes
SET Titulo = 'Diario de uma paixão'
WHERE IdFilme = 4;
