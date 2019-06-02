-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpNovoMatch_ProcurarUsuarioPrimario]  
    @usuarioPrimario varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.UsuarioPrimario,
		u.UsuarioSecundario		
	FROM PlaySports.dbo.NovoMatch u WHERE u.UsuarioPrimario = @usuarioPrimario;
END;
GO


-- 3.6 SELECT BY Nome
CREATE PROCEDURE [dbo].[SpNovoMatch_ProcurarUsuarioSecundario]  
    @usuarioSecundario varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
		u.UsuarioPrimario,
		u.UsuarioSecundario		
	FROM PlaySports.dbo.NovoMatch u WHERE u.UsuarioSecundario = @usuarioSecundario;
END;
GO