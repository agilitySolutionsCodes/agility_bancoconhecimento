USE [AgilityKBase]
GO

/****** Object:  Table [dbo].[Posts]    Script Date: 03/18/2013 15:11:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Posts](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NULL,
	[Conteudo] [varchar](max) NULL,
	[Anexo] [varchar](100) NULL,
	[Data] [date] NULL,
	[Hora] [char](5) NULL,
	[IdUsuario] [int] NULL,
	[IdContexto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_IdContexto] FOREIGN KEY([IdContexto])
REFERENCES [dbo].[Arvore] ([IdNode])
GO

ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_IdContexto]
GO


