USE senai_CZBooks

SELECT * FROM Instituicao

SELECT * FROM Livros

SELECT * FROM Categoria

SELECT * FROM Usuarios

SELECT * FROM tipoUsuario

SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'M�dico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situa��o
FROM Pacientes
FULL OUTER JOIN Consultas
ON Pacientes.IdPaciente = Consultas.IdPaciente
FULL OUTER JOIN Medicos
ON Medicos.IdMedico = Consultas.IdMedico;