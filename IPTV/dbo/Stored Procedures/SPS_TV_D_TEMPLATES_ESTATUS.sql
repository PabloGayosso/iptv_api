
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE SPS_TV_D_TEMPLATES_ESTATUS
  @ID_ESTATUS INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_TEMPLATE
    ,ALTO
    ,ANCHO
    ,CANTIDAD_REGIONES
    ,FEC_ALTA
    ,FEC_MOD
    ,NOMBRE
    ,USUARIO
    ,ID_ESTATUS
  FROM TV_D_TEMPLATES
  WHERE
    ID_ESTATUS = @ID_ESTATUS
  SET NOCOUNT OFF
END

