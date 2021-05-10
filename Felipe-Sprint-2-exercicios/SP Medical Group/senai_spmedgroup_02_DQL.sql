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