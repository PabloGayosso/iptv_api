﻿CREATE TABLE [dbo].[TV_D_REPOSITORIO] (
    [ID_REPOSITORIO]    INT           IDENTITY (1, 1) NOT NULL,
    [ID_TIPO_CONTENIDO] INT           NULL,
    [DESCRIPCION]       VARCHAR (50)  NOT NULL,
    [RUTA_ALOJAMIENTO]  VARCHAR (150) NOT NULL,
    [EXTENSION]         VARCHAR (10)  NOT NULL,
    [DURACION]          TIME NOT NULL DEFAULT '00:00:00',
    [ID_ESTATUS]        INT           NULL,
    [FEC_ALTA]          DATETIME      NOT NULL,
    [FEC_MOD]           DATETIME      NULL,
    [USUARIO]           VARCHAR (30)  NULL,
    CONSTRAINT [PK_TV_D_REPOSITORIO] PRIMARY KEY CLUSTERED ([ID_REPOSITORIO] ASC),
    CONSTRAINT [FK_TV_D_REPOSITORIO_GL_C_PARAMETRO_ESTATUS] FOREIGN KEY ([ID_ESTATUS]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO]),
    CONSTRAINT [FK_TV_D_REPOSITORIO_GL_C_PARAMETRO_TIPO_CONTENIDO] FOREIGN KEY ([ID_TIPO_CONTENIDO]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO])
);

