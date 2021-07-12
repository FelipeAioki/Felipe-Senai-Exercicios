CREATE DATABASE senai_CZBooks

USE senai_CZBooks

CREATE TABLE Instituicao
(
	IdInstituicao			INT PRIMARY KEY IDENTITY
	,Nome					VARCHAR (200) NOT NULL
	,Endereco				VARCHAR (200) NOT NULL
);

CREATE TABLE TipoUsuario
(
	IdTipoUsuario		INT PRIMARY KEY IDENTITY
	,nomeTipo			VARCHAR (200) NOT NULL
);

CREATE TABLE Usuarios
(
	IdUsuario			INT PRIMARY KEY IDENTITY
	,IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
	,Nome				VARCHAR (200) NOT NULL
	,Email				VARCHAR (200) NOT NULL
	,Senha				VARCHAR (100) NOT NULL
);

CREATE TABLE Categoria
(
	IdCategoria			INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR (200) NOT NULL
);

CREATE TABLE Livros
(
	IdLivro			INT PRIMARY KEY IDENTITY
	,IdUsuario		INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
	,IdCategoria		INT FOREIGN KEY REFERENCES Categoria (IdCategoria)
	,Titulo				VARCHAR (200) NOT NULL
	,Sinopse			VARCHAR (300) NOT NULL
	,Data_de_publicacao	VARCHAR (100) NOT NULL
	,Preco				DECIMAL NOT NULL
);

