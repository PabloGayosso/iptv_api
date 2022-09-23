
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_C_HARDWARE
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_HARDWARE_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_HARDWARE
      ,DESCRIPCION
      ,ID_ESTATUS
      ,DETALLE
    FROM TV_C_HARDWARE
  SET NOCOUNT OFF
END

