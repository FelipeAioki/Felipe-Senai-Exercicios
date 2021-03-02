CREATE DATABASE Senai_Hroads_Manha;

USE Senai_Hroads_Manha;

CREATE TABLE TipoHabilidades
(
	IdTipoHab INT PRIMARY KEY IDENTITY
	,Nome	  VARCHAR (200) NOT NULL
);

CREATE TABLE Habilidades
(
	IdHab		INT PRIMARY KEY IDENTITY
	,IdTipo		INT FOREIGN KEY REFERENCES TipoHabilidades (IdTipoHab)
	,Nome		VARCHAR(200) NOT NULL
);


CREATE TABLE Classes
(
	IdClasse INT PRIMARY KEY IDENTITY
   ,Nome	 VARCHAR(200) NOT NULL 
);

CREATE TABLE Personagens
(
	IdPersonagem		INT PRIMARY KEY IDENTITY
	,IdClasse		    INT FOREIGN KEY REFERENCES Classes (IdClasse)
	,Nome				VARCHAR(200) NOT NULL 
	,MaxVida			INT
	,MaxMana			INT
	,Atualizacao		VARCHAR(200) 
	,Criacao			DATE 
);
CREATE TABLE ClassesHabilidades
(
	IdClasse			INT FOREIGN KEY REFERENCES Classes (IdClasse)
	,IdHab				INT FOREIGN KEY REFERENCES Habilidades (IdHab)
);

--DDL