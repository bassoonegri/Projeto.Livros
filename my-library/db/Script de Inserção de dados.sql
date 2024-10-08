
-- Inserir dados na tabela Livro
INSERT INTO dbo.Livro (Titulo, Editora, Edicao, AnoPublicacao) VALUES
('Aprendendo SQL Server', 'Editora ABC', 1, '2023'),
('Desenvolvimento Web com ASP.NET', 'Editora XYZ', 2, '2022'),
('Programa��o C# Avan�ada', 'Editora DEF', 3, '2024'),
('Introdu��o ao Desenvolvimento de Software', 'Editora GHI', 1, '2021'),
('Estruturas de Dados em C#', 'Editora JKL', 2, '2023'),
('Design Patterns em .NET', 'Editora MNO', 1, '2022'),
('Algoritmos e L�gica de Programa��o', 'Editora PQR', 3, '2024'),
('C# e SQL Server', 'Editora STU', 1, '2023'),
('Cem Anos de Solid�o', 'Editora A', 1, '1967'),
('Orgulho e Preconceito', 'Editora B', 3, '1813'),
('1984', 'Editora C', 5, '1949'),
('Harry Potter e a Pedra Filosofal', 'Editora D', 1, '1997'),
('Assassinato no Expresso do Oriente', 'Editora E', 2, '1934'),
('O Senhor dos An�is', 'Editora F', 2, '1954'),
('O Sol Tamb�m se Levanta', 'Editora G', 1, '1926'),
('O Grande Gatsby', 'Editora H', 1, '1925'),
('As Aventuras de Tom Sawyer', 'Editora I', 4, '1876'),
('Um Conto de Duas Cidades', 'Editora J', 1, '1859'),
('Guerra e Paz', 'Editora K', 3, '1869'),
('Os Irm�os Karamazov', 'Editora L', 1, '1880'),
('A Divina Com�dia', 'Editora M', 1, '1320'),
('O Retrato de Dorian Gray', 'Editora N', 2, '1890'),
('Ulysses', 'Editora O', 1, '1922');

-- Inserir dados na tabela Autor
INSERT INTO dbo.Autor (Nome) VALUES
('Jo�o da Silva'),
('Maria Oliveira'),
('Pedro Santos'),
('Ana Costa'),
('Carlos Pereira'),
('Juliana Lima'),
('Ricardo Almeida'),
('Luciana Ferreira'),
('Gabriel Garcia Marquez'),
('Jane Austen'),
('George Orwell'),
('J.K. Rowling'),
('Agatha Christie'),
('J.R.R. Tolkien'),
('Ernest Hemingway'),
('F. Scott Fitzgerald'),
('Mark Twain'),
('Charles Dickens'),
('Leo Tolstoy'),
('Emily Dickinson'),
('Virginia Woolf'),
('James Joyce'),
('Oscar Wilde');

-- Inserir dados na tabela Assunto
INSERT INTO dbo.Assunto (Descricao) VALUES
('Banco de Dados'),
('Desenvolvimento Web'),
('Programa��o'),
('Arquitetura de Software'),
('Algoritmos'),
('L�gica de Programa��o'),
('Desenvolvimento de Sistemas'),
('Programa��o Orientada a Objetos'),
('Fic��o Cient�fica'),
('Romance'),
('Mist�rio'),
('Fantasia'),
('Biografia'),
('Hist�ria'),
('Autoajuda'),
('Drama'),
('Poesia'),
('Psicologia'),
('Tecnologia'),
('Neg�cios'),
('Sa�de'),
('Aventura'),
('Religi�o'),
('Educa��o');

-- Inserir dados na tabela Livro_Autor
INSERT INTO dbo.Livro_Autor (Livro_Codl, Autor_CodAu) VALUES
(1, 1),
(1, 2),
(2, 2),
(3, 3),
(4, 4),
(4, 5),
(5, 6),
(6, 7),
(7, 8),
(8, 4),
(8, 6),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(13, 13),
(14, 14),
(15, 15),
(16, 16),
(17, 17),
(18, 18),
(19, 19),
(20, 20),
(21, 21),
(22, 22),
(23, 23);

-- Inserir dados na tabela Livro_Assunto
INSERT INTO dbo.Livro_Assunto (Livro_Codl, Assunto_codAs) VALUES
(1, 1),
(2, 2),
(3, 3),
(2, 1),
(4, 4),
(4, 7),
(5, 5),
(5, 8),
(6, 4),
(6, 8),
(7, 6),
(7, 7),
(8, 5),
(8, 8),
(9, 9),
(10, 10),
(11, 3),
(12, 4),
(13, 11),
(14, 12),
(15, 13),
(16, 14),
(17, 15),
(18, 16),
(19, 10),
(20, 12),
(21, 17),
(22, 18),
(23, 19);

-- Inserir dados na tabela Tipo_Venda
INSERT INTO dbo.Tipo_Venda (Descricao) VALUES
('Venda Normal'),
('Venda Promocional'),
('Venda Especial'),
('Venda Online'),
('Venda F�sica'),
('Leil�o'),
('Pr�-venda'),
('Venda Exclusiva'),
('Venda Internacional'),
('Venda Nacional'),
('Venda de Colecionador'),
('Venda de Segunda M�o'),
('Venda por Assinatura'),
('Venda por Doa��o'),
('Venda para Bibliotecas');

-- Inserir dados na tabela Livro_Valor
INSERT INTO dbo.Livro_Valor (TipoVenda_CodTv, Livro_Codl, Valor) VALUES
(1, 1, 49.90),
(2, 2, 29.90),
(3, 3, 19.90),
(4, 4, 39.90),
(5, 5, 59.90),
(6, 6, 89.90),
(7, 7, 99.90),
(8, 8, 79.90),
(9, 9, 25.00),
(10, 10, 30.00),
(11, 11, 15.00),
(12, 12, 20.00),
(13, 13, 10.00),
(14, 14, 35.00),
(15, 15, 45.00),
(1, 16, 50.00),
(2, 17, 55.00),
(3, 18, 60.00),
(4, 19, 65.00),
(5, 20, 70.00),
(6, 21, 75.00),
(7, 22, 80.00),
(8, 23, 85.00);
