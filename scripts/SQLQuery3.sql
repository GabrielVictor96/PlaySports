-- 3.5 SELECT BY MATCH
CREATE PROCEDURE [dbo].[SpUser_GetByMatch]    
   @esporte varchar(20) = NULL,
   @localizacao varchar(60) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.Nome,
		u.Sexo,
		u.DataNascimento,
		u.Esporte,
		u.Nivel,
		u.Localizacao,		
		u.Login,
		u.Imagem		
	FROM PlaySports.dbo.Users u WHERE u.Esporte = @esporte and u.Localizacao = @localizacao;
END;
GO