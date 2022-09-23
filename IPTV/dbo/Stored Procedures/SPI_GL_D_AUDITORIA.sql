-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE [dbo].[SPI_GL_D_AUDITORIA]
    @DSC_AUDITORIA NVARCHAR(250)
    ,@ID_USUARIO INT
    ,@FCH_ACCION DATETIME
    ,@DSC_ACCION NVARCHAR(250)
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
    ,@ID_APLICACION INT
    ,@ID_SUCURSAL INT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_AUDITORIA
    (
      DSC_AUDITORIA
      ,ID_USUARIO
      ,FCH_ACCION
      ,DSC_ACCION
      ,FEC_ALTA
      --,FEC_MOD
      ,USUARIO
      ,ID_APLICACION
      ,ID_SUCURSAL
    )
  VALUES
  (
    @DSC_AUDITORIA
    ,@ID_USUARIO
    ,@FCH_ACCION
    ,@DSC_ACCION
    ,GETDATE()--@FEC_ALTA
    --,@FEC_MOD
    ,@USUARIO
    ,@ID_APLICACION
    ,@ID_SUCURSAL
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

