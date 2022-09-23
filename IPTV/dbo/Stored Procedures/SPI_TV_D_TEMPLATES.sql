-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_TEMPLATES]
    @ALTO INT
    ,@ANCHO INT
    ,@CANTIDAD_REGIONES INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@NOMBRE VARCHAR(50)
    ,@USUARIO VARCHAR(50)
    ,@ID_ESTATUS INT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_TEMPLATES
    (
      ALTO
      ,ANCHO
      ,CANTIDAD_REGIONES
      ,FEC_ALTA
      --,FEC_MOD
      ,NOMBRE
      ,USUARIO
      ,ID_ESTATUS
    )
  VALUES
  (
    @ALTO
    ,@ANCHO
    ,@CANTIDAD_REGIONES
    ,GETDATE()
    --,@FEC_MOD
    ,@NOMBRE
    ,@USUARIO
    ,@ID_ESTATUS
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

