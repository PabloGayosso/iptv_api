-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPS_TV_R_GRUPO_REPRODUCTOR_ID_REPRODUCTOR
	-- Add the parameters for the stored procedure here
	@ID_REPRODUCTOR INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT 
	ID_GRUPO_REPRODUCTOR,
	ID_GRUPO,
	ID_REPRODUCTOR,
	FECHA_ALTA,
	FECHA_MOD,
	USAURIO
	FROM TV_R_GRUPO_REPRODUCTOR
	WHERE ID_REPRODUCTOR = @ID_REPRODUCTOR;
	SET NOCOUNT OFF
END
