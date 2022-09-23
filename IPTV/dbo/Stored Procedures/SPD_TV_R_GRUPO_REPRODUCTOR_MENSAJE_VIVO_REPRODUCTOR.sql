﻿-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 02/04/2020
-- Description: Eliminar un registro de la tabla 
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO_REPRODUCTOR]
	-- Add the parameters for the stored procedure here
	@ID_REPRODUCTOR INT
	,@ID_MENSAJE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	DELETE TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
	WHERE ID_REPRODUCTOR = @ID_REPRODUCTOR
	AND ID_MENSAJE = @ID_MENSAJE
	SET NOCOUNT OFF
END
