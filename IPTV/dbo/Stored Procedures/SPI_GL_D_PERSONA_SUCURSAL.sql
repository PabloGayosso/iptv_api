-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_PERSONA_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_PERSONA_SUCURSAL]
    @ID_PERSONA INT
    ,@ID_SUCURSAL INT
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_PERSONA_SUCURSAL
    (
      ID_PERSONA
      ,ID_SUCURSAL
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_PERSONA
    ,@ID_SUCURSAL
    ,@ID_ESTATUS
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

