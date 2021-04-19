--DDL
CREATE DATABASE InLock
GO;

USE InLock
GO;

CREATE TABLE Estudio
(
	IdEstudio INT PRIMARY KEY IDENTITY
	,NomeEstudio	  VARCHAR (200)
)
GO;

CREATE TABLE Jogo
(
	 IdJogo		INT PRIMARY KEY IDENTITY
	,IdEstudio  INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
	,NomeJogo		VARCHAR (200) 
	,Descricao	VARCHAR (250)
	,Lancamento DATE
	,Valor      DECIMAL
)
GO;

CREATE TABLE TipoUsuario
(
	 IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Titulo		  VARCHAR(200)
)
GO

CREATE TABLE Usuario
(
	IdUsuario		INT PRIMARY KEY IDENTITY
	,IdTipoUsuario  INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
	,Email			VARCHAR (200)
	,Senha			VARCHAR(200)
)

GO