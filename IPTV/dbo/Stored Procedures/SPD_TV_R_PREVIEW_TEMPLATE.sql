-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  20/01/2021
-- Description:  Elimina un registro en especifico de la tabla TV_R_PREVIEW_TEMPLATE
-- =============================================
CREATE PROCEDURE SPD_TV_R_PREVIEW_TEMPLATE
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_R_PREVIEW_TEMPLATE SET
    ID_TEMPLATE = NULL
  SET NOCOUNT OFF
END
GO