GO

/****** Object:  StoredProcedure [dbo].[STP_Aceita_TermosUso]    Script Date: 06/30/2015 15:58:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =======================================================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  10/09/2012      
-- Descri��o:  Atualiza Campo Ativo Tabela Usu�rios para setar que usu�rio aceitou os termos de uso   
-- N�MERO DATA        USU�RIO   DESCRI��O      
-- #001#  
-- =======================================================================================================  
    
ALTER PROCEDURE [dbo].[STP_Aceita_TermosUso]      
(   
 @P_IdUsuario INT,
 @P_Ativo BIT,
 @P_NovaSenha VARCHAR(30)
)      
AS      
BEGIN      
SET NOCOUNT ON    

	Update Usuarios 
	Set Ativo = @P_Ativo, 
	    Senha = @P_NovaSenha
	Where IdUsuario = @P_IdUsuario
	
END      
SET NOCOUNT OFF 


GO


