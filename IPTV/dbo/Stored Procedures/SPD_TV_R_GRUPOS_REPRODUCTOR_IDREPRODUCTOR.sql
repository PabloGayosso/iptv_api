-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 26/03/2020
-- Description:	Eliminar TV_R_GRUPO_REPRODUCTOR por ID_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_R_GRUPOS_REPRODUCTOR_IDREPRODUCTOR]
	-- Add the parameters for the stored procedure here
	@ID_REPRODUCTOR INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	DELETE TV_R_GRUPO_REPRODUCTOR
	WHERE ID_REPRODUCTOR = @ID_REPRODUCTOR

	SET NOCOUNT OFF
END
