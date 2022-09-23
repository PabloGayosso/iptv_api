
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_D_ENTIDAD
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_ENTIDAD]
    @ID_ENTIDAD INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_ENTIDAD
      ,CLAVE_IS
      ,RAZON_SOCIAL
      ,RFC
      ,ES_GRUPO
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_ENTIDAD
    WHERE
      ID_ENTIDAD = @ID_ENTIDAD
  SET NOCOUNT OFF
END

