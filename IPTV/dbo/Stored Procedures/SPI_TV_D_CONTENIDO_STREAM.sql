﻿-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_CONTENIDO_STREAM]
  @ID_TIPO_CANAL INT
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
  ,@ID_ESTATUS INT
  --,@FEC_ALTA DATETIME
  --,@FEC_MOD DATETIME
  ,@USUARIO VARCHAR(50)
  ,@ES_INTERMITENCIA bit
  ,@INTERMITENCIA_SEG int
  ,@INTERMITENCIA_MIN int
  ,@INTERMITENCIA_HRS INT
  ,@VOLUMEN decimal(15,2)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_CONTENIDO
  (
    ID_TIPO_CANAL
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
    ,ID_ESTATUS
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
	,ES_INTERMITENCIA 
	,INTERMITENCIA_SEG 
	,INTERMITENCIA_MIN 
	,INTERMITENCIA_HRS 
	,VOLUMEN 
  )
  VALUES
  (
    @ID_TIPO_CANAL
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
    ,@ID_ESTATUS
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
	,@ES_INTERMITENCIA 
	,@INTERMITENCIA_SEG 
	,@INTERMITENCIA_MIN 
	,@INTERMITENCIA_HRS 
	,@VOLUMEN 
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

