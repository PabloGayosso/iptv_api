-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_ENVIO]
    @NOMBRE_CONTENIDO NCHAR(50)
    ,@REPRODUCTOR VARCHAR(50)
    ,@USUARIO VARCHAR(150)
    ,@FEC_ENVIO DATETIME
    ,@VELOCIDAD VARCHAR(50)
    ,@TAM_TOTAL VARCHAR(150)
    ,@TAM_DESCARGADO VARCHAR(150)
    ,@PORCENTAJE INT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_ENVIO
    (
      NOMBRE_CONTENIDO,
      REPRODUCTOR,
      USUARIO,
      FEC_ENVIO,
      VELOCIDAD,
      TAM_TOTAL,
      TAM_DESCARGADO,
      PORCENTAJE,
	    FEC_ALTA,
	    FEC_ACTUALIZACION
    )
  VALUES
  (
      @NOMBRE_CONTENIDO,
      @REPRODUCTOR,
      @USUARIO,
      @FEC_ENVIO,
      @VELOCIDAD,
      @TAM_TOTAL,
      @TAM_DESCARGADO,
      @PORCENTAJE,
	    GETDATE(),
	    GETDATE()
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

