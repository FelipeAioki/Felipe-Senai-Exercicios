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


--Listar todos os jogos e seus respectivos estúdios;
SELECT NomeJogo ,NomeEstudio FROM Jogo
JOIN Estudio 
ON Jogo.IdEstudio = Estudio.IdEstudio	


--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
--todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT NomeEstudio, NomeJogo FROM Jogo 
RIGHT JOIN Estudio
ON Estudio.IdEstudio = Jogo.IdEstudio


--Buscar um usuário por e-mail e senha (login);
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
