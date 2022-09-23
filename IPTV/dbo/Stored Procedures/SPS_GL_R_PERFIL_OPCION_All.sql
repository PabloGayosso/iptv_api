
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  16/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_R_PERFIL_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_R_PERFIL_OPCION_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_PERFIL
      ,ID_OPCION
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_R_PERFIL_OPCION
  SET NOCOUNT OFF
END

