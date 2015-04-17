USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Categorias_Home]    Script Date: 04/15/2013 11:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  10/09/2012      
-- Descrição:  Lista Categorias Principais Home Page
-- NÚMERO DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================  

ALTER PROCEDURE [dbo].[STP_Lista_Categorias_Home]   

AS

BEGIN 
SET NOCOUNT ON   
		
		SELECT DISTINCT I.ImgCategoria, A.IdNode
		FROM Arvore A
		INNER JOIN ImgCategoria I
		ON A.IdNode = I.IdCategoria
END





GO


