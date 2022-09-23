
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Selecciona un registro en especifico de la tabla TV_D_CAMPO
-- =============================================
CREATE PROCEDURE SPS_TV_D_CAMPO
    @ID_CAMPO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_CAMPO
    ,NOMBRE_CAMPO
    ,ETIQUETA
    ,ID_TIPO_DATO
    ,TAMAÑO
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM TV_D_CAMPO
  WHERE
    ID_CAMPO = @ID_CAMPO
  SET NOCOUNT OFF
END
