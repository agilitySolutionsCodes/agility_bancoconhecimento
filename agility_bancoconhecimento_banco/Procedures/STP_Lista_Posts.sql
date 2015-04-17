USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Posts]    Script Date: 04/15/2013 11:54:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  10/09/2012      
-- Descrição:  Autenticar Login do Usuário   
-- NÚMERO DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================  

ALTER PROCEDURE [dbo].[STP_Lista_Posts]   
(
	@P_IdNodeGalho VARCHAR(10)
)
AS

BEGIN 
SET NOCOUNT ON   
	
	SELECT P.IdPost, P.Titulo, P.Conteudo AS Conteudo, U.Nome, P.Data
	FROM Posts P
	JOIN Arvore PArvore ON P.IdContexto = PArvore.IdNode  
	JOIN Usuarios U
	ON P.IdUsuario = U.IdUsuario                                              
	WHERE PArvore.IdNode = @P_IdNodeGalho	
	
END











GO


