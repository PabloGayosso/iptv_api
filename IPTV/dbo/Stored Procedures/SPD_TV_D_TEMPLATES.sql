
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_D_TEMPLATES]
    @ID_TEMPLATE INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_D_TEMPLATES
    WHERE
      ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END

