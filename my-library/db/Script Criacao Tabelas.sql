-- Deletar tabelas existentes se necessário
IF OBJECT_ID('dbo.Livro_Autor', 'U') IS NOT NULL DROP TABLE dbo.Livro_Autor;
IF OBJECT_ID('dbo.Livro_Assunto', 'U') IS NOT NULL DROP TABLE dbo.Livro_Assunto;
IF OBJECT_ID('dbo.Livro', 'U') IS NOT NULL DROP TABLE dbo.Livro;
IF OBJECT_ID('dbo.Autor', 'U') IS NOT NULL DROP TABLE dbo.Autor;
IF OBJECT_ID('dbo.Assunto', 'U') IS NOT NULL DROP TABLE dbo.Assunto;

-- Recriar tabelas com tamanhos corrigidos

-- Criação da tabela Livro
CREATE TABLE dbo.Livro (
    Codl INT PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL,   -- Aumentar o tamanho para comportar títulos maiores
    Editora VARCHAR(40) NOT NULL,
    Edicao INT NOT NULL,
    AnoPublicacao VARCHAR(4) NOT NULL
);

-- Criação da tabela Autor
CREATE TABLE dbo.Autor (
    CodAu INT PRIMARY KEY,
    Nome VARCHAR(40) NOT NULL
);

-- Criação da tabela Assunto
CREATE TABLE dbo.Assunto (
    codAs INT PRIMARY KEY,
    Descricao VARCHAR(50) NOT NULL   -- Aumentar o tamanho para comportar descrições maiores
);

-- Criação da tabela Livro_Autor
CREATE TABLE dbo.Livro_Autor (
    Livro_Codl INT,
    Autor_CodAu INT,
    PRIMARY KEY (Livro_Codl, Autor_CodAu),
    FOREIGN KEY (Livro_Codl) REFERENCES dbo.Livro(Codl) ON DELETE CASCADE,
    FOREIGN KEY (Autor_CodAu) REFERENCES dbo.Autor(CodAu) ON DELETE CASCADE
);

-- Criação da tabela Livro_Assunto
CREATE TABLE dbo.Livro_Assunto (
    Livro_Codl INT,
    Assunto_codAs INT,
    PRIMARY KEY (Livro_Codl, Assunto_codAs),
    FOREIGN KEY (Livro_Codl) REFERENCES dbo.Livro(Codl) ON DELETE CASCADE,
    FOREIGN KEY (Assunto_codAs) REFERENCES dbo.Assunto(codAs) ON DELETE CASCADE
);
