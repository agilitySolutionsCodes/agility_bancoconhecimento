USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Usuario_ById]    Script Date: 04/15/2013 11:55:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================================================       
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  05/09/2012     
-- Descri��o:  Lista Usuarios Cadastrados Recebe como param�tro o Id do usu�rio
-- N�mero	   Data		    Usu�rio      Descri��o
-- #001#	   05/09/2012   Yule Souza	 Primeira Vers�o
-- =============================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Usuario_ById]

(     
 @P_IdUsuario INTEGER
)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT  
    Nome,
    Email,
    Telefone,
    Ramal,
    Celular,
    NomeSkype,
    Foto,
    Senha,
    Imagem,
    Departamento
    FROM Usuarios 
    
    WHERE IdUsuario = @P_IdUsuario
	
END





GO


