USE [AgilityKBase]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Usuarios]    Script Date: 04/15/2013 11:55:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================================================       
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  31/05/2012     
-- Descrição:  Lista Usuarios Cadastrados Recebe como paramêtro o Id do usuário
-- Número	   Data		    Usuário      Descrição
-- #001#	   28/06/2012	Yule Souza	 Primeira Versão
-- =============================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Usuarios]

AS
BEGIN

	SET NOCOUNT ON;

    SELECT  
    IdUsuario,
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
	
END






GO


