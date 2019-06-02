CREATE PROCEDURE [dbo].[SpAgenda_Procurar]  
    @criador varchar(100) = NULL
AS
BEGIN
	SELECT 
		u.Id,
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
	FROM PlaySports.dbo.Agenda u WHERE u.Criador = @criador or u.Membro1 = @criador or u.Membro2 = @criador or u.Membro3 = @criador or Membro4 = @criador or Membro5 = @criador or Membro6 = @criador or Membro7 = @criador or Membro8 = @criador or Membro9 = @criador;
END;
GO





