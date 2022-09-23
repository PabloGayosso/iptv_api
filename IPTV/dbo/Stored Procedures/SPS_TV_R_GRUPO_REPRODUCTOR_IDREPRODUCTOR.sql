-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPS_TV_R_GRUPO_REPRODUCTOR_IDREPRODUCTOR
	-- Add the parameters for the stored procedure here
	@ID_REPRODUCTOR INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT 
	G.ID_GRUPO 
	FROM TV_C_REPRODUCTOR R
	INNER JOIN TV_R_GRUPO_REPRODUCTOR GR
	ON R.ID_REPRODUCTOR = GR.ID_REPRODUCTOR
	INNER JOIN TV_D_GRUPOS G
	ON G.ID_GRUPO = GR.ID_GRUPO
	WHERE R.ID_REPRODUCTOR = @ID_REPRODUCTOR;
	SET NOCOUNT OFF
END
