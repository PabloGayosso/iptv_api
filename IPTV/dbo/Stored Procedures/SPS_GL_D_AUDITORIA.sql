
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_AUDITORIA]
    @ID_AUDITORIA INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_AUDITORIA
      ,DSC_AUDITORIA
      ,ID_USUARIO
      ,FCH_ACCION
      ,DSC_ACCION
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
      ,ID_APLICACION
      ,ID_SUCURSAL
    FROM GL_D_AUDITORIA
    WHERE
      ID_AUDITORIA = @ID_AUDITORIA
  SET NOCOUNT OFF
END

