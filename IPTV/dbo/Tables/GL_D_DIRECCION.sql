﻿CREATE TABLE [dbo].[GL_D_DIRECCION] (
    [ID_DIRECCION]       INT           IDENTITY (1, 1) NOT NULL,
    [ID_TIPO_DIRECCION]  INT           NOT NULL,
    [ID_PAIS]            INT           NOT NULL,
    [ID_ESTADO]          INT           NOT NULL,
    [ID_DELEG_MUNICIPIO] INT           NOT NULL,
    [ID_COLONIA]         INT           NOT NULL,
    [CODIGO_POSTAL]      VARCHAR (10)  NOT NULL,
    [CIUDAD]             VARCHAR (250) NOT NULL,
    [CALLE]              VARCHAR (250) NOT NULL,
    [NUMERO_EXTERIOR]    VARCHAR (50)  NULL,
    [NUMERO_INTERIOR]    VARCHAR (50)  NULL,
    [ID_ESTATUS]         INT           NOT NULL,
    [FEC_ALTA]           DATETIME      NOT NULL,
    [FEC_MOD]            DATETIME      NULL,
    [USUARIO]            VARCHAR (30)  NOT NULL,
    CONSTRAINT [PK_DIRECCION] PRIMARY KEY CLUSTERED ([ID_DIRECCION] ASC),
    CONSTRAINT [FK_DIRECCION_PARAMETRO] FOREIGN KEY ([ID_ESTATUS]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO]),
    CONSTRAINT [FK_GL_DIRECCION_GL_ESTADO1] FOREIGN KEY ([ID_ESTADO]) REFERENCES [dbo].[GL_C_ESTADO] ([ID_ESTADO]),
    CONSTRAINT [FK_GL_DIRECCION_GL_PAIS] FOREIGN KEY ([ID_PAIS]) REFERENCES [dbo].[GL_C_PAIS] ([ID_PAIS]),
    CONSTRAINT [FK_GL_DIRECCION_GL_PARAMETRO] FOREIGN KEY ([ID_TIPO_DIRECCION]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO])
);

