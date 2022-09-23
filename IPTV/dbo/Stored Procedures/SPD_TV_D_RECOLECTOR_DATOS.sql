
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_RECOLECTOR_DATOS
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_RECOLECTOR_DATOS]
    @ID_RECOLECTOR INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_RECOLECTOR_DATOS
    WHERE
      ID_RECOLECTOR = @ID_RECOLECTOR
  SET NOCOUNT OFF
END

