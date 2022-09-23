-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].SPS_D_GRUPOS_CATALOGO
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT
	ID_GRUPO,
	NOMBRE
	FROM TV_D_GRUPOS 
	WHERE ID_ESTATUS=3 AND CANTIDAD_REPRODUCTORES>0
	  SET NOCOUNT OFF
END
