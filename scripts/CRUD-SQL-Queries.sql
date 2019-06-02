-- 1. CRIAR BANCO
CREATE DATABASE PlaySports;
GO

USE PlaySports;
GO

-- 2. CRIAR TABELA
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Sexo] [varchar](20) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Esporte] [varchar](20) NOT NULL,
	[Nivel] [varchar](15) NOT NULL,
	[Localizacao] [varchar](60) NOT NULL,
	[Login] [varchar](60) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Imagem] [image] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- 3. STORED PROCEDURES
-- 3.1 ADD
CREATE PROCEDURE [dbo].[SpUser_Add] 
    @id uniqueidentifier,
	@nome varchar(100),
	@sexo varchar(20),
	@dataNascimento datetime,
	@esporte varchar(20),
	@nivel varchar(15),
	@localizacao varchar(60),
	@login varchar(60),
	@senha varchar(100),
	@imagem image
AS
BEGIN
	INSERT INTO PlaySports.dbo.Users 
	VALUES(@id, @nome, @sexo, @dataNascimento, @esporte, @nivel, @localizacao, @login, @senha, @imagem);
END;
GO

-- 3.2 EDIT
CREATE PROCEDURE [dbo].[SpUser_Edit] 
    @id uniqueidentifier,
	@nome varchar(100),
	@sexo varchar(20),
	@dataNascimento datetime,
	@esporte varchar(20),
	@nivel varchar(15), 
	@localizacao varchar(60),
	@login varchar(60),
	@imagem image
AS
BEGIN
	UPDATE PlaySports.dbo.Users 
	SET Nome=@nome, Sexo=@sexo, DataNascimento=@dataNascimento, Esporte=@esporte, Nivel=@nivel, Localizacao=@localizacao, Login=@login, Imagem=@imagem
	WHERE Id = @id;
END;
GO

-- 3.3 DELETE
CREATE PROCEDURE [dbo].[SpUser_Delete] 
    @id uniqueidentifier
AS
BEGIN
	DELETE FROM PlaySports.dbo.Users WHERE Id = @id;
END;
GO

-- 3.4 SELECT ALL
CREATE PROCEDURE [dbo].[SpUser_GetAll] 
AS
SELECT 
	u.Id,
	u.Nome,
	u.Sexo,
	u.DataNascimento,
	u.Esporte,
	u.Nivel,
	u.Localizacao,
	u.Login,
	u.Imagem
FROM PlaySports.dbo.Users u
GO

-- 3.5 SELECT BY ID
CREATE PROCEDURE [dbo].[SpUser_GetById]    
    @id uniqueidentifier = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.Nome,
		u.Sexo,
		u.DataNascimento,
		u.Esporte,
		u.Nivel,
		u.Localizacao,		
		u.Login,
		u.Imagem		
	FROM PlaySports.dbo.Users u WHERE u.Id = @id;
END;
GO

-- 3.6 SELECT BY LOGIN
CREATE PROCEDURE [dbo].[SpUser_GetByLogin]  
    @login varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.Nome,
		u.Sexo,
		u.DataNascimento,
		u.Esporte,
		u.Nivel,
		u.Localizacao,		
		u.Login,
		u.Imagem		
	FROM PlaySports.dbo.Users u WHERE u.Login = @login;
END;
GO

-- 3.7 USER AUTHENTICATE
CREATE PROCEDURE [dbo].[SpAuthentication_Login]
	@login varchar(60),
	@senha varchar(100)
AS
BEGIN
	SELECT Id, Nome, Sexo, DataNascimento, Esporte, Nivel, Localizacao, Login, Imagem
	FROM PlaySports.dbo.Users
	WHERE Login=@login AND Senha=@senha;
END;
GO