GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Usuario]    Script Date: 06/30/2015 16:05:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  30/08/2012      
-- Descrição:	  Incluir / Alterar usuario   

-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_Usuario]      

(     
 @P_IdUsuario INTEGER = NULL,
 @P_Nome VARCHAR(80),
 @P_Email VARCHAR(50),
 @P_Telefone VARCHAR(8),
 @P_Ramal CHAR(2),
 @P_Celular VARCHAR(9),
 @P_NomeSkype VARCHAR(20),
 @P_Foto VARCHAR(100),
 @P_Senha VARCHAR(30),
 @P_Imagem VARCHAR(100),
 @P_Departamento VARCHAR(70),
 @P_Ativo BIT,
 @P_Administrador BIT
)      

AS      
BEGIN      
SET NOCOUNT ON
		If(SELECT COUNT(*) FROM Usuarios (NOLOCK) WHERE IdUsuario = @P_IdUsuario) = 0 BEGIN
			INSERT INTO Usuarios (Nome, Email, Telefone, Ramal, Celular, NomeSkype, Foto, Senha, Imagem, Departamento, Ativo, Administrador) 
			VALUES(@P_Nome, @P_Email, @P_Telefone, @P_Ramal, @P_Celular, @P_NomeSkype, @P_Foto, @P_Senha, @P_Imagem, @P_Departamento, @P_Ativo, @P_Administrador)		
			
		END
	ELSE
	BEGIN
	
		UPDATE Usuarios 
		SET 
		Nome = @P_Nome, 
		Email = @P_Email, 
		Telefone = @P_Telefone,
		Ramal = @P_Ramal,
		Celular = @P_Celular,
		NomeSkype = @P_NomeSkype,
		Foto = @P_Foto,
		Senha = @P_Senha,
		Imagem = @P_Imagem,
		Departamento = @P_Departamento
		
		WHERE IdUsuario = @P_IdUsuario
	END		
END      
SET NOCOUNT OFF 










GO


