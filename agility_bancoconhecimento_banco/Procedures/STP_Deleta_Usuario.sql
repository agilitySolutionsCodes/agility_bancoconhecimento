USE [bc6]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Usuario]    Script Date: 06/30/2015 16:00:36 ******/
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

CREATE PROCEDURE [dbo].[STP_Deleta_Usuario]    
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


