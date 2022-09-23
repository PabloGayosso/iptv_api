
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_TEMPLATES]
    @ID_TEMPLATE INT
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
      ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END

