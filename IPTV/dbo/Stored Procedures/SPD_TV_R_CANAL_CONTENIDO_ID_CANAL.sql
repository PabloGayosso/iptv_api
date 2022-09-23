-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  19/09/2018
-- Description:  Elimina un registro en especifico de la tabla TV_R_CANAL_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_R_CANAL_CONTENIDO_ID_CANAL]
    @ID_CANAL INT   
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_R_CANAL_CONTENIDO
  WHERE
    ID_CANAL = @ID_CANAL 
  SET NOCOUNT OFF
END
