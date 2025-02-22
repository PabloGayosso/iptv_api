﻿CREATE TABLE [dbo].[GL_R_DIRECCION_ENTIDAD] (
    [ID_ENTIDAD]      INT          NOT NULL,
    [ID_DIRECCION]    INT          NOT NULL,
    [ID_TIPO_ENTIDAD] INT          NOT NULL,
    [ID_ESTATUS]      INT          CONSTRAINT [DF_DIRECCION_ENTIDAD_ID_ESTATUS] DEFAULT ((1)) NOT NULL,
    [FEC_ALTA]        DATETIME     NOT NULL,
    [FEC_MOD]         DATETIME     NULL,
    [USUARIO]         VARCHAR (30) NULL,
    CONSTRAINT [PK_DIRECCION_ENTIDAD] PRIMARY KEY CLUSTERED ([ID_ENTIDAD] ASC, [ID_DIRECCION] ASC, [ID_TIPO_ENTIDAD] ASC),
    CONSTRAINT [FK_DIRECCION_ENTIDAD_DIRECCION] FOREIGN KEY ([ID_DIRECCION]) REFERENCES [dbo].[GL_D_DIRECCION] ([ID_DIRECCION]),
    CONSTRAINT [FK_DIRECCION_ENTIDAD_PARAMETRO] FOREIGN KEY ([ID_ESTATUS]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO]),
    CONSTRAINT [FK_DIRECCION_ENTIDAD_PARAMETRO1] FOREIGN KEY ([ID_TIPO_ENTIDAD]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO])
);

