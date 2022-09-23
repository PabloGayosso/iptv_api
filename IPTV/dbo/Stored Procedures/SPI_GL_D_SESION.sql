-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_SESION
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_SESION]
    @ID_ESTACION_TRABAJO INT
    ,@INICIO DATETIME
    ,@ID_ESTATUS INT
    ,@FIN DATETIME
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_SESION
    (
      ID_ESTACION_TRABAJO
      ,INICIO
      ,ID_ESTATUS
      ,FIN
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    )
  VALUES
  (
    @ID_ESTACION_TRABAJO
    ,@INICIO
    ,@ID_ESTATUS
    ,@FIN
    ,@FEC_ALTA
    ,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

