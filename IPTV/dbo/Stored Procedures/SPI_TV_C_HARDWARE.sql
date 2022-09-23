-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_C_HARDWARE
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_C_HARDWARE]
    @ID_HARDWARE INT
    ,@DESCRIPCION VARCHAR(500)
    ,@ID_ESTATUS INT
    ,@DETALLE VARCHAR(1000)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_C_HARDWARE
    (
      ID_HARDWARE
      ,DESCRIPCION
      ,ID_ESTATUS
      ,DETALLE
    )
  VALUES
  (
    @ID_HARDWARE
    ,@DESCRIPCION
    ,@ID_ESTATUS
    ,@DETALLE
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

