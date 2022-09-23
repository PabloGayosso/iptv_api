-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_C_EXTENSIONES
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_C_EXTENSIONES]
    @ID_EXTENSION INT
    ,@ID_TIPO_REPRODUCCION INT
    ,@DESCRIPCION VARCHAR(10)
    ,@ACTIVO BIT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_C_EXTENSIONES
    (
      ID_EXTENSION
      ,ID_TIPO_REPRODUCCION
      ,DESCRIPCION
      ,ACTIVO
    )
  VALUES
  (
    @ID_EXTENSION
    ,@ID_TIPO_REPRODUCCION
    ,@DESCRIPCION
    ,@ACTIVO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

