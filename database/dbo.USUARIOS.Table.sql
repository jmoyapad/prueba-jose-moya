USE [prueba_josemoya]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 9/6/2022 11:23:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[apellidos] [varchar](200) NOT NULL,
	[correo_electronico] [varchar](150) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[telefono] [varchar](10) NULL,
	[id_pais] [char](3) NOT NULL,
	[recibe_informacion] [bit] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[USUARIOS] ADD  CONSTRAINT [DF_USUARIOS_activo]  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[USUARIOS]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOS_PAISES] FOREIGN KEY([id_pais])
REFERENCES [dbo].[PAISES] ([id_pais])
GO
ALTER TABLE [dbo].[USUARIOS] CHECK CONSTRAINT [FK_USUARIOS_PAISES]
GO
