
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_PERFIL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_PERFIL]
    @ID_PERFIL INT
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
      ID_PERFIL = @ID_PERFIL
  SET NOCOUNT OFF
END

