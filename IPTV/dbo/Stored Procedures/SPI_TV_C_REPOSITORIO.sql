-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE  [dbo].[SPI_TV_C_REPOSITORIO]
    @NOMBRE NVARCHAR(250)
    ,@RUTA_ALOJAMIENTO TEXT
     ,@USUARIO NVARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_C_REPOSITORIO
  (
    NOMBRE
    ,RUTA_ALOJAMIENTO
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @NOMBRE
    ,@RUTA_ALOJAMIENTO
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

