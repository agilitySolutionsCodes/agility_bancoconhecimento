USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Autenticar_Administrador]    Script Date: 04/15/2013 11:51:29 ******/
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
    
ALTER PROCEDURE [dbo].[STP_Autenticar_Administrador]      
(   
  
 @P_Email VARCHAR(50),
 @P_Senha VARCHAR(30),
 @Ok BIT OUTPUT,
 @CodUsuario INTEGER OUTPUT,
 @NomeUsuario VARCHAR(80) OUTPUT,
 @ImagemUsuario VARCHAR(100) OUTPUT
 
)      
AS      
BEGIN      
SET NOCOUNT ON    

	DECLARE @Senha VARCHAR(30)

	SET @CodUsuario = 0
	SET @NomeUsuario = ''
	
	IF(SELECT COUNT(*) FROM Usuarios (NOLOCK) WHERE Email = @P_Email) > 0 BEGIN
		SELECT @Senha = Senha, 
			   @CodUsuario = IdUsuario, 
			   @NomeUsuario = Nome, 
			   @ImagemUsuario = Imagem 
			   FROM Usuarios (NOLOCK) WHERE Email = @P_Email AND Administrador = 1
		IF @Senha = @P_Senha BEGIN
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


