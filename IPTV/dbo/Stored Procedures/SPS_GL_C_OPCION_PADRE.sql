
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_OPCION_PADRE]
  @ID_PERFIL INT
  ,@OPCION_PADRE INT
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
  LEFT JOIN GL_R_PERFIL_OPCION TB ON TB.ID_OPCION = TA.ID_OPCION
  WHERE
    TB.ID_PERFIL = @ID_PERFIL
    AND TA.OPCION_PADRE = @OPCION_PADRE
    AND TA.ID_ESTATUS = 3
  ORDER BY ORDEN
  SET NOCOUNT OFF
END

