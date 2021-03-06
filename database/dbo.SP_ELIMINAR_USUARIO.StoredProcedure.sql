USE [prueba_josemoya]
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_USUARIO]    Script Date: 10/6/2022 07:30:34 ******/
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
-- SELECT * FROM [dbo].[USUARIOS]   SELECT * FROM [dbo].[ACTIVIDADES]
    
CREATE PROCEDURE [dbo].[SP_ELIMINAR_USUARIO] 
	@id_usuario INT
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION  SP_ELIMINAR_USUARIO
    -- Insert statements for procedure here

	DECLARE @actividad VARCHAR(200)= (SELECT CONCAT('El usuario ',[nombre],' ',[apellidos],' fue dado de baja el dia ',FORMAT (getdate(), 'dd/MM/yyyy'))
	FROM [dbo].[USUARIOS] 
	WHERE [id_usuario] = @id_usuario)



	UPDATE [dbo].[USUARIOS]
	   SET [activo] = 0
	 WHERE [id_usuario] = @id_usuario



	EXEC SP_REGISTRO_ACTIVIDADES @id_usuario, @actividad

	
	SELECT 1000 [Code],'Proceso realizado correctamente...' [Msg],0 Result,HasError = 1   

   COMMIT TRANSACTION SP_ELIMINAR_USUARIO

END TRY  
BEGIN CATCH  


	DECLARE @xstate INT = XACT_STATE();
	IF @xstate = -1
	ROLLBACK
	IF @xstate = 1 and @@TRANCOUNT = 0
	ROLLBACK
	IF @xstate = 1 and @@TRANCOUNT > 0
	
	ROLLBACK TRANSACTION SP_ELIMINAR_USUARIO ;
    SELECT 2000 [Code],ERROR_MESSAGE() [Msg],0 Result,HasError = 1   
END CATCH

GO
