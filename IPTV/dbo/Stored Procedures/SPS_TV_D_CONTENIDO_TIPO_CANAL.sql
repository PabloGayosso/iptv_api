
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE SPS_TV_D_CONTENIDO_TIPO_CANAL
  @ID_TIPO_CANAL INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CONTENIDO
    ,ID_REPOSITORIO
    ,ID_MENSAJE
    ,ID_TIPO_CANAL
    ,RUTA
    ,NOMBRE
    ,DURACION_SEG
    ,DURACION_MIN
    ,DURACION_HRS
    ,ORDEN
    --,POSICION_X
    --,POSICION_Y
    --,ANCHO
    --,ALTO
    ,OPACIDAD
    ,TEXTO
    ,ID_ESTATUS
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_D_CONTENIDO
  WHERE
    ID_TIPO_CANAL = @ID_TIPO_CANAL
  SET NOCOUNT OFF
END

