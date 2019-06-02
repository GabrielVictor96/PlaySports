-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpMatch_ProcurarMatch]  
    @usuarioCurtiu varchar(100) = NULL,
	@usuarioCurtido varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.UsuarioCurtiu,
		u.UsuarioCurtido		
	FROM PlaySports.dbo.Match u WHERE u.UsuarioCurtiu = @usuarioCurtiu and u.UsuarioCurtido = @usuarioCurtido;
END;
GO