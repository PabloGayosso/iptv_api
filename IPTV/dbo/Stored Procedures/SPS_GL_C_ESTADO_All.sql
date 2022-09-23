
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_ESTADO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_ESTADO_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_ESTADO
      ,DESC_ESTADO
      ,ABV
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_ESTADO
  SET NOCOUNT OFF
END

