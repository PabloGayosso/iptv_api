
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_TIPO_ASENTAMIENTO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_TIPO_ASENTAMIENTO_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_TIPO_ASENTAMIENTO
      ,DESC_TIPO_ASENTAMIENTO
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_TIPO_ASENTAMIENTO
  SET NOCOUNT OFF
END

