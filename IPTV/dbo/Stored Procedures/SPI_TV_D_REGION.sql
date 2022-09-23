-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_REGION
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_REGION]
    @ALTO INT
    ,@ANCHO INT
    ,@DESC_REGION VARCHAR(50)
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@POSICION_X INT
    ,@POSICION_Y INT
    ,@USUARIO VARCHAR(50)
    ,@ID_ESTATUS INT
    ,@ID_TEMPLATE INT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_REGION
    (
      ALTO
      ,ANCHO
      ,DESC_REGION
      ,FEC_ALTA
      --,FEC_MOD
      ,POSICION_X
      ,POSICION_Y
      ,USUARIO
      ,ID_ESTATUS
      ,ID_TEMPLATE
    )
  VALUES
  (
    @ALTO
    ,@ANCHO
    ,@DESC_REGION
    ,GETDATE()
    --,@FEC_MOD
    ,@POSICION_X
    ,@POSICION_Y
    ,@USUARIO
    ,@ID_ESTATUS
    ,@ID_TEMPLATE
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

