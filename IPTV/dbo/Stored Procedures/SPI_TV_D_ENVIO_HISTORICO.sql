-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_ENVIO_HISTORICO]
    @ID_ENVIO INT
    ,@NOMBRE_CONTENIDO NCHAR(50)
    ,@REPRODUCTOR VARCHAR(50)
    ,@USUARIO VARCHAR(150)
    ,@FEC_ENVIO VARCHAR(150)
    ,@FEC_ALTA VARCHAR(150)
    ,@ESTATUS NVARCHAR(200)
AS
BEGIN
  SET NOCOUNT ON

  DELETE FROM TV_D_ENVIO WHERE ID_ENVIO = @ID_ENVIO

  INSERT INTO TV_D_ENVIO_HISTORICO
    (
      NOMBRE_CONTENIDO,
      REPRODUCTOR,
      USUARIO,
      FEC_ENVIO,
      FEC_ALTA,
      ESTATUS
    )
  VALUES
  (
      @NOMBRE_CONTENIDO,
      @REPRODUCTOR,
      @USUARIO,
      @FEC_ENVIO,
      @FEC_ALTA,
      @ESTATUS
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END