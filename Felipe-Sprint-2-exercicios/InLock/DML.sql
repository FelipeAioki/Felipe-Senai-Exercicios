--DML
USE InLock
GO
INSERT INTO Estudio(NomeEstudio)
VALUES				('Blizzard')
				   ,('Rockstar Studios')
				   ,('Square Enix');
GO

INSERT INTO Jogo (NomeJogo,     IdEstudio, Lancamento,Valor,Descricao)
VALUES			 ('Diablo 3',   1		,  '15/05/2012',  99.00  ,'� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.')

				,('RedDeadRedemption 2',	 2		,'26/10/2018',	120.00, 'jogo eletr�nico de a��o-aventura western');
GO

INSERT INTO TipoUsuario(Titulo)
VALUES					('Administrador')
						,('Cliente');
GO

INSERT INTO Usuario(IdTipoUsuario, Email			    , Senha)
VALUES				('1'		 ,'admin@admin.com' 	,  'admin')
				   ,('2'		 ,'cliente@cliente.com' , 'cliente');
GO
