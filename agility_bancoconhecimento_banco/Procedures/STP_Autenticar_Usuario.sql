GO

/****** Object:  StoredProcedure [dbo].[STP_Autenticar_Usuario]    Script Date: 06/30/2015 15:59:37 ******/
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
    
CREATE PROCEDURE [dbo].[STP_Autenticar_Usuario]      
(   
 @P_Email VARCHAR(50),
 @P_Senha VARCHAR(30),
 @Ok BIT OUTPUT,
 @CodUsuario INTEGER OUTPUT,
 @NomeUsuario VARCHAR(80) OUTPUT,
 @ImagemUsuario VARCHAR(100) OUTPUT, 
 @Ativo BIT OUTPUT,
 @PerfilUsuario BIT OUTPUT,
 @UltimoPost DATETIME OUTPUT 
 
)      
AS      
BEGIN      
SET NOCOUNT ON    

	DECLARE @Senha VARCHAR(30)

	SET @CodUsuario = 0
	SET @NomeUsuario = ''
	SET @Ativo = 0
	
	IF(SELECT COUNT(*) FROM Usuarios WHERE Email = @P_Email) > 0 BEGIN
	    
		SELECT  
			   @Senha = U.Senha, 
			   @CodUsuario = U.IdUsuario, 
			   @NomeUsuario = U.Nome, 
			   @ImagemUsuario = U.Imagem, 
			   @Ativo = U.Ativo,
			   @PerfilUsuario = U.Administrador,
			   @UltimoPost = MAX(P.Data)			   
			   
		FROM Usuarios U (NOLOCK) 
		LEFT JOIN Posts P  
		ON U.IdUsuario = P.IdUsuario
		
		WHERE Email = @P_Email
		
		GROUP BY
		U.Senha,
		U.IdUsuario,
		U.Nome,
		U.Imagem,
		U.Ativo,
		U.Administrador	
		 				
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


