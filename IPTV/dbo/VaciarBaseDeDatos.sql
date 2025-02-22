﻿USE IPTV
GO
TRUNCATE TABLE GL_R_DIRECCION_ENTIDAD
GO
TRUNCATE TABLE GL_R_PERFIL_OPCION
GO
TRUNCATE TABLE GL_R_PERSONA_DIRECCION
GO
TRUNCATE TABLE GL_R_SUCURSAL_APLICACION_IST
GO
TRUNCATE TABLE GL_R_USUARIO_APLICACION_IS
GO
TRUNCATE TABLE GL_D_AUDITORIA
GO
TRUNCATE TABLE GL_C_DISPOSITIVO
GO

TRUNCATE TABLE GL_D_LICENCIAMIENTO
GO
TRUNCATE TABLE GL_D_LICENCIA_ACTIVA
GO
TRUNCATE TABLE TV_C_REPOSITORIO
GO
DELETE FROM GL_C_APLICACION_IST
DBCC CHECKIDENT (GL_C_APLICACION_IST, RESEED, 0)
GO

DELETE FROM GL_C_USUARIO
DBCC CHECKIDENT (GL_C_USUARIO, RESEED, 0)
GO
DELETE FROM GL_C_PERFIL
DBCC CHECKIDENT (GL_C_PERFIL, RESEED, 0)
GO
TRUNCATE TABLE GL_R_CARACTERISTICA_SUCURSAL
GO
DELETE FROM GL_C_OPCION
DBCC CHECKIDENT (GL_C_OPCION, RESEED, 0)
GO
DELETE FROM GL_C_SUCURSAL
DBCC CHECKIDENT (GL_C_SUCURSAL, RESEED, 0)
GO
DELETE FROM GL_D_ENTIDAD
DBCC CHECKIDENT (GL_D_ENTIDAD, RESEED, 0)
GO

DELETE FROM GL_D_DIRECCION
DBCC CHECKIDENT (GL_D_DIRECCION, RESEED, 0)
GO

DELETE FROM GL_D_ESTACION_TRABAJO
DBCC CHECKIDENT (GL_D_ESTACION_TRABAJO, RESEED, 0)
GO

DELETE FROM GL_D_PERSONA
DBCC CHECKIDENT (GL_D_PERSONA, RESEED, 0)
GO
TRUNCATE TABLE GL_D_PERSONA_SUCURSAL
GO
TRUNCATE TABLE GL_D_SESION
GO
TRUNCATE TABLE TV_R_CAD
GO
TRUNCATE TABLE TV_R_CANAL_CONTENIDO
GO
TRUNCATE TABLE TV_R_GRUPO_REPRODUCTOR
GO
TRUNCATE TABLE TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
GO
TRUNCATE TABLE TV_R_MONITOR
GO
TRUNCATE TABLE TV_R_TABLA_CAMPO
GO
TRUNCATE TABLE TV_R_TEMPLATE_CANAL
GO
TRUNCATE TABLE TV_R_TEMPLATE_REPRODUCTOR
GO
DELETE FROM TV_D_CONTENIDO
DBCC CHECKIDENT (TV_D_CONTENIDO, RESEED, 0)
GO
DELETE FROM TV_D_REPOSITORIO
DBCC CHECKIDENT (TV_D_CONTENIDO, RESEED, 0)
GO
DELETE FROM TV_C_MENSAJES
DBCC CHECKIDENT (TV_C_MENSAJES, RESEED, 0)
GO
DELETE FROM TV_C_REPRODUCTOR
DBCC CHECKIDENT (TV_C_REPRODUCTOR, RESEED, 0)
GO
DELETE FROM TV_D_CAMPO
DBCC CHECKIDENT (TV_D_CAMPO, RESEED, 0)
GO
DELETE FROM TV_D_CANAL
DBCC CHECKIDENT (TV_D_CANAL, RESEED, 0)
GO
DELETE FROM TV_D_GRUPOS
DBCC CHECKIDENT (TV_D_GRUPOS, RESEED, 0)
GO
TRUNCATE TABLE TV_D_LOG_EXCEPCIONES_CAD
GO
TRUNCATE TABLE TV_D_MENSAJE_VIVO
GO
TRUNCATE TABLE TV_D_RECOLECTOR_DATOS
GO
DELETE FROM TV_D_TABLA
DBCC CHECKIDENT (TV_D_TABLA, RESEED, 0)
GO
DELETE FROM TV_D_TEMPLATES
DBCC CHECKIDENT (TV_D_TEMPLATES, RESEED, 0)
GO
SET IDENTITY_INSERT GL_C_APLICACION_IST ON 
GO
INSERT GL_C_APLICACION_IST ([ID_APLICACION_IST], [CLAVE], [NOMBRE], [FEC_ALTA], [FEC_MOD], [USUARIO], [ID_ESTATUS]) VALUES (1, N'IM', N'BACKOFFICE', CAST(N'2017-03-01T00:00:00.000' AS DateTime), CAST(N'2017-08-15T12:42:17.110' AS DateTime), N'ESPINOZA', 3)
GO
SET IDENTITY_INSERT GL_C_APLICACION_IST OFF
DBCC CHECKIDENT (GL_C_APLICACION_IST, RESEED, 1)
GO

SET IDENTITY_INSERT [dbo].[GL_D_ENTIDAD] ON 
GO
INSERT [dbo].[GL_D_ENTIDAD] ([ID_ENTIDAD], [CLAVE_IS], [RAZON_SOCIAL], [RFC], [ES_GRUPO], [ID_ESTATUS], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, N'IS', N'INTERACTIVE SOLUTIONS', N'INTERACTIVE SOLUTIONS', 1, 3, CAST(N'2016-10-11T00:00:00.000' AS DateTime), CAST(N'2016-10-11T00:00:00.000' AS DateTime), N'ADMIN')
GO
SET IDENTITY_INSERT [dbo].[GL_D_ENTIDAD] OFF
DBCC CHECKIDENT ([GL_D_ENTIDAD], RESEED, 1)
GO

SET IDENTITY_INSERT [dbo].[GL_C_SUCURSAL] ON 
GO
INSERT [dbo].[GL_C_SUCURSAL] ([ID_SUCURSAL], [ID_ENTIDAD], [CLAVE], [NOMBRE], [ID_ESTATUS], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 1, N'IS', N'INTERACTIVE SOLUTIONS', 3, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2017-08-14T12:49:34.173' AS DateTime), N'ESPINOZA')
GO
SET IDENTITY_INSERT [dbo].[GL_C_SUCURSAL] OFF
DBCC CHECKIDENT ([GL_C_SUCURSAL], RESEED, 1)
GO

SET IDENTITY_INSERT [dbo].[GL_D_PERSONA] ON 
GO
INSERT [dbo].[GL_D_PERSONA] ([ID_PERSONA], [CLAVE], [NOMBRE], [APELLIDO_PATERNO], [APELLIDO_MATERNO], [ID_ESTATUS], [ID_PAIS], [FECHA_NACIMIENTO], [ID_GENERO], [ID_ESTADO_CIVIL], [ID_ESCOLARIDAD], [OCUPACION], [RELIGION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, N'ADMIN', N'ADMINISTRADOR', N'DEL', N'SISTEMA', 3, 117, CAST(N'1990-07-01T00:00:00.000' AS DateTime), 39, NULL, NULL, NULL, NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2017-06-13T15:07:16.680' AS DateTime), N'FANGELES')
GO
SET IDENTITY_INSERT [dbo].[GL_D_PERSONA] OFF
DBCC CHECKIDENT (GL_D_PERSONA, RESEED, 1)
GO
SET IDENTITY_INSERT [dbo].[GL_C_PERFIL] ON 
GO
INSERT [dbo].[GL_C_PERFIL] ([ID_PERFIL], [NOMBRE], [DESCRIPCION], [ID_ESTATUS], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, N'SA', N'ADMINISTRADOR DE TODO EL SISTEMA, CONTROL TOTAL', 3, CAST(N'2017-05-29T00:00:00.000' AS DateTime), CAST(N'2020-01-16T10:29:37.643' AS DateTime), N'FANGELES')
GO
SET IDENTITY_INSERT [dbo].[GL_C_PERFIL] OFF
DBCC CHECKIDENT (GL_C_PERFIL, RESEED, 1)
GO

SET IDENTITY_INSERT [dbo].[GL_C_USUARIO] ON 
GO
INSERT [dbo].[GL_C_USUARIO] ([ID_USUARIO], [ID_PERSONA], [ID_SUCURSAL], [CLAVE_USUARIO], [CONTRASENA], [ID_PERFIL], [ID_ESTATUS], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 1, 1, N'ADMIN', N'6JcfsasVYQU=', 1, 3, CAST(N'2018-09-25T17:07:19.700' AS DateTime), CAST(N'2018-10-01T10:26:33.593' AS DateTime), N'FANGELES')
GO
SET IDENTITY_INSERT [dbo].[GL_C_USUARIO] OFF
DBCC CHECKIDENT (GL_C_USUARIO, RESEED, 1)
GO
SET IDENTITY_INSERT [dbo].[GL_C_OPCION] ON 
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (1, 1, N'Administración', N'Administración', N'account_circle', NULL, 3, 0, 1, 1, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (2, 1, N'Configuracion', N'Configuración', N'miscellaneous_services', NULL, 3, 0, 1, 2, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (3, 1, N'Monitor', N'Monitor', N'~/Images/home.png', NULL, 3, 0, 1, 3, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (4, 1, N'Herramienta', N'Herramienta', N'~/Images/home.png', NULL, 4, 0, 1, 4, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (5, 1, N'Catálogo', N'Catálogo', N'~/Images/home.png', NULL, 4, 0, 1, 5, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (6, 1, N'Reporte', N'Reporte', N'bar_chart', NULL, 3, 0, 1, 3, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (7, 1, N'Licenciamiento', N'Licienciamiento', N'~/Images/home.png', NULL, 3, 0, 1, 7, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (8, 1, N'Perfil', N'Perfil', N'account_circle', N'/home/perfil', 3, 1, 2, 1, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (9, 1, N'Seguridad', N'Seguridad', N'security', N'/home/seguridad', 3, 1, 2, 2, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (10, 1, N'Usuario', N'Usuario', N'supervised_user_circle', N'/home/usuario', 3, 1, 2, 4, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (11, 1, N'Aaplicacion IST', N'Aaplicacion IST', N'~/Images/home-black.png', NULL, 4, 1, 2, 4, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (12, 1, N'Entidad', N'Entidad', N'~/Images/home-black.png', NULL, 4, 1, 2, 5, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (13, 1, N'Sucursal', N'Sucursal', N'~/Images/home-black.png', NULL, 4, 1, 2, 6, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (14, 1, N'Persona', N'Persona', N'~/Images/home-black.png', NULL, 4, 1, 2, 3, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (15, 1, N'Grupo', N'Grupo', N'~/Images/home-black.png', NULL, 4, 1, 2, 8, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (16, 1, N'Terminal', N'Terminal', N'~/Images/home-black.png', N'vfrmTerminal', 4, 1, 2, 9, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (17, 1, N'Server NIST', N'Server NIST', N'~/Images/home-black.png', NULL, 4, 1, 2, 10, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (18, 1, N'Multimedia', N'Multimedia', N'perm_media', N'/home/cargarMultimedia', 4, 2, 2, 1, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (19, 1, N'Canal Abierto', N'Canal Abierto', N'~/Images/home-black.png', NULL, 4, 2, 2, 8, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (20, 1, N'Canal Programado', N'Canal Programado', N'~/Images/home-black.png', NULL, 4, 2, 2, 9, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (21, 1, N'Tablero', N'Tablero', N'~/Images/home-black.png', NULL, 4, 3, 2, 1, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (22, 1, N'Reproductores', N'Reproductores', N'theaters', N'/home/reproductores', 3, 2, 2, 7, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (23, 1, N'Dispositivos', N'Dispositivos', N'devices', N'/home/monitor', 3, 3, 2, 3, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (24, 1, N'Plantilla', N'Plantilla', N'featured_video', N'/home/template', 3, 2, 2, 6, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (25, 1, N'Mensajes', N'Mensajes', N'chat', N'/home/generarMensajes', 4, 2, 2, 2, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (26, 1, N'Reporte Usuario', N'Reporte Usuario', N'print', N'/home/reporteUsuario', 3, 6, 2, 1, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (27, 1, N'Reporte Terminal', N'Reporte Terminal', N'~/Images/home-black.png', N'vfrmReporteTerminales', 4, 6, 2, 2, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (28, 1, N'Reporte Actividades', N'Reporte Actividades', N'print', N'/home/reporteActividades', 3, 6, 2, 2, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (29, 1, N'Reporte Visita', N'Reporte Visita', N'~/Images/home-black.png', NULL, 4, 6, 2, 4, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (30, 1, N'Reporte Usuario Pase Lista', N'Reporte Usuario Pase Lista', N'~/Images/home-black.png', NULL, 4, 6, 2, 5, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (31, 1, N'Catálogo', N'Catálogo', N'', N'/home/catalogo', 4, 1, 2, 11, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (32, 1, N'Generar Licencia', N'Generar Licencia', N'~/Images/home-black.png', N'vfrmLicenciamiento', 3, 7, 2, 1, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (33, 1, N'Canal', N'Canal', N'~/Images/home.png', N'vfmCanal', 4, 2, 2, 5, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (34, 1, N'Contenido', N'Contenido', N'video_settings', N'/home/contenido', 3, 2, 2, 4, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
--GO
--INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (35, 1, N'Tablas', N'Tabla Dinamica', N'', N'/home/tablaDinamica', 4, 2, 2, 3, NULL, CAST(N'2019-06-26 00:00:00.000' AS DateTime), N'FANGELES')
GO
INSERT [dbo].[GL_C_OPCION] ([ID_OPCION], [ID_SUCURSAL], [NOMBRE], [DESCRIPCION], [URL_ICON], [URL], [ID_ESTATUS], [OPCION_PADRE], [NIVEL], [ORDEN], [FEC_MOD], [FEC_ALTA], [USUARIO]) VALUES (36, 1, N'MensajeVivo', N'Mensaje vivo', N'sms', N'/home/mensajeVivo', 3, 2, 2, 4, NULL, CAST(N'2018-08-17 13:04:08.957' AS DateTime), N'FANGELES')
GO
SET IDENTITY_INSERT [dbo].[GL_C_OPCION] OFF
DBCC CHECKIDENT (GL_C_OPCION, RESEED, 36)
GO


INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 1, CAST(N'2020-01-15T17:40:08.673' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 2, CAST(N'2020-01-15T17:40:08.680' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 3, CAST(N'2020-01-15T17:40:08.683' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 4, CAST(N'2020-01-15T17:40:08.683' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 5, CAST(N'2020-01-15T17:40:08.683' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 6, CAST(N'2020-01-15T17:40:08.683' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 8, CAST(N'2020-01-15T17:40:08.687' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 9, CAST(N'2020-01-15T17:40:08.697' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 10, CAST(N'2020-01-15T17:40:08.697' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 11, CAST(N'2020-01-15T17:40:08.697' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 12, CAST(N'2020-01-15T17:40:08.700' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 13, CAST(N'2020-01-15T17:40:08.700' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 14, CAST(N'2020-01-15T17:40:08.703' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 15, CAST(N'2020-01-15T17:40:08.703' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 16, CAST(N'2020-01-15T17:40:08.713' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 17, CAST(N'2020-01-15T17:40:08.727' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 18, CAST(N'2020-01-15T17:40:08.727' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 19, CAST(N'2020-01-15T17:40:08.730' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 20, CAST(N'2020-01-15T17:40:08.730' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 21, CAST(N'2020-01-15T17:40:08.730' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 22, CAST(N'2020-01-15T17:40:08.730' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 23, CAST(N'2020-01-15T17:40:08.733' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 24, CAST(N'2020-01-15T17:40:08.733' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 25, CAST(N'2020-01-15T17:40:08.733' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 26, CAST(N'2020-01-15T17:40:08.737' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 27, CAST(N'2020-01-15T17:40:08.737' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 28, CAST(N'2020-01-15T17:40:08.737' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 29, CAST(N'2020-01-15T17:40:08.737' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 30, CAST(N'2020-01-15T17:40:08.750' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 31, CAST(N'2020-01-15T17:40:08.750' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 33, CAST(N'2020-01-15T17:40:08.760' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 34, CAST(N'2020-01-15T17:40:08.763' AS DateTime), NULL, N'FANGELES')
--GO
--INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 35, CAST(N'2020-01-15T17:40:08.763' AS DateTime), NULL, N'FANGELES')
GO
INSERT [dbo].[GL_R_PERFIL_OPCION] ([ID_PERFIL], [ID_OPCION], [FEC_ALTA], [FEC_MOD], [USUARIO]) VALUES (1, 36, CAST(N'2020-01-15T17:40:08.763' AS DateTime), NULL, N'FANGELES')
GO
