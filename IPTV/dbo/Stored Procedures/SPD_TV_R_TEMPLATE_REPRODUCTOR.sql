
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  27/09/2018
-- Description:  Elimina un registro en especifico de la tabla TV_R_TEMPLATE_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_R_TEMPLATE_REPRODUCTOR]
    @ID_REPRODUCTOR INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_R_TEMPLATE_REPRODUCTOR
    WHERE
    ID_REPRODUCTOR = @ID_REPRODUCTOR
  SET NOCOUNT OFF
END
