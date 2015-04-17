USE [AgilityKBase]
GO

/****** Object:  Table [dbo].[PostArvore]    Script Date: 03/18/2013 15:04:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PostArvore](
	[KIdNode] [int] NULL,
	[KIdPost] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PostArvore]  WITH CHECK ADD FOREIGN KEY([KIdNode])
REFERENCES [dbo].[Arvore] ([IdNode])
GO

ALTER TABLE [dbo].[PostArvore]  WITH CHECK ADD FOREIGN KEY([KIdPost])
REFERENCES [dbo].[Posts] ([IdPost])
GO


