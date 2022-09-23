-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  18/11/2020
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_CONTENIDO_TABLA]
     @ID_CONTENIDO INT
    ,@ID_TABLA INT
    ,@ID_TIPO_CANAL INT
    ,@RUTA VARCHAR(150)
    ,@NOMBRE NCHAR(50)
    ,@DURACION_SEG INT
    ,@DURACION_MIN INT
    ,@DURACION_HRS INT
    ,@ORDEN INT
    --,@POSICION_X INT
    --,@POSICION_Y INT
    --,@ANCHO INT
    --,@ALTO INT
    ,@OPACIDAD DECIMAL
    ,@TEXTO VARCHAR(500)
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
    UPDATE TV_D_CONTENIDO SET
     ID_TABLA = @ID_TABLA
    ,ID_TIPO_CANAL = @ID_TIPO_CANAL
    ,RUTA = @RUTA
    ,NOMBRE = @NOMBRE
    ,DURACION_SEG = @DURACION_SEG
    ,DURACION_MIN = @DURACION_MIN
    ,DURACION_HRS = @DURACION_HRS
    ,ORDEN = @ORDEN
    --,POSICION_X = @POSICION_X
    --,POSICION_Y = @POSICION_Y
    --,ANCHO = @ANCHO
    --,ALTO = @ALTO
    ,OPACIDAD = @OPACIDAD
    ,TEXTO = @TEXTO
    ,ID_ESTATUS = @ID_ESTATUS
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
      ID_CONTENIDO = @ID_CONTENIDO
  SET NOCOUNT OFF
END