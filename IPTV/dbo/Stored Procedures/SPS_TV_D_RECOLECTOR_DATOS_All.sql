
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_RECOLECTOR_DATOS
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_RECOLECTOR_DATOS_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_RECOLECTOR
    ,ID_TEMPLATE
    ,ARCHIVO_XML
    ,FEC_ALTA
    ,FEC_MOD
    ,ID_ESTATUS
    ,USUARIO
  FROM TV_D_RECOLECTOR_DATOS
  SET NOCOUNT OFF
END

