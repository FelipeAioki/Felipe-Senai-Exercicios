SELECT * FROM Habilidades;

--Conta
SELECT count(IdHab) AS Habilidades
FROM Habilidades


--M�dia
SELECT AVG(IdHab) AS Habilidades
FROM Habilidades;

--Soma
SELECT SUM(IdHab) AS Habilidades
FROM Habilidades;


--Pega a data atual
SELECT GETDATE();

--CALCULA DIAS
SELECT DATEDIFF ( DAY , 07 , 31 ) AS DIAS;

SELECT @@VERSION


