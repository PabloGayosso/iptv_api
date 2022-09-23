-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Inserta registro en la tabla TV_D_CAMPO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_CAMPO]
    @NOMBRE_CAMPO NVARCHAR(255)
    ,@ETIQUETA NVARCHAR(255)
    ,@ID_TIPO_DATO INT
    ,@TAMAÑO INT
    ,@ID_TABLA INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO NVARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  DECLARE @ID_CAMPO INT
  INSERT INTO TV_D_CAMPO
  (
    NOMBRE_CAMPO
    ,ETIQUETA
    ,ID_TIPO_DATO
    ,TAMAÑO
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @NOMBRE_CAMPO
    ,@ETIQUETA
    ,@ID_TIPO_DATO
    ,@TAMAÑO
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @ID_CAMPO = @@IDENTITY

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

  SELECT @ID_CAMPO

  SET NOCOUNT OFF
END
