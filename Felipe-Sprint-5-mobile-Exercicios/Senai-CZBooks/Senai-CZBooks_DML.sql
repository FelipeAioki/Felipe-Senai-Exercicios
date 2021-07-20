USE senai_CZBooks

INSERT INTO Instituicao(Nome, Endereco) 
VALUES				('CZBooks', 'Avenida Bar�o Limeira 532 S�o Paulo SP');

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
					,('Cole��o')
					,('Conto')
					,('Fic�ao Cientif�ca')
					,('Poesia')
					,('Humor')
					,('Estudo')
					,('Aventura')
					,('Drama')
					,('Suspense');

INSERT INTO Livros(IdUsuario, idCategoria, titulo, sinopse, Data_de_publicacao, Preco)
VALUES				 ('2', '7', 'O Universo numa Casca de Noz', 'O universo numa casca de noz � leitura obrigat�ria para aqueles que querem se aventurar no que h� de mais instigante hoje na f�sica e para os que almejam ver como muitas vezes a teoria pode ser muito mais extraordin�ria do que a fic��o cient�fica.', '2001', 49.12)
					,('2', '7', 'A Roda do Tempo', 'A Roda do Tempo � uma s�rie de romances de alta fantasia escrita pelo autor americano Robert Jordan entre 1990 e 2013, contando com um total de 14 volumes, mais uma prequela lan�ada em 2004', '1990', 59.90)
					,('2', '7', 'Aristoteles e dante descobrem o segredo do universo', 'Em um ver�o tedioso, os jovens Arist�teles e Dante s�o unidos pelo acaso e, embora sejam completamente diferentes um do outro, iniciam uma amizade especial, do tipo que muda a vida das pessoas e dura para sempre.', '2014', 26.79)
					,('2', '7', 'Buracos Negros', 'Buracos Negros � um livro pequeno e enganosamente simples. Ele compreende duas palestras dadas por Stephen Hawking para a r�dio BBC, de 15 minutos cada, tentando explicar um assunto t�o complicado quanto buracos negros para um p�blico amplo', '2016', 18.89)
					,('2', '7', 'Uma Breve Hist�ria do Tempo', 'Uma Breve Hist�ria do Tempo: do Big Bang aos Buracos Negros, � um livro de divulga��o cient�fica escrito pelo Professor Stephen Hawking, publicado pela primeira vez em 1988.', '2015', 38.16);
