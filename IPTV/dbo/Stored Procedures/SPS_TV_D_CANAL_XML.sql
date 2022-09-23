-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  13/01/2021
-- Description:  Selecciona un registro en especifico de la tabla TV_D_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_CANAL_XML]
    @ID_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    TA.ID_CANAL
    ,TA.CLAVE
    ,TA.ID_TIPO_CANAL
    ,TB.ORDEN
    ,TA.CANTIDAD_CONTENIDO
    ,TB.ALTO
    ,TB.ANCHO
    ,TB.POSICION_X
    ,TB.POSICION_Y
    ,TA.ID_ESTATUS
    ,TA.FEC_ALTA
    ,TA.FEC_MOD
    ,TA.USUARIO
  FROM TV_D_CANAL TA
  LEFT JOIN TV_R_TEMPLATE_CANAL TB ON TB.ID_CANAL = TA.ID_CANAL
  WHERE
    TB.ID_TEMPLATE = @ID_TEMPLATE
  ORDER BY TB.ORDEN
  SET NOCOUNT OFF
END