USE [prueba_josemoya]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USUARIO]    Script Date: 10/6/2022 07:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,> 
-- =============================================
-- SP_AGREGAR_USUARIO  'jose alfredo', 'moya padilla','test1@qe.com','1990-11-14','855277551','CR',1
-- SELECT * FROM [dbo].[USUARIOS]   SELECT * FROM [dbo].[ACTIVIDADES] SP_ELIMINAR_USUARIO 2 
    
CREATE PROCEDURE [dbo].[SP_OBTENER_USUARIO] 
	@id_usuario INT
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [id_usuario] AS IdUsuario
      ,[nombre] AS Nombre
      ,[apellidos] AS Apellidos
      ,[correo_electronico] AS CorreoElectronico
      ,[fecha_nacimiento] AS FechaNacimiento
      ,[telefono] AS Telefono
      ,[id_pais] AS IdPais
      ,[recibe_informacion] AS RecibeInformacion
      ,[activo] AS Activo
  FROM [dbo].[USUARIOS]
  WHERE [id_usuario] = CASE WHEN @id_usuario = 0 THEN
                          [id_usuario]
					ELSE
					   @id_usuario
					END AND [activo] = 1
	
END 

GO
