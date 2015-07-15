USE [bc6]
GO

/****** Object:  StoredProcedure [dbo].[STP_Autenticar_Administrador_Logado]    Script Date: 06/30/2015 15:59:21 ******/
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
    
CREATE PROCEDURE [dbo].[STP_Autenticar_Administrador_Logado]      
(   
  
 @P_Email VARCHAR(50),
 @Ok BIT OUTPUT,
 @CodUsuario INTEGER OUTPUT,
 @NomeUsuario VARCHAR(80) OUTPUT,
 @ImagemUsuario VARCHAR(100) OUTPUT
 
)      

AS      
BEGIN      
SET NOCOUNT ON    

	DECLARE @Administrador BIT

	SET @CodUsuario = 0
	SET @NomeUsuario = ''
	
	IF(SELECT COUNT(*) FROM Usuarios (NOLOCK) WHERE Email = @P_Email) > 0 BEGIN
		SELECT @Administrador = Administrador, 
			   @CodUsuario = IdUsuario, 
			   @NomeUsuario = Nome, 
			   @ImagemUsuario = Imagem 
			   FROM Usuarios (NOLOCK) WHERE Email = @P_Email
			   
		IF @Administrador = 1 BEGIN
			SET @Ok = 'TRUE'
		END
		ELSE BEGIN
			SET @Ok = 'FALSE'
		END
	END
	ELSE
	BEGIN
		SET @Ok = 'FALSE'
	END
END      
SET NOCOUNT OFF 




GO


