
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_PERSONA_SUCURSAL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_PERSONA_SUCURSAL_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_PERSONA
      ,ID_SUCURSAL
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_PERSONA_SUCURSAL
  SET NOCOUNT OFF
END

