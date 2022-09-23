-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  09/09/2019
-- Description:  Inserta registro en la tabla TV_D_TABLA
-- =============================================
CREATE PROCEDURE SPI_TV_D_TABLA
    @NOMBRE_BD NVARCHAR(250)
    ,@NOMBRE NVARCHAR(250)
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO NVARCHAR(250)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_TABLA
  (
    NOMBRE_BD
    ,NOMBRE
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @NOMBRE_BD
    ,@NOMBRE
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
