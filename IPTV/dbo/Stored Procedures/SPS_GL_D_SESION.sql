
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_D_SESION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_SESION]
    @ID_SESION INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_SESION
      ,ID_ESTACION_TRABAJO
      ,INICIO
      ,ID_ESTATUS
      ,FIN
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_SESION
    WHERE
      ID_SESION = @ID_SESION
  SET NOCOUNT OFF
END

