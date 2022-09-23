
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Selecciona un registro en especifico de la tabla TV_R_TEMPLATE_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_TEMPLATE_CANAL]
    @ID_CANAL_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CANAL_TEMPLATE
    ,ID_TEMPLATE
    ,ID_CANAL
    ,ID_ESTATUS
    ,ALTO
    ,ANCHO
    ,POSICION_X
    ,POSICION_Y
    ,ORDEN
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_R_TEMPLATE_CANAL
  WHERE
    ID_CANAL_TEMPLATE = @ID_CANAL_TEMPLATE
  SET NOCOUNT OFF
END
