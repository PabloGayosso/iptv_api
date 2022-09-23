
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  31/03/2020
-- Description:  Selecciona un registro en especifico de la tabla TV_D_MENSAJE_VIVO por grupo de acceso
-- =============================================
CREATE PROCEDURE SPS_TV_D_MENSAJE_VIVO_GRUPO
    @ID_GRUPO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    TA.ID_MENSAJE
    ,TA.ID_ESTATUS
    ,TA.DSC_MENSAJE
    ,TA.ES_REPETITIVO
    ,TA.TIEMPO_REPETICION
    ,TA.FECHA_ALTA
    ,TA.FECHA_MOD
    ,TA.USUARIO
  FROM TV_D_MENSAJE_VIVO TA
  LEFT JOIN TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO TB ON TB.ID_MENSAJE = TA.ID_MENSAJE
  WHERE
    TB.ID_GRUPO = @ID_GRUPO
  SET NOCOUNT OFF
END
