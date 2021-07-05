USE SP_Medical_Group

SELECT * FROM Cl�nica

SELECT * FROM Consultas

SELECT * FROM Especialidades

SELECT * FROM Medicos

SELECT * FROM Pacientes

SELECT * FROM TipoUsuario

SELECT * FROM Usuarios

-- 1 -- Seleciona o Nome do Paciente, o nome do M�dico, a Data da Consulta e tamb�m a situa��o da consulta.
SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico;

SELECT idNome, Nome, Sobrenome, Nascimento FROM Consultas WHERE IdPaciente = 1;

SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico WHERE Pacientes.IdPaciente = 4;

SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico;

SELECT Consultas.Situa��o, Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o, Especialidades.Nome
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico
LEFT JOIN Especialidades
ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade;

SELECT Especialidades.Nome AS 'Especialidade', Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o, Cl�nica.Endere�o AS 'Endere�o' FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico LEFT JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade FULL OUTER JOIN Cl�nica on Cl�nica.IdClinica = Cl�nica.IdClinica


SELECT Especialidades.Nome AS 'Especialidade', Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o, Cl�nica.Endere�o AS 'Endere�o' FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico FULL OUTER JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade FULL OUTER JOIN Cl�nica on Cl�nica.IdClinica = Cl�nica.IdClinica  WHERE Pacientes.IdPaciente = @ID;