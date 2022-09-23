﻿CREATE TABLE [dbo].[GL_C_COLONIA] (
    [ID_COLONIA]           INT           NOT NULL,
    [ID_DELEG_MUNICIPIO]   INT           NOT NULL,
    [ID_ESTADO]            INT           NOT NULL,
    [ID_TIPO_ASENTAMIENTO] INT           NOT NULL,
    [CODIGO_POSTAL]        VARCHAR (10)  NOT NULL,
    [DESC_COLONIA]         VARCHAR (150) NOT NULL,
    [DESC_CIUDAD]          VARCHAR (150) NULL,
    [FEC_ALTA]             DATETIME      NOT NULL,
    [FEC_MOD]              DATETIME      NULL,
    [USUARIO]              VARCHAR (30)  NULL,
    CONSTRAINT [PK_GL_COLONIA] PRIMARY KEY CLUSTERED ([ID_COLONIA] ASC, [ID_ESTADO] ASC, [ID_DELEG_MUNICIPIO] ASC),
    CONSTRAINT [FK_GL_C_COLONIA_GL_C_TIPO_ASENTAMIENTO] FOREIGN KEY ([ID_TIPO_ASENTAMIENTO]) REFERENCES [dbo].[GL_C_TIPO_ASENTAMIENTO] ([ID_TIPO_ASENTAMIENTO]),
    CONSTRAINT [FK_GL_COLONIA_GL_DELEG_MUNICIPIO] FOREIGN KEY ([ID_DELEG_MUNICIPIO], [ID_ESTADO]) REFERENCES [dbo].[GL_C_DELEG_MUNICIPIO] ([ID_DELEG_MUNICIPIO], [ID_ESTADO]),
    CONSTRAINT [FK_GL_COLONIA_GL_ESTADO1] FOREIGN KEY ([ID_ESTADO]) REFERENCES [dbo].[GL_C_ESTADO] ([ID_ESTADO])
);

