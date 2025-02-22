﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE SPU_TV_D_CONTENIDO_MULTIMEDIA
     @ID_CONTENIDO INT
    ,@ID_REPOSITORIO INT
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
	,@ES_REPETITIVO bit
	,@ES_INTERMITENCIA bit
	,@INTERMITENCIA_SEG int
	,@INTERMITENCIA_MIN int
	,@INTERMITENCIA_HRS INT
	,@VOLUMEN decimal(15,2)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_D_CONTENIDO SET
    ID_REPOSITORIO = @ID_REPOSITORIO
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
	,ES_REPETITIVO = @ES_REPETITIVO
	,ES_INTERMITENCIA = @ES_INTERMITENCIA
	,INTERMITENCIA_SEG = @INTERMITENCIA_SEG
	,INTERMITENCIA_MIN = @INTERMITENCIA_MIN
	,INTERMITENCIA_HRS = @INTERMITENCIA_HRS
	,VOLUMEN = @VOLUMEN
  WHERE
      ID_CONTENIDO = @ID_CONTENIDO
  SET NOCOUNT OFF
END

