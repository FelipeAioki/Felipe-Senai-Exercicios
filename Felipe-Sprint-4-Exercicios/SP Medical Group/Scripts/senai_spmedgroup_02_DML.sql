USE SP_Medical_Group
INSERT INTO Cl�nica(Nome, Cnpj, Endere�o, Horarios) 
VALUES				('SP Medical Group','235.867.978.98', 'Avenida Bar�o Limeira 532 S�o Paulo SP', '06:00 �s 23:00');

INSERT INTO TipoUsuario(nomeTipo)
VALUES				 ('Administrador')
					,('M�dico')
					,('Paciente');

INSERT INTO Usuarios(IdTipoUsuario, nomeUsuario, Email, Senha)
VALUES				 ('1', 'Felipe', 'admin@admin', 'admin123')
					,('3', 'Mario', 'mario@gmail', 'mario123')
					,('3', 'Carlos', 'carlos@gmail.com', 'carlos123');

					INSERT INTO Usuarios(IdTipoUsuario, nomeUsuario, Email, Senha)
VALUES				 ('2', 'Ricardo', 'ricardo.lemos@spmedicalgroup.com.br', '43545')
					,('2', 'Roberto', 'roberto.possarle@spmedicalgroup.com.br', '2343242')
					,('1', 'Helena Strada', 'helena.souza@spmedicalgroup.com.br', '5453252');
UPDATE Usuarios
SET IdTipoUsuario = 2
WHERE nomeUsuario = 'Helena Strada';

INSERT INTO Pacientes(IdTipoUsuario, Nome, RG, CPF, Endere�o, Nascimento, Telefone)
VALUES				 ('3', 'Ligia', '43522543-5', '94839859000', 'Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000', '13/10/1983', '11 3456-7654')
					,('3', 'Alexandre', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200', '7/23/2001', '11 98765-6543')
					,('3', 'Fernando', '54636525-3', '16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200', '10/10/1978', '11 97208-4453')
					,('3', 'Henrique', '54366362-5', '14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '09/10/1978', '11 3456-6543')
					,('3', 'Jo�o', '32544444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380', '8/27/1975', '11 7656-6377')
					,('3', 'Bruno', '54566266-7', '79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001', '3/21/1972', '11 95436-8769')
					,('3', 'Mariana', '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '3/5/2018', '11 94958-43543');

INSERT INTO Especialidades(Nome)
VALUES				('Acupuntura')
					,('Anestesiologia')
					,('Angiologia')
					,('Cardiologia')
					,('Cirurgia Cardiovascular')
					,('Cirurgia da M�o')
					,('Cirurgia do Aparelho Digestivo')
					,('Cirurgia Geral')
					,('Cirurgia Pedi�trica')
					,('Cirurgia Pl�stica')
					,('Cirurgia Tor�cica')
					,('Cirurgia Vascular')
					,('Dermatologia')
					,('Radioterapia')
					,('Urologia')
					,('Pediatria')
					,('Psiquiatria');

INSERT INTO Medicos(IdTipoUsuario, IdEspecialidade, Nome)
VALUES				 ('2', '2', 'Ricardo Lemos')
					,('2', '17', 'Roberto Possarle')
					,('2', '16', 'Helena Strada');

INSERT INTO Consultas(IdMedico, IdPaciente, Data_da_consulta,Situa��o)
VALUES				 ('3', '7', '20/01/2020-15:00','Realizada')
					,('2', '2', '06/01/2020-10:00','Cancelada')
					,('2', '3', '07/02/2020-11:00','Realizada')
					,('2', '2', '06/02/2018-10:00','Realizada')
					,('1', '4', '07/02/2019-11:00','Cancelada')
					,('3', '7', '08/03/2020-15:00','Agendada')
					,('1', '4', '09/03/2020-11:00','Agendada');