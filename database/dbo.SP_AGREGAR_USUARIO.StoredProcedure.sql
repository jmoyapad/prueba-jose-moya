USE [prueba_josemoya]
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_USUARIO]    Script Date: 10/6/2022 07:30:34 ******/
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
-- SELECT * FROM [dbo].[USUARIOS]
    
CREATE PROCEDURE [dbo].[SP_AGREGAR_USUARIO] 
	@nombre varchar(200),
    @apellidos varchar(200),
    @correo_electronico varchar(150),
    @fecha_nacimiento datetime,
    @telefono varchar(10),
    @id_pais char(3),
    @recibe_informacion bit
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION  SP_AGREGAR_USUARIO
    -- Insert statements for procedure here
	DECLARE @userid  INT,
	        @actividad VARCHAR(200)= 'El usuario '+@nombre+' '+@apellidos+', se creó en la fecha '+FORMAT (getdate(), 'dd/MM/yyyy ')

	INSERT INTO [dbo].[USUARIOS]
           ([nombre]
           ,[apellidos]
           ,[correo_electronico]
           ,[fecha_nacimiento]
           ,[telefono]
           ,[id_pais]
           ,[recibe_informacion])
     VALUES
           (@nombre
           ,@apellidos
           ,@correo_electronico
           ,@fecha_nacimiento
           ,@telefono
           ,@id_pais
           ,@recibe_informacion)

	SET @userid = @@IDENTITY


	EXEC SP_REGISTRO_ACTIVIDADES @userid, @actividad

	
	SELECT 1000 [Code],'Usuario creado correctamente' [Msg],0 Result,HasError = 0   

   COMMIT TRANSACTION SP_AGREGAR_USUARIO

END TRY  
BEGIN CATCH  


	DECLARE @xstate INT = XACT_STATE();
	IF @xstate = -1
	ROLLBACK
	IF @xstate = 1 and @@TRANCOUNT = 0
	ROLLBACK
	IF @xstate = 1 and @@TRANCOUNT > 0
	
	ROLLBACK TRANSACTION SP_AGREGAR_USUARIO ;
    SELECT 2000 [Code],ERROR_MESSAGE() [Msg],0 Result,HasError = 1   
END CATCH
GO
