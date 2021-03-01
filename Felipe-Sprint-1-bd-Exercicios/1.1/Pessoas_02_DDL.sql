CREATE DATABASE Pessoas;

USE Pessoas;

Create table Pessoas
(
	IdPessoa		INT PRIMARY KEY IDENTITY
	,IdTelefone		INT FOREIGN KEY REFERENCES Telefones (IdTelefone)
	,IdCnh			INT FOREIGN KEY REFERENCES Cnh (IdCnh)
	,IdEmail		INT FOREIGN KEY REFERENCES Emails (IdEmail)
	,Nome			VARCHAR(200)	NOT NULL
);

Create table Telefones
(
	IdTelefone			INT PRIMARY KEY IDENTITY
	,Numero				INT NOT NULL
);

Create table Cnh
(
	IdCnh				INT PRIMARY KEY IDENTITY
	,Identificação		INT NOT NULL
);

Create table Emails
(
	IdEmail				INT PRIMARY KEY IDENTITY
	,Email				VARCHAR(100) NOT NULL
);

INSERT INTO Telefones (Numero)
VALUES				(723673)
				   ,(323445);

INSERT INTO Cnh (Identificação)
VALUES				(72363673)
				   ,(32442345);

INSERT INTO Emails (Email)
VALUES				('PessoaUm@Gmail.com')
				   ,('PessoaDois@Gmail.com');


SET IDENTITY_INSERT Pessoas ON
INSERT INTO Pessoas (Nome, IdCnh, IdEmail, IdPessoa)
VALUES				('Felipe Queiroz', 1, 1, 1)
				   ,('Maria Maria', 2, 2, 2);