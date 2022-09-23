
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_CANAL_ESTATUS]
  @ID_ESTATUS INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CANAL
    ,ID_TIPO_CANAL
    --,DURACION_SEG
    --,DURACION_MIN
    --,DURACION_HRS
    --,INICIO_SEG
    --,INICIO_MIN
    --,INICIO_HRS
    --,POSICION_X
    --,POSICION_Y
    --,ES_REPETITIVO
    --,ID_TIPO_PRESENTACION
    --,ID_FORMA_DESPLIEGUE
    --,ES_COLOR_FONDO_TEXTO
    --,OPACIDAD_BARRA_TEXTO
    --,COLOR_FONDO_BARRA_TEXTO
    --,RUTA_IMG_FONDO_BARRA_TEXTO
    --,VELOCIDAD_TEXTO
    --,TIPO_LETRA_TEXTO
    --,TAMANIO_LETRA_TEXTO
    --,OPACIDAD_TEXTO
    --,COLOR_TEXTO
    --,ANCHO_BARRA_TEXTO
    --,ALTO_BARRA_TEXTO
    --,ORIENTACION_TEXTO
    --,POSICION_X_FIN_TEXTO
    --,POSICION_Y_FIN_TEXTO
    --,FEC_REPRODUCCION
    ,FEC_ALTA
    ,FEC_MOD
    --,ORDEN
    ,ID_ESTATUS
    --,ALTO
    --,ANCHO
    ,CANTIDAD_CONTENIDO
    ,CLAVE
    --,FEC_FIN
    --,FEC_INICIO
    --,FIN_HRS
    --,FIN_MIN
    --,FIN_SEG
    --,OPACIDAD
    ,USUARIO
  FROM TV_D_CANAL
  WHERE
    ID_ESTATUS = @ID_ESTATUS
  SET NOCOUNT OFF
END

