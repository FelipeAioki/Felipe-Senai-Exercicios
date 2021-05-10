CREATE DATABASE SP_Medical_Group

USE SP_Medical_Group

CREATE TABLE Clínica
(
	IdClinica			INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR (200) NOT NULL
	,Cnpj				VARCHAR (200) NOT NULL
	,Endereço			VARCHAR (200) NOT NULL
	,Horarios			VARCHAR (100) NOT NULL
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
	,nomeUsuario		VARCHAR (200) NOT NULL
	,Email				VARCHAR (200) NOT NULL
	,Senha				VARCHAR (100) NOT NULL
);

CREATE TABLE Pacientes
(
	IdPaciente			INT PRIMARY KEY IDENTITY
	,IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
	,Nome				VARCHAR (200) NOT NULL
	,RG					VARCHAR (200) NOT NULL
	,CPF				VARCHAR (100) NOT NULL
	,Endereço			VARCHAR (200) NOT NULL
	,Nascimento			VARCHAR (200) NOT NULL
	,Telefone			VARCHAR (200) NOT NULL
);

CREATE TABLE Especialidades
(
	IdEspecialidade		INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR (200) NOT NULL
);

CREATE TABLE Medicos
(
	IdMedico			INT PRIMARY KEY IDENTITY
	,IdTipoUsuario		INT FOREIGN KEY REFERENCES Usuarios (IdUsuario) 
	,IdEspecialidade	INT FOREIGN kEY REFERENCES Especialidades (IdEspecialidade)
	,Nome				VARCHAR (200) NOT NULL
);

CREATE TABLE Consultas
(
	IdConsulta			INT PRIMARY KEY IDENTITY
	,IdMedico			INT FOREIGN KEY REFERENCES Medicos (IdMedico)
	,IdPaciente			INT FOREIGN KEY REFERENCES Pacientes (IdPaciente)
	,Data_da_consulta	VARCHAR (100) NOT NULL
	,Situação			VARCHAR (100) NOT NULL
);
