-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_REPOSITORIO]
    @DESCRIPCION VARCHAR(50)
    ,@RUTA_ALOJAMIENTO VARCHAR(150)
    ,@EXTENSION VARCHAR(10)
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@DURACION TIME
    ,@USUARIO VARCHAR(30)
    ,@ID_TIPO_CONTENIDO INT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_REPOSITORIO
  (
    DESCRIPCION
    ,RUTA_ALOJAMIENTO
    ,EXTENSION
    ,DURACION
    ,ID_ESTATUS
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
    ,ID_TIPO_CONTENIDO
  )
  VALUES
  (
    @DESCRIPCION
    ,@RUTA_ALOJAMIENTO
    ,@EXTENSION
    ,@DURACION
    ,@ID_ESTATUS
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
    ,@ID_TIPO_CONTENIDO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

