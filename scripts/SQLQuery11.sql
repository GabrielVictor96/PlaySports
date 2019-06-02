SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[Id] [uniqueidentifier] NOT NULL,
	[Criador] [varchar](100) NOT NULL,
	[Membro1] [varchar](100),
	[Membro2] [varchar](100),
	[Membro3] [varchar](100),
	[Membro4] [varchar](100),
	[Membro5] [varchar](100),
	[Membro6] [varchar](100),
	[Membro7] [varchar](100),
	[Membro8] [varchar](100),
	[Membro9] [varchar](100),
	[Atividade] [varchar](100),
	[Local] [varchar](100) NOT NULL,
	[Data] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO