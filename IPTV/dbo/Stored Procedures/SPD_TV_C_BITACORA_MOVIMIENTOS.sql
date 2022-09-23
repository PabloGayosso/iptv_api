
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_C_BITACORA_MOVIMIENTOS
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_C_BITACORA_MOVIMIENTOS]
    @ID_BITACORA INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM TV_C_BITACORA_MOVIMIENTOS
    WHERE
      ID_BITACORA = @ID_BITACORA
  SET NOCOUNT OFF
END

