CREATE DATABASE Empresa;

USE Empresa;

Create table Marcas
(
	IdMarca	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(100) NOT NULL
);

Create table Modelos
(
	IdModelo	INT PRIMARY KEY IDENTITY
	,IdMarca	INT FOREIGN KEY REFERENCES Marcas (IdMarca)
	,Descrição		VARCHAR(100) NOT NULL
);

Create table Clientes
(
	IdCliente	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) NOT NULL
	,Cpf		INT NOT NULL
);

Create table Empresa
(
	IdEmpresa	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) NOT NULL
);

Create table Veiculos
(
	IdVeiculo	INT PRIMARY KEY IDENTITY
	,IdModelo	INT FOREIGN KEY REFERENCES Modelos (IdModelo)
	,IdEmpresa	INT FOREIGN KEY REFERENCES Empresa (IdEmpresa)
	,Placa		VARCHAR(100) NOT NULL
);



Create table Alugueis
(
	IdAluguel	INT PRIMARY KEY IDENTITY
	,IdCliente	INT FOREIGN KEY REFERENCES Clientes (IdCliente)
	,IdVeiculo	INT FOREIGN KEY REFERENCES Veiculos (IdVeiculo)
	,DataInicio		VARCHAR(200) NOT NULL
	,DataFim		VARCHAR(200) NOT NULL
);

