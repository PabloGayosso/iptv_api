-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  18/09/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_R_CANAL_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_R_CANAL_CONTENIDO_ID_CANAL]
    @ID_CANAL INT
    ,@ID_ESTATUS INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT
    CO.*
    ,CC.FEC_INICIO
    ,CC.FEC_FIN
    ,CC.INICIO_HRS
    ,CC.INICIO_MIN
    ,CC.INICIO_SEG
    ,CC.FIN_HRS
    ,CC.FIN_MIN
    ,CC.FIN_SEG
  FROM TV_D_CONTENIDO CO
  LEFT JOIN TV_R_CANAL_CONTENIDO CC
  ON CO.ID_CONTENIDO = CC.ID_CONTENIDO
  WHERE
    CC.ID_CANAL = @ID_CANAL AND CO.ID_ESTATUS=@ID_ESTATUS
  
  SET NOCOUNT OFF
END
