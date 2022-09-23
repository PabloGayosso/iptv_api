
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_CANAL_]
    @ID_CANAL INT
    --,@ID_CONTENIDO INT
    ,@ID_TIPO_CANAL INT
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
  UPDATE TV_D_CANAL SET
    --ID_CONTENIDO = @ID_CONTENIDO
    ID_TIPO_CANAL = @ID_TIPO_CANAL
    --,DURACION_SEG = @DURACION_SEG
    --,DURACION_MIN = @DURACION_MIN
    --,DURACION_HRS = @DURACION_HRS
    --,INICIO_SEG = @INICIO_SEG
    --,INICIO_MIN = @INICIO_MIN
    --,INICIO_HRS = @INICIO_HRS
    --,POSICION_X = @POSICION_X
    --,POSICION_Y = @POSICION_Y
    --,FEC_REPRODUCCION = @FEC_REPRODUCCION
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,ID_ESTATUS = @ID_ESTATUS
    --,ALTO = @ALTO
    --,ANCHO = @ANCHO
    ,CANTIDAD_CONTENIDO = @CANTIDAD_CONTENIDO
    ,CLAVE = @CLAVE
    --,FEC_FIN = @FEC_FIN
    --,FEC_INICIO = @FEC_INICIO
    --,FIN_HRS = @FIN_HRS
    --,FIN_MIN = @FIN_MIN
    --,FIN_SEG = @FIN_SEG
    ,USUARIO = @USUARIO
  WHERE
      ID_CANAL = @ID_CANAL
  SET NOCOUNT OFF
END

