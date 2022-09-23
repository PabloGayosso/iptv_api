-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  24/09/2018
-- Description:  Inserta registro en la tabla TV_R_REGION_CANAL
-- =============================================
CREATE PROCEDURE SPI_TV_R_REGION_CANAL_SIN
    @ID_REGION INT
    ,@ID_ESTATUS INT
    ,@ALTO INT
    ,@ANCHO INT
    ,@POSICION_X INT
    ,@POSICION_Y INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_R_REGION_CANAL
  (
    ID_REGION
    ,ID_ESTATUS
    ,ALTO
    ,ANCHO
    ,POSICION_X
    ,POSICION_Y
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_REGION
    ,@ID_ESTATUS
    ,@ALTO
    ,@ANCHO
    ,@POSICION_X
    ,@POSICION_Y
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
