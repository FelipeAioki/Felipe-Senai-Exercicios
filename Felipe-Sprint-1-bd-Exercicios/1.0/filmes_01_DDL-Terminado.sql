USE Filmes;

SELECT * FROM Generos;

SELECT Titulo, IdGenero,idFilme FROM Filmes;

SELECT IdFilme, Titulo AS Filme, Nome AS Genero FROM Filmes
INNER JOIN Generos
ON Filmes.IdGenero = Generos.IdGenero;