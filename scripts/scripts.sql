USE [master]
GO
/****** Object:  Database [playsports]    Script Date: 16/06/2019 21:47:24 ******/
CREATE DATABASE [playsports]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'playsports', FILENAME = N'c:\databases\playsports\playsports.mdf' , SIZE = 8192KB , MAXSIZE = 20971520KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'playsports_log', FILENAME = N'c:\databases\playsports\playsports_log.ldf' , SIZE = 8192KB , MAXSIZE = 1048576KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [playsports] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [playsports].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [playsports] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [playsports] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [playsports] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [playsports] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [playsports] SET ARITHABORT OFF 
GO
ALTER DATABASE [playsports] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [playsports] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [playsports] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [playsports] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [playsports] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [playsports] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [playsports] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [playsports] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [playsports] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [playsports] SET  DISABLE_BROKER 
GO
ALTER DATABASE [playsports] SET AUTO_UPDATE_STATISTICS_ASYNC ON 
GO
ALTER DATABASE [playsports] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [playsports] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [playsports] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [playsports] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [playsports] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [playsports] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [playsports] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [playsports] SET  MULTI_USER 
GO
ALTER DATABASE [playsports] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [playsports] SET DB_CHAINING OFF 
GO
ALTER DATABASE [playsports] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [playsports] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [playsports] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'playsports', N'ON'
GO
ALTER DATABASE [playsports] SET QUERY_STORE = OFF
GO
USE [playsports]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 16/06/2019 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[Id] [uniqueidentifier] NOT NULL,
	[Criador] [varchar](100) NOT NULL,
	[Membro1] [varchar](100) NULL,
	[Membro2] [varchar](100) NULL,
	[Membro3] [varchar](100) NULL,
	[Membro4] [varchar](100) NULL,
	[Membro5] [varchar](100) NULL,
	[Membro6] [varchar](100) NULL,
	[Membro7] [varchar](100) NULL,
	[Membro8] [varchar](100) NULL,
	[Membro9] [varchar](100) NULL,
	[Atividade] [varchar](100) NULL,
	[Local] [varchar](100) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Ativo] [varchar](5) NULL,
 CONSTRAINT [PK__Agenda__3214EC07E24062EF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 16/06/2019 21:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[Id] [uniqueidentifier] NOT NULL,
	[UsuarioCurtiu] [varchar](100) NOT NULL,
	[UsuarioCurtido] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 16/06/2019 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[Id] [uniqueidentifier] NOT NULL,
	[AgendaId] [varchar](100) NOT NULL,
	[Criador] [varchar](100) NOT NULL,
	[NotaMembro1] [varchar](100) NULL,
	[NotaMembro2] [varchar](100) NULL,
	[NotaMembro3] [varchar](100) NULL,
	[NotaMembro4] [varchar](100) NULL,
	[NotaMembro5] [varchar](100) NULL,
	[NotaMembro6] [varchar](100) NULL,
	[NotaMembro7] [varchar](100) NULL,
	[NotaMembro8] [varchar](100) NULL,
	[NotaMembro9] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NovoMatch]    Script Date: 16/06/2019 21:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NovoMatch](
	[Id] [uniqueidentifier] NOT NULL,
	[UsuarioPrimario] [varchar](100) NOT NULL,
	[UsuarioSecundario] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	[Imagem] [image] NOT NULL,
	[Denuncia] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SpAgenda_AddAgenda]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpAgenda_AddAgenda] 
    @id uniqueidentifier,
	@criador varchar(100),
	@membro1 varchar(100),
	@membro2 varchar(100),
	@membro3 varchar(100),
	@membro4 varchar(100),
	@membro5 varchar(100),
	@membro6 varchar(100),
	@membro7 varchar(100),
	@membro8 varchar(100),
	@membro9 varchar(100),
	@atividade varchar(100),
	@local varchar(100),
	@data datetime,
	@ativo varchar(5)
AS
BEGIN
	INSERT INTO PlaySports.dbo.Agenda 
	VALUES(@id, @criador, @membro1, @membro2, @membro3, @membro4, @membro5, @membro6, @membro7, @membro8, @membro9, @atividade, @local, @data, @ativo);
END;
GO
/****** Object:  StoredProcedure [dbo].[SpAgenda_Detalhes]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpAgenda_Detalhes]  
    @id uniqueidentifier = NULL
AS
BEGIN
	SELECT 
		u.Criador,
		u.Membro1,
		u.Membro2,
		u.Membro3,
		u.Membro4,
		u.Membro5,
		u.Membro6,
		u.Membro7,
		u.Membro8,
		u.Membro9,
		u.Atividade,
		u.Local,
		u.Data		
	FROM PlaySports.dbo.Agenda u WHERE u.Id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpAgenda_Edit]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpAgenda_Edit] 
    @id uniqueidentifier,
	@ativo varchar(5)

AS
BEGIN
	UPDATE PlaySports.dbo.Agenda
	SET ativo=@ativo
	WHERE Id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpAgenda_EditAgenda]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpAgenda_EditAgenda] 
    @id uniqueidentifier,
	@criador varchar(100),
	@membro1 varchar(100),
	@membro2 varchar(100),
	@membro3 varchar(100),
	@membro4 varchar(100),
	@membro5 varchar(100),
	@membro6 varchar(100),
	@membro7 varchar(100),
	@membro8 varchar(100),
	@membro9 varchar(100),
	@atividade varchar(100),
	@local varchar(100),
	@data datetime,
	@ativo varchar(5)
AS
BEGIN
	UPDATE PlaySports.dbo.Agenda 
	SET Criador=@criador, Membro1=@membro1, Membro2=@membro2, Membro3=@membro3, Membro4=@membro4, Membro5=@membro5, Membro6=@membro6, Membro7=@membro7, Membro8=@membro8, Membro9=@membro9, Atividade=@atividade, Local=@local, Data=@data, Ativo=@ativo
	WHERE Id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpAgenda_Procurar]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpAgenda_Procurar]  
    @criador varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.Criador,
		u.Membro1,
		u.Membro2,
		u.Membro3,
		u.Membro4,
		u.Membro5,
		u.Membro6,
		u.Membro7,
		u.Membro8,
		u.Membro9,
		u.Atividade,
		u.Local,
		u.Data		
	FROM PlaySports.dbo.Agenda u WHERE (u.Criador = @criador or u.Membro1 = @criador or u.Membro2 = @criador or u.Membro3 = @criador or u.Membro4 = @criador or u.Membro5 = @criador or u.Membro6 = @criador or u.Membro7 = @criador or u.Membro8 = @criador or u.Membro9 = @criador) and u.Ativo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpAgenda_ProcurarMembro]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpAgenda_ProcurarMembro]  
    @criador varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.Criador,
		u.Membro1,
		u.Membro2,
		u.Membro3,
		u.Membro4,
		u.Membro5,
		u.Membro6,
		u.Membro7,
		u.Membro8,
		u.Membro9,
		u.Atividade,
		u.Local,
		u.Data		
	FROM PlaySports.dbo.Agenda u WHERE (u.Criador = @criador or u.Membro1 = @criador or u.Membro2 = @criador or u.Membro3 = @criador or u.Membro4 = @criador or u.Membro5 = @criador or u.Membro6 = @criador or u.Membro7 = @criador or u.Membro8 = @criador or u.Membro9 = @criador) and u.Ativo = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpAuthentication_Login]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[SpMatch_AddMatch]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3. STORED PROCEDURES
-- 3.1 ADD
CREATE PROCEDURE [dbo].[SpMatch_AddMatch] 
    @id uniqueidentifier,
	@usuarioCurtiu varchar(100),
	@usuarioCurtido varchar(100)
AS
BEGIN
	INSERT INTO PlaySports.dbo.Match 
	VALUES(@id, @usuarioCurtiu, @usuarioCurtido);
END;
GO
/****** Object:  StoredProcedure [dbo].[SpMatch_ProcurarMatch]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpMatch_ProcurarMatch]  
    @usuarioCurtiu varchar(100) = NULL,
	@usuarioCurtido varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.UsuarioCurtiu,
		u.UsuarioCurtido		
	FROM PlaySports.dbo.Match u WHERE u.UsuarioCurtiu = @usuarioCurtiu and u.UsuarioCurtido = @usuarioCurtido;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpNota_AddNota]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpNota_AddNota] 
    @id uniqueidentifier,
	@agendaId varchar(100),
	@criador varchar(100),
	@notaMembro1 varchar(100),
	@notaMembro2 varchar(100),
	@notaMembro3 varchar(100),
	@notaMembro4 varchar(100),
	@notaMembro5 varchar(100),
	@notaMembro6 varchar(100),
	@notaMembro7 varchar(100),
	@notaMembro8 varchar(100),
	@notaMembro9 varchar(100)
AS
BEGIN
	INSERT INTO PlaySports.dbo.Nota 
	VALUES(@id, @agendaId, @criador, @notaMembro1, @notaMembro2, @notaMembro3, @notaMembro4, @notaMembro5, @notaMembro6, @notaMembro7, @notaMembro8, @notaMembro9);
END;
GO
/****** Object:  StoredProcedure [dbo].[SpNota_Detalhes]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpNota_Detalhes]  
    @agendaId varchar(100)
AS
BEGIN
	SELECT 
		u.Id,
		u.AgendaId,
		u.Criador,
		u.NotaMembro1,
		u.NotaMembro2,
		u.NotaMembro3,
		u.NotaMembro4,
		u.NotaMembro5,
		u.NotaMembro6,
		u.NotaMembro7,
		u.NotaMembro8,
		u.NotaMembro9
	FROM PlaySports.dbo.Nota u WHERE u.AgendaId = @agendaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpNovoMatch_AddNovoMatch]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3. STORED PROCEDURES
-- 3.1 ADD
CREATE PROCEDURE [dbo].[SpNovoMatch_AddNovoMatch] 
    @id uniqueidentifier,
	@usuarioPrimario varchar(100),
	@usuarioSecundario varchar(100)
AS
BEGIN
	INSERT INTO PlaySports.dbo.NovoMatch 
	VALUES(@id, @usuarioPrimario, @usuarioSecundario);
END;
GO
/****** Object:  StoredProcedure [dbo].[SpNovoMatch_ProcurarUsuarioPrimario]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpNovoMatch_ProcurarUsuarioPrimario]  
    @usuarioPrimario varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.UsuarioPrimario,
		u.UsuarioSecundario		
	FROM PlaySports.dbo.NovoMatch u WHERE u.UsuarioPrimario = @usuarioPrimario;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpNovoMatch_ProcurarUsuarioSecundario]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpNovoMatch_ProcurarUsuarioSecundario]  
    @usuarioSecundario varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.UsuarioPrimario,
		u.UsuarioSecundario		
	FROM PlaySports.dbo.NovoMatch u WHERE u.UsuarioSecundario = @usuarioSecundario;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpUser_Add]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@imagem image,
	@denuncia varchar(100)
AS
BEGIN
	INSERT INTO PlaySports.dbo.Users 
	VALUES(@id, @nome, @sexo, @dataNascimento, @esporte, @nivel, @localizacao, @login, @senha, @imagem, @denuncia);
END;
GO
/****** Object:  StoredProcedure [dbo].[SpUser_Delete]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3.3 DELETE
CREATE PROCEDURE [dbo].[SpUser_Delete] 
    @id uniqueidentifier
AS
BEGIN
	DELETE FROM PlaySports.dbo.Users WHERE Id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpUser_Edit]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpUser_Edit] 
    @id uniqueidentifier,
	@nome varchar(100),
	@sexo varchar(20),
	@dataNascimento datetime,
	@esporte varchar(20),
	@nivel varchar(15), 
	@localizacao varchar(60),
	@login varchar(60),
	@imagem image,
	@denuncia varchar(100)
AS
BEGIN
	UPDATE PlaySports.dbo.Users 
	SET Nome=@nome, Sexo=@sexo, DataNascimento=@dataNascimento, Esporte=@esporte, Nivel=@nivel, Localizacao=@localizacao, Login=@login, Imagem=@imagem, Denuncia = @denuncia
	WHERE Id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpUser_GetAll]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[SpUser_GetById]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		u.Imagem,
		u.Denuncia		
	FROM PlaySports.dbo.Users u WHERE u.Id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpUser_GetByLogin]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[SpUser_GetByMatch]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3.5 SELECT BY MATCH
CREATE PROCEDURE [dbo].[SpUser_GetByMatch]    
   @esporte varchar(20) = NULL,
   @localizacao varchar(60) = NULL
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
	FROM PlaySports.dbo.Users u WHERE u.Esporte = @esporte and u.Localizacao = @localizacao;
END;
GO
/****** Object:  StoredProcedure [dbo].[SpUser_GetByNome]    Script Date: 16/06/2019 21:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpUser_GetByNome]  
    @nome varchar(100) = NULL
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
	FROM PlaySports.dbo.Users u WHERE u.Nome = @nome;
END;
GO
USE [master]
GO
ALTER DATABASE [playsports] SET  READ_WRITE 
GO
