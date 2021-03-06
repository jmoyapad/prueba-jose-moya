USE [prueba_josemoya]
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRO_ACTIVIDADES]    Script Date: 10/6/2022 07:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_REGISTRO_ACTIVIDADES]
  @user_id  INT,
  @actividad VARCHAR(200)
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION  SP_REGISTRO_ACTIVIDADES
    -- Insert statements for procedure here

	INSERT INTO [dbo].[ACTIVIDADES]
           ([create_date]
           ,[id_usuario]
           ,[actividad])
     VALUES
           (GETDATE()
           ,@user_id
           ,@actividad)
   COMMIT TRANSACTION SP_REGISTRO_ACTIVIDADES
END
GO
