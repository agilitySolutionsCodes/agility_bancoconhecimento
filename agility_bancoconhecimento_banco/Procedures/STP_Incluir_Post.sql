USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Post]    Script Date: 04/15/2013 11:54:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  30/08/2012      
-- Descrição:	  Incluir Post   

-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_Post]      

(     
	 @P_IdPost INTEGER = NULL,
	 @P_Titulo VARCHAR(100),
	 @P_Conteudo VARCHAR(8000),
	 @P_Anexo VARCHAR (100) = NULL,
	 @P_Data Date,
	 @P_Hora CHAR(5),
	 @P_IdUsuario INT, 
	 @P_IdContexto INT  
)

AS      
BEGIN      
SET NOCOUNT ON
		If(SELECT COUNT(*) FROM Posts (NOLOCK) WHERE IdPost = @P_IdPost) = 0 BEGIN
			INSERT INTO Posts (Titulo, Conteudo, Anexo, Data, Hora, IdUsuario, IdContexto) 
			VALUES(@P_Titulo, @P_Conteudo, @P_Anexo, @P_Data, @P_Hora, @P_IdUsuario, @P_IdContexto)		
		END	
END      


GO


