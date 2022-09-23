﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPS_D_GRUPOS
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT
	G.ID_GRUPO,
	G.NOMBRE,
	G.DESCRIPCION,
	G.CANTIDAD_REPRODUCTORES,
	G.FECHA_ALTA,
	G.FECHA_MOD,
	G.USUARIO,
	G.ID_ESTATUS,
	G.ID_TEMPLATE,
	T.NOMBRE AS TEMPLATE_NOMBRE
	 FROM TV_D_GRUPOS G
	 INNER JOIN TV_D_TEMPLATES T ON G.ID_TEMPLATE = T.ID_TEMPLATE
	WHERE G.ID_GRUPO = @ID_GRUPO;
	  SET NOCOUNT OFF
END
