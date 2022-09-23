-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_CANAL_]
    --@ID_CANAL INT
    --,@ID_CONTENIDO INT
    @ID_TIPO_CANAL INT
    --,@DURACION_SEG INT
    --,@DURACION_MIN INT
    --,@DURACION_HRS INT
    --,@INICIO_SEG INT
    --,@INICIO_MIN INT
    --,@INICIO_HRS INT
    --,@POSICION_X INT
    --,@POSICION_Y INT
    --,@FEC_REPRODUCCION DATETIME
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@ID_ESTATUS INT
    --,@ALTO INT
    --,@ANCHO INT
    ,@CANTIDAD_CONTENIDO INT
    ,@CLAVE VARCHAR(50) = ''
    --,@FEC_FIN DATETIME2
    --,@FEC_INICIO DATETIME2
    --,@FIN_HRS INT
    --,@FIN_MIN INT
    --,@FIN_SEG INT
    ,@USUARIO VARCHAR(50) = ''
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_CANAL
  (
    ID_TIPO_CANAL
    --,DURACION_SEG
    --,DURACION_MIN
    --,DURACION_HRS
    --,INICIO_SEG
    --,INICIO_MIN
    --,INICIO_HRS
    --,POSICION_X
    --,POSICION_Y
    --,FEC_REPRODUCCION
    ,FEC_ALTA
    --,FEC_MOD
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
    ,USUARIO
  )
  VALUES
  (
    @ID_TIPO_CANAL
    --,@DURACION_SEG
    --,@DURACION_MIN
    --,@DURACION_HRS
    --,@INICIO_SEG
    --,@INICIO_MIN
    --,@INICIO_HRS
    --,@POSICION_X
    --,@POSICION_Y
    --,@FEC_REPRODUCCION
    ,GETDATE()
    --,@FEC_MOD
    ,@ID_ESTATUS
    --,@ALTO
    --,@ANCHO
    ,@CANTIDAD_CONTENIDO
    ,@CLAVE
    --,@FEC_FIN
    --,@FEC_INICIO
    --,@FIN_HRS
    --,@FIN_MIN
    --,@FIN_SEG
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

