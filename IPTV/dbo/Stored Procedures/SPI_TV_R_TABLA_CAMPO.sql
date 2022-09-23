-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Inserta registro en la tabla TV_R_TABLA_CAMPO
-- =============================================
CREATE PROCEDURE SPI_TV_R_TABLA_CAMPO
    @ID_TABLA INT
    ,@ID_CAMPO INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO NVARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_R_TABLA_CAMPO
  (
    ID_TABLA
    ,ID_CAMPO
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_TABLA
    ,@ID_CAMPO
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
