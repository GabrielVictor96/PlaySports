-- 3. STORED PROCEDURES
-- 3.1 ADD
CREATE PROCEDURE [dbo].[SpAgenda_AddAgenda] 
    @id uniqueidentifier,
	@criador varchar(100),
	@membro1 varchar(100),
	@membro2 varchar(100),
	@membro3 varchar(100),
	@membro4 varchar(100),
	@membro5 varchar(100),
	@membro6 varchar(100),
	@membro7 varchar(100),
	@membro8 varchar(100),
	@membro9 varchar(100),
	@atividade varchar(100),
	@local varchar(100),
	@data datetime
AS
BEGIN
	INSERT INTO PlaySports.dbo.Agenda 
	VALUES(@id, @criador, @membro1, @membro2, @membro3, @membro4, @membro5, @membro6, @membro7, @membro8, @membro9, @atividade, @local, @data);
END;
GO

