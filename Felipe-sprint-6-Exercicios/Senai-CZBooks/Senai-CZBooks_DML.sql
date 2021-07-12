USE senai_CZBooks

INSERT INTO Instituicao(Nome, Endereco) 
VALUES				('CZBooks', 'Avenida Barão Limeira 532 São Paulo SP');

INSERT INTO TipoUsuario(nomeTipo)
VALUES				 ('Administrador')
					,('Autor')
					,('Cliente');

INSERT INTO Usuarios(IdTipoUsuario, nome, Email, Senha)
VALUES				 ('1', 'Felipe', 'admin@admin.com', 'admin123')
					,('2', 'Saulo', 'autor@autor.com', 'autor123')
					,('3', 'Caique', 'cliente@cliente.com', 'cliente123');

INSERT INTO Categoria(nome)
VALUES				('Biografia')
					,('Coleção')
					,('Conto')
					,('Ficçao Cientifíca')
					,('Poesia')
					,('Humor')
					,('Estudo')
					,('Aventura')
					,('Drama')
					,('Suspense');

INSERT INTO Livros(IdUsuario, idCategoria, titulo, sinopse, Data_de_publicacao, Preco)
VALUES				 ('2', '7', 'O Universo numa Casca de Noz', 'O universo numa casca de noz é leitura obrigatória para aqueles que querem se aventurar no que há de mais instigante hoje na física e para os que almejam ver como muitas vezes a teoria pode ser muito mais extraordinária do que a ficção científica.', '2001', 49.12)
					,('2', '7', 'A Roda do Tempo', 'A Roda do Tempo é uma série de romances de alta fantasia escrita pelo autor americano Robert Jordan entre 1990 e 2013, contando com um total de 14 volumes, mais uma prequela lançada em 2004', '1990', 59.90)
					,('2', '7', 'Aristoteles e dante descobrem o segredo do universo', 'Em um verão tedioso, os jovens Aristóteles e Dante são unidos pelo acaso e, embora sejam completamente diferentes um do outro, iniciam uma amizade especial, do tipo que muda a vida das pessoas e dura para sempre.', '2014', 26.79)
					,('2', '7', 'Buracos Negros', 'Buracos Negros é um livro pequeno e enganosamente simples. Ele compreende duas palestras dadas por Stephen Hawking para a rádio BBC, de 15 minutos cada, tentando explicar um assunto tão complicado quanto buracos negros para um público amplo', '2016', 18.89)
					,('2', '7', 'Uma Breve História do Tempo', 'Uma Breve História do Tempo: do Big Bang aos Buracos Negros, é um livro de divulgação científica escrito pelo Professor Stephen Hawking, publicado pela primeira vez em 1988.', '2015', 38.16);
