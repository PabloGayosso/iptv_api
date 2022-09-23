-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  05/09/2018
-- Description:  Inserta registro en la tabla GL_R_PERSONA_DIRECCION
-- =============================================
CREATE PROCEDURE SPI_GL_R_PERSONA_DIRECCION
    @ID_PERSONA INT
    ,@ID_DIRECCION INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_R_PERSONA_DIRECCION
    (
      ID_PERSONA
      ,ID_DIRECCION
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_PERSONA
    ,@ID_DIRECCION
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
