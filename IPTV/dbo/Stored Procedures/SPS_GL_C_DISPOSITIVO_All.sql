
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_DISPOSITIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_DISPOSITIVO_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_DISPOSITIVO
      ,NOMBRE
      ,CLAVE
      ,IP
      ,MAC_ADDRESS
      ,DESCRIPCION
      ,ID_TIPO_DISPOSITIVO
      ,PUERTO
      ,VISITA
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_DISPOSITIVO
  SET NOCOUNT OFF
END

