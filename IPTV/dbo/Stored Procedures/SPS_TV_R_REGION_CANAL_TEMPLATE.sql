
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  24/09/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_R_REGION_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_REGION_CANAL_TEMPLATE]
    @ID_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
	TA.ID_CANAL_REGION
    ,TA.ID_REGION
    ,TA.ID_CANAL
    ,TA.ID_ESTATUS
    ,TA.ALTO
    ,TA.ANCHO
    ,TA.POSICION_X
    ,TA.POSICION_Y
    ,TA.FEC_ALTA
    ,TA.FEC_MOD
    ,TA.USUARIO
  FROM TV_R_REGION_CANAL TA
  LEFT JOIN TV_D_REGION TB ON TB.ID_REGION = TA.ID_REGION
  WHERE
    TB.ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END
