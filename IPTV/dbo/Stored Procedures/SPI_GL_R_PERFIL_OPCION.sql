-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  16/08/2018
-- Description:  Inserta registro en la tabla GL_R_PERFIL_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_R_PERFIL_OPCION]
    @ID_PERFIL INT
    ,@ID_OPCION INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_R_PERFIL_OPCION
  (
    ID_PERFIL
    ,ID_OPCION
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_PERFIL
    ,@ID_OPCION
    ,GETDATE()--@FEC_ALTA
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

