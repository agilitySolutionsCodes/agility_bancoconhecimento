USE [AgilityKBase]
GO

/****** Object:  Table [dbo].[ImgCategoria]    Script Date: 03/18/2013 15:04:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ImgCategoria](
	[ImgCategoria] [varchar](100) NULL,
	[IdCategoria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ImgCategoria]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Arvore] ([IdNode])
GO


