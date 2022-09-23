-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 02/04/2020
-- Description:	Buscar registro por ID_MENSAJE
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO_ID_MENSAJE]
	-- Add the parameters for the stored procedure here
	@ID_GRUPO_REPRODUCTOR_MENSAJE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT * FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
	WHERE ID_GRUPO_REPRODUCTOR_MENSAJE = @ID_GRUPO_REPRODUCTOR_MENSAJE
	SET NOCOUNT OFF
END
