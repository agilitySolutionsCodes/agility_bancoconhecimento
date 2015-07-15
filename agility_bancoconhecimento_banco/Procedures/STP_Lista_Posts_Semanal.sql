USE [bc6]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Posts_Semanal]    Script Date: 06/30/2015 16:06:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =======================================================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  10/06/2015      
-- Descrição:  Lista Post Da Semana
-- Número    Data      Usuário     Descrição
-- #001#  25/06/2015  Yule Souza  Lista Posts da Semana
-- =======================================================================================================  
    
ALTER PROCEDURE [dbo].[STP_Lista_Posts_Semanal]      
AS      
BEGIN      
SET NOCOUNT ON    

	SELECT U.Nome, COUNT(U.Nome)AS NumeroPosts
	FROM Posts P 
	JOIN Usuarios U 
	ON P.IdUsuario = U.IdUsuario
	WHERE P.Data BETWEEN GETDATE() - 6 AND GETDATE()
	GROUP BY 
	U.Nome 
	
END      
SET NOCOUNT OFF 



GO


