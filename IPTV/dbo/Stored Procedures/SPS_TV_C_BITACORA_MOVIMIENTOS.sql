
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_C_BITACORA_MOVIMIENTOS
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_BITACORA_MOVIMIENTOS]
    @ID_BITACORA INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_BITACORA
      ,ID_REPRODUCTOR
      ,ID_TEMPLATE
      ,ID_REGION
      ,ID_CANAL
      ,ID_CONTENIDO
      ,ID_ESTATUS
      ,DESCRIPCION
      ,ID_USUARIO
      ,FEC_ALTA
      ,OPERACION
      ,TABLA
      ,IP_MODIFICO
    FROM TV_C_BITACORA_MOVIMIENTOS
    WHERE
      ID_BITACORA = @ID_BITACORA
  SET NOCOUNT OFF
END

