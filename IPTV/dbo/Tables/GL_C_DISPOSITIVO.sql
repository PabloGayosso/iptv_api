﻿CREATE TABLE [dbo].[GL_C_DISPOSITIVO] (
    [ID_DISPOSITIVO]      INT          IDENTITY (1, 1) NOT NULL,
    [NOMBRE]              VARCHAR (50) NULL,
    [CLAVE]               VARCHAR (50) NULL,
    [IP]                  VARCHAR (50) NULL,
    [MAC_ADDRESS]         VARCHAR (50) NULL,
    [DESCRIPCION]         VARCHAR (50) NULL,
    [ID_TIPO_DISPOSITIVO] INT          NULL,
    [PUERTO]              INT          NULL,
    [VISITA]              BIT          NULL,
    [ID_ESTATUS]          INT          NULL,
    [FEC_ALTA]            DATETIME     NULL,
    [FEC_MOD]             DATETIME     NULL,
    [USUARIO]             VARCHAR (30) NULL,
    CONSTRAINT [PK_DISPOSITIVO] PRIMARY KEY CLUSTERED ([ID_DISPOSITIVO] ASC),
    CONSTRAINT [FK_DISPOSITIVO_PARAMETRO] FOREIGN KEY ([ID_TIPO_DISPOSITIVO]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO]),
    CONSTRAINT [FK_DISPOSITIVO_PARAMETRO1] FOREIGN KEY ([ID_ESTATUS]) REFERENCES [dbo].[GL_C_PARAMETRO] ([ID_PARAMETRO])
);

