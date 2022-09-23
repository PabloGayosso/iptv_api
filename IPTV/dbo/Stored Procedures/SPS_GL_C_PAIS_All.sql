
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_PAIS
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_PAIS_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_PAIS
      ,DESC_PAIS
      ,GENTILICIO
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_PAIS
  SET NOCOUNT OFF
END

