
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Selecciona todos los registros de la tabla TV_R_TABLA_CAMPO
-- =============================================
CREATE PROCEDURE SPS_TV_R_TABLA_CAMPO_All
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_TABLA_CAMPO
    ,ID_TABLA
    ,ID_CAMPO
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_R_TABLA_CAMPO
  SET NOCOUNT OFF
END
