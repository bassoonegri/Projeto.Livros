-- Inserir dados na tabela Livro
INSERT INTO dbo.Livro ( Titulo, Editora, Edicao, AnoPublicacao) VALUES
('Aprendendo SQL Server', 'Editora ABC', 1, '2023'),
('Desenvolvimento Web com ASP.NET', 'Editora XYZ', 2, '2022'),
('Programação C# Avançada', 'Editora DEF', 3, '2024'),
('Introdução ao Desenvolvimento de Software', 'Editora GHI', 1, '2021'),
('Estruturas de Dados em C#', 'Editora JKL', 2, '2023'),
('Design Patterns em .NET', 'Editora MNO', 1, '2022'),
('Algoritmos e Lógica de Programação', 'Editora PQR', 3, '2024'),
('C# e SQL Server', 'Editora STU', 1, '2023');

-- Inserir dados na tabela Autor
INSERT INTO dbo.Autor ( Nome) VALUES
('João da Silva'),
('Maria Oliveira'),
('Pedro Santos'),
('Ana Costa'),
('Carlos Pereira'),
('Juliana Lima'),
('Ricardo Almeida'),
('Luciana Ferreira');

-- Inserir dados na tabela Assunto
INSERT INTO dbo.Assunto ( Descricao) VALUES
('Banco de Dados'),
('Desenvolvimento Web'),
('Programação'),
('Arquitetura de Software'),
('Algoritmos'),
('Lógica de Programação'),
('Desenvolvimento de Sistemas'),
('Programação Orientada a Objetos');

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
(8, 6);

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
(8, 8);
