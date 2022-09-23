CREATE TABLE [dbo].[TV_D_ENVIO_HISTORICO] (
    [ID_ENVIO]   INT             IDENTITY (1, 1) NOT NULL,
    [NOMBRE_CONTENIDO] NCHAR(50)             NULL,
    [REPRODUCTOR]     VARCHAR(50)             NULL,
    [USUARIO]       VARCHAR(150)             NULL,
    [FEC_ENVIO]  DATETIME             NULL,
    [FEC_ALTA]  DATETIME             NULL,
    [ESTATUS] NVARCHAR(200)             NULL
);

