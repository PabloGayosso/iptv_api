-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_ENTIDAD
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_ENTIDAD]
    @CLAVE_IS VARCHAR(50)
    ,@RAZON_SOCIAL VARCHAR(250)
    ,@RFC VARCHAR(25)
    ,@ES_GRUPO BIT
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_ENTIDAD
    (
      CLAVE_IS
      ,RAZON_SOCIAL
      ,RFC
      ,ES_GRUPO
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @CLAVE_IS
    ,@RAZON_SOCIAL
    ,@RFC
    ,@ES_GRUPO
    ,@ID_ESTATUS
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

