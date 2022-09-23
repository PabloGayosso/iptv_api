CREATE TABLE [dbo].[TV_D_GRUPOS] (
    [ID_GRUPO]               INT        IDENTITY (1, 1) NOT NULL,
    [NOMBRE]                 NCHAR (30) NOT NULL,
    [DESCRIPCION]            TEXT       NULL,
    [CANTIDAD_REPRODUCTORES] INT        NULL,
    [ID_ESTATUS]             INT        NULL,
    [ID_TEMPLATE]            INT        NULL,
    [FECHA_ALTA]             DATETIME   NOT NULL,
    [FECHA_MOD]              DATETIME   NULL,
    [USUARIO]                NCHAR (30) NULL,
    CONSTRAINT [PK_TV_D_GRUPOS] PRIMARY KEY CLUSTERED ([ID_GRUPO] ASC)
);

