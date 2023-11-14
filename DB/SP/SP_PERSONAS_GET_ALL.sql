USE [DoubleV]
GO
/****** Object:  StoredProcedure [dbo].[SP_PERSONAS_GET_ALL]    Script Date: 13/11/2023 9:35:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[SP_PERSONAS_GET_ALL]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
	p.id,
	CONCAT(p.nombres,' ',p.apellidos) nombres,
	CONCAT(ti.nombre_tipo,'-',p.identificacion) identificacion,
	p.email,
	us.[login]
	FROM Personas p
	INNER JOIN TiposIdentificacion ti ON p.id_tipo_identificacion = ti.id
	INNER JOIN Usuarios us ON p.id = us.id
	ORDER BY us.id

END
