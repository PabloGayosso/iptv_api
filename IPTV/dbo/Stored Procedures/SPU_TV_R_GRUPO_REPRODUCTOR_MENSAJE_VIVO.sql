﻿-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 02/04/2020
-- Description:	Buscar registro por ID_MENSAJE
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO]
	-- Add the parameters for the stored procedure here
	@ID_GRUPO_REPRODUCTOR_MENSAJE INT,
	@ID_GRUPO INT,
	@ID_REPRODUCTOR INT,
	@ID_MENSAJE INT,
	@ID_ESTATUS INT,
	@USUARIO NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

	IF(@ID_GRUPO <> 0)
	BEGIN
	UPDATE TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
	SET
	ID_GRUPO = @ID_GRUPO,
	ID_REPRODUCTOR = NULL,
	ID_MENSAJE = @ID_MENSAJE,
	ID_ESTATUS = @ID_ESTATUS,
	USUARIO = @USUARIO,
	FECHA_MOD = GETDATE()
	WHERE ID_GRUPO_REPRODUCTOR_MENSAJE = @ID_GRUPO_REPRODUCTOR_MENSAJE
	END
	ELSE
	BEGIN
	UPDATE TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
	SET
	ID_GRUPO = NULL,
	ID_REPRODUCTOR = @ID_REPRODUCTOR,
	ID_MENSAJE = @ID_MENSAJE,
	ID_ESTATUS = @ID_ESTATUS,
	USUARIO = @USUARIO,
	FECHA_MOD = GETDATE()
	WHERE ID_GRUPO_REPRODUCTOR_MENSAJE = @ID_GRUPO_REPRODUCTOR_MENSAJE
	END
	SET NOCOUNT OFF
END
