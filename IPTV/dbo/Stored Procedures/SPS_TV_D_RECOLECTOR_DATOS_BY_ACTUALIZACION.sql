
-- =============================================
-- Create date:  30/01/2019
-- Description:  Selecciona todos los registros de la tabla TV_D_RECOLECTOR_DATOS PARA ACTUALIZAR
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_RECOLECTOR_DATOS_BY_ACTUALIZACION]
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
  WHERE ACTUALIZACION ='1'
  SET NOCOUNT OFF
END

