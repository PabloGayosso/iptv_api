﻿CREATE PROCEDURE [dbo].[SPS_TV_D_HORARIO_TERMINAL]
	@ID_HORARIO_TERMINAL INT
  AS
BEGIN
  SET NOCOUNT ON
	SELECT  h.*
	FROM TV_D_HORARIO_TERMINAL h
	WHERE h.IdTvHorarioTerminal = @ID_HORARIO_TERMINAL
  SET NOCOUNT OFF
END

