CREATE PROCEDURE [dbo].[SpAgenda_Detalhes]  
    @id uniqueidentifier = NULL
AS
BEGIN
	SELECT 
		u.Criador,
		u.Membro1,
		u.Membro2,
		u.Membro3,
		u.Membro4,
		u.Membro5,
		u.Membro6,
		u.Membro7,
		u.Membro8,
		u.Membro9,
		u.Atividade,
		u.Local,
		u.Data		
	FROM PlaySports.dbo.Agenda u WHERE u.Id = @id;
END;
GO





