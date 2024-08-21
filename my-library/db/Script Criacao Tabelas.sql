-- Deletar tabelas existentes se necessário
IF OBJECT_ID('dbo.Livro_Autor', 'U') IS NOT NULL DROP TABLE dbo.Livro_Autor;
IF OBJECT_ID('dbo.Livro_Assunto', 'U') IS NOT NULL DROP TABLE dbo.Livro_Assunto;
IF OBJECT_ID('dbo.Livro', 'U') IS NOT NULL DROP TABLE dbo.Livro;
IF OBJECT_ID('dbo.Autor', 'U') IS NOT NULL DROP TABLE dbo.Autor;
IF OBJECT_ID('dbo.Assunto', 'U') IS NOT NULL DROP TABLE dbo.Assunto;
IF OBJECT_ID('dbo.Livro_Valor', 'U') IS NOT NULL DROP TABLE dbo.Livro_Valor;
IF OBJECT_ID('dbo.Tipo_Venda', 'U') IS NOT NULL DROP TABLE dbo.Tipo_Venda;

-- Recriar tabelas com tamanhos corrigidos

-- Criação da tabela Livro
CREATE TABLE dbo.Livro (
    Codl INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Titulo VARCHAR(100) NOT NULL,   -- Aumentar o tamanho para comportar títulos maiores
    Editora VARCHAR(40) NOT NULL,
    Edicao INT NOT NULL,
    AnoPublicacao VARCHAR(4) NOT NULL
);

-- Criação da tabela Autor
CREATE TABLE dbo.Autor (
    CodAu INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Nome VARCHAR(40) NOT NULL
);

-- Criação da tabela Assunto
CREATE TABLE dbo.Assunto (
    CodAs INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
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

-- Criação da Tabela de Tipo Venda
CREATE TABLE dbo.Tipo_Venda (
    CodTv INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Descricao VARCHAR(50) NOT NULL   -- Aumentar o tamanho para comportar descrições maiores
);

CREATE TABLE dbo.Livro_Valor (
	TipoVenda_CodTv INT, 
	Livro_Codl INT, 
	Valor DECIMAL,	
    FOREIGN KEY (Livro_Codl) REFERENCES dbo.Livro(Codl),
    FOREIGN KEY (TipoVenda_CodTv) REFERENCES dbo.Tipo_Venda(CodTv) 
)