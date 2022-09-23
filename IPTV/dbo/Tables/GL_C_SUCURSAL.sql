﻿CREATE TABLE [dbo].[GL_C_SUCURSAL] (
    [ID_SUCURSAL] INT           IDENTITY (1, 1) NOT NULL,
    [ID_ENTIDAD]  INT           NOT NULL,
    [CLAVE]       VARCHAR (50)  NULL,
    [NOMBRE]      VARCHAR (250) NOT NULL,
    [ID_ESTATUS]  INT           NULL,
    [FEC_ALTA]    DATETIME      CONSTRAINT [DF_SUCURSAL_FECHA_ALTA] DEFAULT (getdate()) NOT NULL,
    [FEC_MOD]     DATETIME      NULL,
    [USUARIO]     VARCHAR (30)  NOT NULL,
    CONSTRAINT [PK_SUCURSAL] PRIMARY KEY CLUSTERED ([ID_SUCURSAL] ASC),
    CONSTRAINT [FK_SUCURSAL_EMPRESA] FOREIGN KEY ([ID_ENTIDAD]) REFERENCES [dbo].[GL_D_ENTIDAD] ([ID_ENTIDAD]) ON UPDATE CASCADE
);

