USE SP_Medical_Group

SELECT * FROM Clínica

SELECT * FROM Consultas

SELECT * FROM Especialidades

SELECT * FROM Medicos

SELECT * FROM Pacientes

SELECT * FROM TipoUsuario

SELECT * FROM Usuarios

-- 1 -- Seleciona o Nome do Paciente, o nome do Médico, a Data da Consulta e também a situação da consulta.
SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico;