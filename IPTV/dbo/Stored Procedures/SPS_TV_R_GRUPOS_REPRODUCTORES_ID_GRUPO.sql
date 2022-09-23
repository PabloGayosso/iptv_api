-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 24/03/2020
-- Description:	Consulta TV_R_GRUPOS_REPRODUCTORES por ID GRUPO devuelve los reproductores del Grupo
-- =============================================
CREATE PROCEDURE SPS_TV_R_GRUPOS_REPRODUCTORES_ID_GRUPO
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT 
	R.ID_REPRODUCTOR,
	R.DESCRIPCION,
	R.IP_CLIENTE
	FROM TV_R_GRUPO_REPRODUCTOR PR
	INNER JOIN TV_C_REPRODUCTOR R
	ON R.ID_REPRODUCTOR = PR.ID_REPRODUCTOR
	WHERE PR.ID_GRUPO = @ID_GRUPO
	SET NOCOUNT OFF
END
