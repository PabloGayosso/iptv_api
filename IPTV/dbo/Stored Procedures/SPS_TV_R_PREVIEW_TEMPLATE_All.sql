-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  20/01/2021
-- Description:  Selecciona todos los registros de la tabla TV_R_PREVIEW_TEMPLATE
-- =============================================
CREATE PROCEDURE SPS_TV_R_PREVIEW_TEMPLATE_All
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_PREVIEW
    ,ID_TEMPLATE
  FROM TV_R_PREVIEW_TEMPLATE
  SET NOCOUNT OFF
END
GO