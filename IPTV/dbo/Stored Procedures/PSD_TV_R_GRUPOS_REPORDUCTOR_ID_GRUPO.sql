-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 24/03/2020
-- Description:	Eliminar TV_R_GRUPOS_REPRODUCTOR POR ID_GRUPO
-- =============================================
CREATE PROCEDURE PSD_TV_R_GRUPOS_REPORDUCTOR_ID_GRUPO
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	DELETE FROM TV_R_GRUPO_REPRODUCTOR
    WHERE
      ID_GRUPO = @ID_GRUPO 
	SET NOCOUNT OFF
END
