
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  05/09/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_R_PERSONA_DIRECCION
-- =============================================
CREATE PROCEDURE SPS_GL_R_PERSONA_DIRECCION_DIRECCION
    @ID_DIRECCION INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_PERSONA
    ,ID_DIRECCION
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM GL_R_PERSONA_DIRECCION
  WHERE
    ID_DIRECCION = @ID_DIRECCION
  SET NOCOUNT OFF
END
