GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Posts_Relativos ]    Script Date: 06/30/2015 16:06:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =======================================================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  17/09/2012      
-- Descrição:	  Lista os posts quando houver mais de 1 Posts relativo a opção selecionada 

-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =======================================================================================================
ALTER PROCEDURE [dbo].[STP_Lista_Posts_Relativos ]
	(
		@P_IdNode VARCHAR(10)
	)
AS
BEGIN
	
	
	SELECT P.Titulo, P.Conteudo, P.Data, P.IdPost, PA.KIdNode
	FROM   Posts P
	INNER JOIN PostArvore PA
	ON  PA.KIdNode = CONVERT(INTEGER, @P_IdNode)
	JOIN Arvore A
	ON A.IdNode = PA.KIdNode AND P.IdPost = PA.KIdPost
	
	SET NOCOUNT ON;
END







GO


