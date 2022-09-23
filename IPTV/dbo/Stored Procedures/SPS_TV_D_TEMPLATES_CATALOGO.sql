
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_TEMPLATES_CATALOGO]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_TEMPLATE
      ,NOMBRE
    FROM TV_D_TEMPLATES
	WHERE ID_ESTATUS = 3
  SET NOCOUNT OFF
END

