-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona los registros de la tabla GL_R_SUCURSAL_APLICACION_IST por sucursal
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_R_SUCURSAL_APLICACION_IST_SUCURSAL]
  @ID_SUCURSAL INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_SUCURSAL_APLICACION
    ,ID_SUCURSAL
    ,ID_APLICACION_IST
    ,LICENCIA_ACTIVADA
    ,LICENCIA
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM GL_R_SUCURSAL_APLICACION_IST
  WHERE
    ID_SUCURSAL = @ID_SUCURSAL
  SET NOCOUNT OFF
END

