
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_SUCURSAL_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_SUCURSAL
      ,ID_ENTIDAD
      ,CLAVE
      ,NOMBRE
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_SUCURSAL
  SET NOCOUNT OFF
END

