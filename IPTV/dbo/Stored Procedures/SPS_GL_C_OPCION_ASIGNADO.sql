
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_OPCION
-- =============================================
CREATE PROCEDURE SPS_GL_C_OPCION_ASIGNADO
  @ID_PERFIL INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    TA.ID_OPCION
    ,TA.ID_SUCURSAL
    ,TA.NOMBRE
    ,TA.DESCRIPCION
    ,TA.URL_ICON
    ,TA.URL
    ,TA.ID_ESTATUS
    ,TA.OPCION_PADRE
    ,TA.NIVEL
    ,TA.ORDEN
    ,TA.FEC_MOD
    ,TA.FEC_ALTA
    ,TA.USUARIO
  FROM GL_C_OPCION TA
  WHERE
    TA.ID_OPCION IN (
      SELECT TB.ID_OPCION
      FROM GL_R_PERFIL_OPCION TB
      WHERE
        TB.ID_PERFIL = @ID_PERFIL
    )
  SET NOCOUNT OFF
END

