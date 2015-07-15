GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Categoria]    Script Date: 06/30/2015 16:04:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  15/03/2013      
-- Descrição:	  Incluir nova Categoria   

-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

CREATE PROCEDURE [dbo].[STP_Incluir_Categoria]      

(     
	 @P_IdNode INTEGER = NULL,
	 @P_DescricaoNode VARCHAR(50),
	 @P_AbaixoPai INT,
	 @P_Profundidade INT
)

AS      
BEGIN      
SET NOCOUNT ON
		If(SELECT COUNT(*) FROM Arvore (NOLOCK) WHERE IdNode = @P_IdNode) = 0 BEGIN
			INSERT INTO Arvore(DescricaoNode, AbaixoPai, Profundidade) 
			VALUES(@P_DescricaoNode, @P_AbaixoPai, @P_Profundidade)		
		END	
END      




GO


