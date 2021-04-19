--DQL
USE InLock

 -- tudo de estudio
SELECT * FROM Estudio


--tudo de jogo
SELECT * FROM Jogo


--tudo de TipoUsuario
SELECT * FROM TipoUsuario


--Tudo de Usuario
SELECT * FROM Usuario


--Listar todos os jogos e seus respectivos est�dios;
SELECT NomeJogo ,NomeEstudio FROM Jogo
JOIN Estudio 
ON Jogo.IdEstudio = Estudio.IdEstudio

--Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar
--todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia;
SELECT NomeEstudio, NomeJogo FROM Jogo 
RIGHT JOIN Estudio
ON Estudio.IdEstudio = Jogo.IdEstudio


--Buscar um usu�rio por e-mail e senha (login);
SELECT Email, Senha FROM Usuario U
INNER JOIN TipoUsuario TU
ON u.IdTipoUsuario = TU.IdTipoUsuario
WHERE Email = 'cliente@cliente.com' AND Senha = 'cliente'


--Buscar um jogo pelo Id
SELECT * FROM Jogo
WHERE IdJogo = '2'


--Buscar um Estudio pelo ID
SELECT * FROM Estudio
WHERE IdEstudio = '3'

SELECT IdJogo ,NomeJogo , NomeEstudio, Descricao, valor, Lancamento FROM Jogo JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio