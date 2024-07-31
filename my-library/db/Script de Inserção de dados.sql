-- Inserir dados na tabela Livro
INSERT INTO dbo.Livro (Codl, Titulo, Editora, Edicao, AnoPublicacao) VALUES
(1, 'Aprendendo SQL Server', 'Editora ABC', 1, '2023'),
(2, 'Desenvolvimento Web com ASP.NET', 'Editora XYZ', 2, '2022'),
(3, 'Programação C# Avançada', 'Editora DEF', 3, '2024'),
(4, 'Introdução ao Desenvolvimento de Software', 'Editora GHI', 1, '2021'),
(5, 'Estruturas de Dados em C#', 'Editora JKL', 2, '2023'),
(6, 'Design Patterns em .NET', 'Editora MNO', 1, '2022'),
(7, 'Algoritmos e Lógica de Programação', 'Editora PQR', 3, '2024'),
(8, 'C# e SQL Server', 'Editora STU', 1, '2023');

-- Inserir dados na tabela Autor
INSERT INTO dbo.Autor (CodAu, Nome) VALUES
(1, 'João da Silva'),
(2, 'Maria Oliveira'),
(3, 'Pedro Santos'),
(4, 'Ana Costa'),
(5, 'Carlos Pereira'),
(6, 'Juliana Lima'),
(7, 'Ricardo Almeida'),
(8, 'Luciana Ferreira');

-- Inserir dados na tabela Assunto
INSERT INTO dbo.Assunto (codAs, Descricao) VALUES
(1, 'Banco de Dados'),
(2, 'Desenvolvimento Web'),
(3, 'Programação'),
(4, 'Arquitetura de Software'),
(5, 'Algoritmos'),
(6, 'Lógica de Programação'),
(7, 'Desenvolvimento de Sistemas'),
(8, 'Programação Orientada a Objetos');

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
