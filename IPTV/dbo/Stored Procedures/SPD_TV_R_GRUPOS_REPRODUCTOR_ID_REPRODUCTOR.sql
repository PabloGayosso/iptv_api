-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 26/03/2020
-- Description:	Eliminar TV_R_GRUPO_REPRODUCTOR por ID_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_R_GRUPOS_REPRODUCTOR_ID_REPRODUCTOR]
	-- Add the parameters for the stored procedure here
	@ID_REPRODUCTOR INT,
	@ID_GRUPO INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	DELETE TV_R_GRUPO_REPRODUCTOR
	WHERE ID_REPRODUCTOR = @ID_REPRODUCTOR

	UPDATE TV_D_GRUPOS
	SET CANTIDAD_REPRODUCTORES = (SELECT COUNT(ID_GRUPO) FROM TV_R_GRUPO_REPRODUCTOR WHERE ID_GRUPO=@ID_GRUPO)
	WHERE ID_GRUPO = @ID_GRUPO

	SET NOCOUNT OFF
END
