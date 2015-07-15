GO

/****** Object:  StoredProcedure [dbo].[STP_Busca]    Script Date: 06/30/2015 15:59:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  02/10/2012      
-- Descrição:  Busca Posts a partir da palavra chave digitada  
-- NÚMERO DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================  

CREATE PROCEDURE [dbo].[STP_Busca]   
(
	@P_PalavraChave VARCHAR(100)
)
AS

BEGIN 
SET NOCOUNT ON   
	
	SELECT U.Nome, QFT.IdPost, QFT.Titulo, QFT.Conteudo, QFT.Data, QFT.Anexo FROM
	(SELECT KEY_TBL.RANK, FT_TBL.IdPost, FT_TBL.Titulo, FT_TBL.Conteudo, FT_TBL.Data, FT_TBL.Anexo, FT_TBL.IdUsuario
	FROM Posts AS FT_TBL 
    INNER JOIN
    FREETEXTTABLE(Posts, *, @P_PalavraChave) AS KEY_TBL
    ON FT_TBL.IdPost = KEY_TBL.[KEY]) AS QFT
    INNER JOIN Usuarios U
    ON QFT.IdUsuario = U.IdUsuario

END





GO


