
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_OPCION_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_OPCION
      ,ID_SUCURSAL
      ,NOMBRE
      ,DESCRIPCION
      ,URL_ICON
      ,URL
      ,ID_ESTATUS
      ,OPCION_PADRE
      ,NIVEL
      ,ORDEN
      ,FEC_MOD
      ,FEC_ALTA
      ,USUARIO
    FROM GL_C_OPCION
  SET NOCOUNT OFF
END

