-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 02/04/2020
-- Description:	Buscar registro por ID_MENSAJE_VIVO
-- =============================================
CREATE PROCEDURE SPS_TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO_ALL
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT * FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
	SET NOCOUNT OFF
END
