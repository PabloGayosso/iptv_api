CREATE TABLE [dbo].[TV_D_ENVIO] (
    [ID_ENVIO]   INT             IDENTITY (1, 1) NOT NULL,
    [NOMBRE_CONTENIDO] NCHAR(50)             NULL,
    [REPRODUCTOR]     VARCHAR(50)             NULL,
    [USUARIO]       VARCHAR(150)             NULL,
    [FEC_ENVIO]  DATETIME             NULL,
    [VELOCIDAD]           VARCHAR (50)   NULL,
    [TAM_TOTAL]         VARCHAR(150)      NULL,
    [TAM_DESCARGADO]         VARCHAR(150)      NULL,
    [PORCENTAJE]   INT      NULL,
    [FEC_ALTA]  DATETIME             NULL,
    [FEC_ACTUALIZACION]  DATETIME             NULL
);

