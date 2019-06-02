-- 3. STORED PROCEDURES
-- 3.1 ADD
CREATE PROCEDURE [dbo].[SpMatch_AddMatch] 
    @id uniqueidentifier,
	@usuarioCurtiu varchar(100),
	@usuarioCurtido varchar(100)
AS
BEGIN
	INSERT INTO PlaySports.dbo.Match 
	VALUES(@id, @usuarioCurtiu, @usuarioCurtido);
END;
GO