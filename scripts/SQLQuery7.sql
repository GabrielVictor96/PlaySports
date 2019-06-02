-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpNovoMatch_ProcurarUsuarioPrimario]  
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


-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpNovoMatch_ProcurarUsuarioSecundario]  
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