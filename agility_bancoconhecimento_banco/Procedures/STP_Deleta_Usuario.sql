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
-- Descrição:	  Deletar Usuário a partir do código do mesmo

-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
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


