USE [AgilityKBase]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 03/18/2013 15:12:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NULL,
	[Email] [varchar](50) NULL,
	[Telefone] [varchar](8) NULL,
	[Ramal] [char](2) NULL,
	[Celular] [varchar](9) NULL,
	[NomeSkype] [varchar](20) NULL,
	[Foto] [varchar](100) NULL,
	[Senha] [varchar](30) NOT NULL,
	[Imagem] [varchar](100) NULL,
	[Departamento] [varchar](70) NOT NULL,
	[Ativo] [bit] NULL,
	[Administrador] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('''') FOR [Departamento]
GO


