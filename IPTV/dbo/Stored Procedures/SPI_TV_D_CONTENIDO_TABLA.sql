-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  18/11/2020
-- Description:  Inserta registro en la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE [SPI_TV_D_CONTENIDO_TABLA]
   @ID_TABLA INT
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
  INSERT INTO TV_D_CONTENIDO
  (
    ID_TABLA
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
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
     @ID_TABLA
    ,@ID_TIPO_CANAL
    ,@RUTA
    ,@NOMBRE
    ,@DURACION_SEG
    ,@DURACION_MIN
    ,@DURACION_HRS
    ,@ORDEN
    --,@POSICION_X
    --,@POSICION_Y
    --,@ANCHO
    --,@ALTO
    ,@OPACIDAD
    ,@TEXTO
    ,@ID_ESTATUS
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END