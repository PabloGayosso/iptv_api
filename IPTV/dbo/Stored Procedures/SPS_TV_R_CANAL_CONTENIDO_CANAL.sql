-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  18/09/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_R_CANAL_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_CANAL_CONTENIDO_CANAL]
    @ID_CANAL INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CANAL
    ,ID_CONTENIDO
    ,ORDEN
    ,ID_ESTATUS
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_R_CANAL_CONTENIDO
  WHERE
    ID_CANAL = @ID_CANAL
  ORDER BY ORDEN
  SET NOCOUNT OFF
END
