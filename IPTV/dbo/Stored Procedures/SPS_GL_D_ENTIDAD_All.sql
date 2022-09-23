
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_ENTIDAD
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_ENTIDAD_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_ENTIDAD
      ,CLAVE_IS
      ,RAZON_SOCIAL
      ,RFC
      ,ES_GRUPO
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_ENTIDAD
  SET NOCOUNT OFF
END

