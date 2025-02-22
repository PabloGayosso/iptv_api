﻿CREATE TABLE [dbo].[GL_D_AUDITORIA] (
    [ID_AUDITORIA]  INT            IDENTITY (1, 1) NOT NULL,
    [DSC_AUDITORIA] NVARCHAR (250) NULL,
    [ID_USUARIO]    INT            NULL,
    [FCH_ACCION]    DATETIME       NULL,
    [DSC_ACCION]    NVARCHAR (250) NULL,
    [FEC_ALTA]      DATETIME       NULL,
    [FEC_MOD]       DATETIME       NULL,
    [USUARIO]       VARCHAR (30)   NULL,
    [ID_APLICACION] INT            NULL,
    [ID_SUCURSAL]   INT            NULL,
    CONSTRAINT [PK__IU_D_AUD__13674E804F1660BE] PRIMARY KEY CLUSTERED ([ID_AUDITORIA] ASC),
    CONSTRAINT [FK_GL_D_AUDITORIA_GL_C_APLICACION_IST] FOREIGN KEY ([ID_APLICACION]) REFERENCES [dbo].[GL_C_APLICACION_IST] ([ID_APLICACION_IST]),
    CONSTRAINT [FK_GL_D_AUDITORIA_GL_D_SUCURSAL] FOREIGN KEY ([ID_SUCURSAL]) REFERENCES [dbo].[GL_C_SUCURSAL] ([ID_SUCURSAL])
);

