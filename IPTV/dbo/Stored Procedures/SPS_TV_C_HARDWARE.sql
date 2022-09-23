
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_C_HARDWARE
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_HARDWARE]
    @ID_HARDWARE INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_HARDWARE
      ,DESCRIPCION
      ,ID_ESTATUS
      ,DETALLE
    FROM TV_C_HARDWARE
    WHERE
      ID_HARDWARE = @ID_HARDWARE
  SET NOCOUNT OFF
END

