
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_CONTENIDO]
    @ID_CONTENIDO INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_CONTENIDO
    WHERE
      ID_CONTENIDO = @ID_CONTENIDO
  SET NOCOUNT OFF
END

