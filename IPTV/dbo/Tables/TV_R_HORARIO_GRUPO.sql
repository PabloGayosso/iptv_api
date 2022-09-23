﻿CREATE TABLE [dbo].[TV_R_HORARIO_GRUPO]
(
	[ID_HORARIO_GRUPO] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_HORARIO] INT NOT NULL,
	[ID_GRUPO] INT NOT NULL,
	[FECH_ALTA] DATETIME DEFAULT GETDATE(),
	[USUARIO] NVARCHAR(150) NOT NULL,
	CONSTRAINT [FK_HORARIO_GRUPO_GRUPO] FOREIGN KEY (ID_GRUPO) REFERENCES [dbo].[TV_D_GRUPOS] (ID_GRUPO),
	CONSTRAINT [FK_HORARIO_GRUPO_HORARIO] FOREIGN KEY (ID_HORARIO) REFERENCES [dbo].[TV_D_HORARIO_TERMINAL] (IdTvHorarioTerminal)
)
