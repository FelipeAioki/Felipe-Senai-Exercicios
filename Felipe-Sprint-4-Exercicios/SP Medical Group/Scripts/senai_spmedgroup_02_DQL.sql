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

SELECT idNome, Nome, Sobrenome, Nascimento FROM Consultas WHERE IdPaciente = 1;

SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico WHERE Pacientes.IdPaciente = 4;

SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico;

SELECT Consultas.Situação, Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação, Especialidades.Nome
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico
LEFT JOIN Especialidades
ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade;

SELECT Especialidades.Nome AS 'Especialidade', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação, Clínica.Endereço AS 'Endereço' FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico LEFT JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade FULL OUTER JOIN Clínica on Clínica.IdClinica = Clínica.IdClinica


SELECT Especialidades.Nome AS 'Especialidade', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação, Clínica.Endereço AS 'Endereço' FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico FULL OUTER JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade FULL OUTER JOIN Clínica on Clínica.IdClinica = Clínica.IdClinica  WHERE Pacientes.IdPaciente = @ID;