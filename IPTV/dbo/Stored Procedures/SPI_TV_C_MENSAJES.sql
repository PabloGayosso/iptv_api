-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_C_MENSAJES
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_C_MENSAJES]
    @NOMBRE NVARCHAR(50)
    ,@DESCRIPCION VARCHAR(MAX)
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@ID_ESTATUS INT
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_C_MENSAJES
  (
    NOMBRE
    ,DESCRIPCION
    ,FEC_ALTA
    --,FEC_MOD
    ,ID_ESTATUS
    ,USUARIO
  )
  VALUES
  (
    @NOMBRE
    ,@DESCRIPCION
    ,GETDATE()
    --,@FEC_MOD
    ,@ID_ESTATUS
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

