
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_PERFIL
-- =============================================
CREATE PROCEDURE SPS_GL_C_PERFIL_ESTATUS
    @ID_ESTATUS INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_PERFIL
    ,NOMBRE
    ,DESCRIPCION
    ,ID_ESTATUS
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM GL_C_PERFIL
  WHERE
    ID_ESTATUS = @ID_ESTATUS
  SET NOCOUNT OFF
END

