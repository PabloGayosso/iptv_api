-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Inserta registro en la tabla TV_R_TEMPLATE_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_R_TEMPLATE_CANAL]
    @ID_TEMPLATE INT
    ,@ID_CANAL INT = 0
    ,@ID_ESTATUS INT
    ,@ALTO INT
    ,@ANCHO INT
    ,@POSICION_X INT
    ,@POSICION_Y INT
    ,@ORDEN INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  IF( @ID_CANAL <> 0 )
  BEGIN
    INSERT INTO TV_R_TEMPLATE_CANAL
    (
      ID_TEMPLATE
      ,ID_CANAL
      ,ID_ESTATUS
      ,ALTO
      ,ANCHO
      ,POSICION_X
      ,POSICION_Y
      ,ORDEN
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
    )
    VALUES
    (
      @ID_TEMPLATE
      ,@ID_CANAL
      ,@ID_ESTATUS
      ,@ALTO
      ,@ANCHO
      ,@POSICION_X
      ,@POSICION_Y
      ,@ORDEN
      ,GETDATE()
      --,@FEC_MOD
      ,@USUARIO
    )
  END
  ELSE
  BEGIN
    INSERT INTO TV_R_TEMPLATE_CANAL
    (
      ID_TEMPLATE
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
      @ID_TEMPLATE
      ,@ID_ESTATUS
      ,@ALTO
      ,@ANCHO
      ,@POSICION_X
      ,@POSICION_Y
      ,GETDATE()
      --,@FEC_MOD
      ,@USUARIO
    )
  END
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
