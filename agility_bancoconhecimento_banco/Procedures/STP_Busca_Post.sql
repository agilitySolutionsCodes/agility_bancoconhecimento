USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Busca_Post]    Script Date: 04/15/2013 11:53:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  10/09/2012      
-- Descri��o:  Busca Post Recebe como parametro o ID do Post   
-- N�MERO DATA        USU�RIO   DESCRI��O      
-- #001#  
-- =========================================================================  

ALTER PROCEDURE [dbo].[STP_Busca_Post]   
(
	@P_IdPost VARCHAR(10)
)
AS

BEGIN 
SET NOCOUNT ON   
	
	SELECT P.IdPost, P.Titulo, P.Conteudo AS Conteudo, U.Nome, P.Data, P.Anexo
	FROM Posts P  
	JOIN Usuarios U                                           
	ON P.IdPost = @P_IdPost AND U.IdUsuario = P.IdUsuario

END







GO


