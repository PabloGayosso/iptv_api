﻿CREATE TABLE [dbo].[TV_D_COLUMNA]
(
    [ID_COLUMNA] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [NOMBRE_BD] NVARCHAR (250) NULL,
    [NOMBRE]    NVARCHAR (250) NULL,
    [FEC_ALTA]  DATETIME       NULL,
    [FEC_MOD]   DATETIME       NULL,
    [USUARIO]   NVARCHAR (250) NULL,

)
