USE Senai_Hroads_Manha;

-- Tipos de habilidades
SELECT * FROM TipoHabilidades

-- Data
SELECT GETDATE();

-- 6. Selecionar todos os personagens;
SELECT * FROM Personagens;

-- 7. Selecionar todos as classes;
SELECT * FROM Classes;

-- 8. Selecionar somente o nome das classes;
SELECT Nome FROM Classes;

-- 9. Selecionar todas as habilidades;
SELECT * FROM Habilidades


-- 10. Realizar a contagem de quantas habilidades estão cadastradas;
SELECT 
    count(IdHab) AS Habilidades
FROM Habilidades

-- 11. Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT IdHab FROM Habilidades
ORDER BY IdHab ASC;

-- 12. Selecionar todos os tipos de habilidades;
SELECT Nome FROM TipoHabilidades;

-- 13. Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT Habilidades.Nome, TipoHabilidades.Nome
FROM Habilidades
LEFT JOIN TipoHabilidades
on Habilidades.IdTipo = TipoHabilidades.IdTipoHab;

-- 14. Selecionar todos os personagens e suas respectivas classes;
Select Personagens.Nome, Classes.Nome
From Personagens
LEFT JOIN Classes
ON Personagens.IdClasse = Classes.IdClasse;

-- 15. Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
Select Personagens.Nome, Classes.Nome
FROM Personagens
FULL OUTER JOIN Classes
ON Personagens.IdClasse = Classes.IdClasse;

-- 16. Selecionar todas as classes e suas respectivas habilidades;
SELECT * FROM ClassesHabilidades

-- 17. Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT Habilidades.Nome, Classes.Nome
FROM Habilidades
INNER JOIN ClassesHabilidades
ON ClassesHabilidades.IdHab = Habilidades.IdHab
INNER JOIN Classes
ON Classes.IdClasse = ClassesHabilidades.IdClasse;

-- 18. Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT Habilidades.Nome, Classes.Nome
FROM Habilidades
FULL OUTER JOIN ClassesHabilidades
ON ClassesHabilidades.IdHab = Habilidades.IdHab
FULL OUTER JOIN Classes
ON Classes.IdClasse = ClassesHabilidades.IdClasse;

SELECT Email, Senha FROM Usuario U
INNER JOIN TipoUsuario TU
ON u.IdTipoUsuario = TU.IdTipoUsuario
WHERE Email = 'cliente@cliente.com' AND Senha = 'cliente';




