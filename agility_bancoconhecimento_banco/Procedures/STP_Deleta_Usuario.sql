USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Usuario]    Script Date: 04/15/2013 11:53:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  30/08/2012      
-- Descri��o:	  Deletar Usu�rio a partir do c�digo do mesmo

-- N�MERO		DATA        USU�RIO   DESCRI��O      
-- #001#  
-- =========================================================================    

ALTER PROCEDURE [dbo].[STP_Deleta_Usuario]    
(     
 @P_IdUsuario INT
)       
AS      
BEGIN      
SET NOCOUNT ON   

	DELETE FROM Usuarios WHERE @P_IdUsuario = IdUsuario
END      
SET NOCOUNT OFF 



GO


