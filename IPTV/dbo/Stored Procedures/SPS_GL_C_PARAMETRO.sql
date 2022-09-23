
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_PARAMETRO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_PARAMETRO]
    @ID_PARAMETRO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_PARAMETRO
      ,PARAMETRO
      ,CONSECUTIVO
      ,CLAVE
      ,DESCRIPCION
      ,PREDETERMINADO
      ,FACTOR
      ,ID_APLICACION_IST
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_PARAMETRO
    WHERE
      ID_PARAMETRO = @ID_PARAMETRO
  SET NOCOUNT OFF
END

