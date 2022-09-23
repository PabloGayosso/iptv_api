
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  31/03/2020
-- Description:  Selecciona un registro en especifico de la tabla TV_D_MENSAJE_VIVO por player
-- =============================================
CREATE PROCEDURE SPS_TV_D_MENSAJE_VIVO_REPRODUCTOR_IP
    @IP_CLIENTE NVARCHAR(20)
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
  LEFT JOIN TV_C_REPRODUCTOR TC ON TC.ID_REPRODUCTOR = TB.ID_REPRODUCTOR
  WHERE
    TC.IP_CLIENTE = @IP_CLIENTE
  SET NOCOUNT OFF
END
