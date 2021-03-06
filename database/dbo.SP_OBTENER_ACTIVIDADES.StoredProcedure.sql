USE [prueba_josemoya]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ACTIVIDADES]    Script Date: 10/6/2022 07:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,> 
-- =============================================
-- 
--  [dbo].[SP_OBTENER_ACTIVIDADES]  2
CREATE PROCEDURE [dbo].[SP_OBTENER_ACTIVIDADES] 
	@id_usuario INT
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT ACT.[id_actividad] AS IdActividad
      ,ACT.[create_date] AS CreateDate
      ,CONCAT(USR.nombre,' ',USR.apellidos) AS Nombre
      ,ACT.[actividad] AS Actividad
  FROM  [dbo].[ACTIVIDADES] AS ACT
  INNER JOIN [dbo].[USUARIOS] AS USR ON USR.id_usuario = ACT.id_usuario  
  WHERE USR.[id_usuario] = CASE WHEN @id_usuario = 0 THEN
                          USR.[id_usuario]
					ELSE
					   @id_usuario
					END 
					ORDER BY ACT.create_date ASC
	
END 

GO
