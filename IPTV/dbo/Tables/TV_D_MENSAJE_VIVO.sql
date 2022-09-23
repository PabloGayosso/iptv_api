CREATE TABLE [dbo].[TV_D_MENSAJE_VIVO] (
    [ID_MENSAJE]              INT             IDENTITY (1, 1) NOT NULL,
    [ID_ESTATUS]              INT             NULL,
    [DSC_MENSAJE]             TEXT            NULL,
    [ES_REPETITIVO]           BIT             NULL,
    [TIEMPO_REPETICION]       TIME (7)        NULL,
    [FECHA_ALTA]              DATETIME        NULL,
    [FECHA_MOD]               DATETIME        NULL,
    [USUARIO]                 NVARCHAR (100)  NULL,
    [COLOR_FONDO_BARRA_TEXTO] VARCHAR (50)    NULL,
    [OPACIDAD_TEXTO]          DECIMAL (15, 2) NULL,
    [OPACIDAD_BARRA_TEXTO]    DECIMAL (15, 2) NULL,
    [TIPO_LETRA_TEXTO]        NVARCHAR (100)  NULL,
    [TAMANIO_LETRA_TEXTO]     INT             NULL,
    [COLOR_TEXTO]             VARCHAR (50)    NULL,
    [VELOCIDAD_TEXTO]         DECIMAL (15, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID_MENSAJE] ASC)
);

