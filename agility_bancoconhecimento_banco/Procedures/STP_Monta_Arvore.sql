GO

/****** Object:  StoredProcedure [dbo].[STP_Monta_Arvore]    Script Date: 06/30/2015 16:08:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  13/09/2012      
-- Descrição:	  Constrói a árvore e sua hierarquia

-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================    

ALTER PROCEDURE [dbo].[STP_Monta_Arvore] AS
BEGIN 
	
	    WITH Iterate_Nodes_Recursive AS 
	(
		SELECT DescricaoNode, IdNode, AbaixoPai, 0 AS Profundidade 
		FROM   Arvore 
		WHERE (IdNode IN(SELECT IdNode FROM Arvore  
		WHERE (AbaixoPai = 0))) 
		UNION ALL 
		SELECT Super.DescricaoNode, Super.IdNode,Super.AbaixoPai, 
			   Sub.Profundidade + 1 AS LEVEL_DEPTH 
		FROM Arvore AS Super INNER JOIN Iterate_Nodes_Recursive AS Sub ON 
		Sub.IdNode = Super.AbaixoPai
	) 

	SELECT DescricaoNode, IdNode, CONVERT(INT, AbaixoPai) AS AbaixoPai, Profundidade 
	FROM Iterate_Nodes_Recursive 
	ORDER BY Profundidade 

END








GO


