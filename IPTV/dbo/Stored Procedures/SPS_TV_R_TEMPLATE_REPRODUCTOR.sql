
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  27/09/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_R_TEMPLATE_REPRODUCTOR
-- =============================================
CREATE PROCEDURE SPS_TV_R_TEMPLATE_REPRODUCTOR
    @ID_REPRODUCTOR INT
    ,@ID_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_REPRODUCTOR
    ,ID_TEMPLATE
    ,ID_ESTATUS
    ,FECHA_ALTA
    ,FECHA_MOD
    ,USUARIO
  FROM TV_R_TEMPLATE_REPRODUCTOR
  WHERE
    ID_REPRODUCTOR = @ID_REPRODUCTOR AND
    ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END
