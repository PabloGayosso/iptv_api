CREATE TABLE [dbo].[TV_D_TEMPLATES] (
    [ID_TEMPLATE]       INT           IDENTITY (1, 1) NOT NULL,
    [ALTO]              INT           NULL,
    [ANCHO]             INT           NULL,
    [CANTIDAD_REGIONES] INT           NULL,
    [FEC_ALTA]          DATETIME2 (7) NULL,
    [FEC_MOD]           DATETIME2 (7) NULL,
    [NOMBRE]            VARCHAR (50)  NULL,
    [USUARIO]           VARCHAR (50)  NULL,
    [ID_ESTATUS]        INT           NULL,
    PRIMARY KEY CLUSTERED ([ID_TEMPLATE] ASC),
    CONSTRAINT [FK87pt8rxre5qikhueoogu59pb5] FOREIGN KEY ([ID_ESTATUS]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO])
);

