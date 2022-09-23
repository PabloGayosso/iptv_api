
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_REPOSITORIO]
    @ID_REPOSITORIO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_REPOSITORIO
    WHERE
      ID_REPOSITORIO = @ID_REPOSITORIO
  SET NOCOUNT OFF
END

