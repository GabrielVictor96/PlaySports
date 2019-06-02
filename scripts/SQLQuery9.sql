-- 3. STORED PROCEDURES
-- 3.1 ADD
CREATE PROCEDURE [dbo].[SpNovoMatch_AddNovoMatch] 
    @id uniqueidentifier,
	@usuarioPrimario varchar(100),
	@usuarioSecundario varchar(100)
AS
BEGIN
	INSERT INTO PlaySports.dbo.NovoMatch 
	VALUES(@id, @usuarioPrimario, @usuarioSecundario);
END;
GO