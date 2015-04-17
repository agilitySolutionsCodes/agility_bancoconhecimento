USE [AgilityKBase]
GO

/****** Object:  Table [dbo].[Arvore]    Script Date: 03/18/2013 15:03:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Arvore](
	[IdNode] [int] IDENTITY(1,1) NOT NULL,
	[DescricaoNode] [nvarchar](50) NOT NULL,
	[AbaixoPai] [int] NOT NULL,
	[Profundidade] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


