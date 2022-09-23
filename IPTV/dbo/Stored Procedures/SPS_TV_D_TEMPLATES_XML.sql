-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  13/01/2021
-- Description:  Selecciona un registro en especifico de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_TEMPLATES_XML]
    @ID_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_TEMPLATE
    ,NOMBRE
    ,ALTO
    ,ANCHO
    ,CANTIDAD_REGIONES
    ,ID_ESTATUS
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_D_TEMPLATES
  WHERE
    ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END