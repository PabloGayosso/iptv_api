
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_C_EXTENSIONES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_EXTENSIONES_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_EXTENSION
      ,ID_TIPO_REPRODUCCION
      ,DESCRIPCION
      ,ACTIVO
    FROM TV_C_EXTENSIONES
  SET NOCOUNT OFF
END

