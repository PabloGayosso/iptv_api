
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_D_DIRECCION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_DIRECCION]
    @ID_DIRECCION INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_DIRECCION
      ,ID_TIPO_DIRECCION
      ,ID_PAIS
      ,ID_ESTADO
      ,ID_DELEG_MUNICIPIO
      ,ID_COLONIA
      ,CODIGO_POSTAL
      ,CIUDAD
      ,CALLE
      ,NUMERO_EXTERIOR
      ,NUMERO_INTERIOR
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_DIRECCION
    WHERE
      ID_DIRECCION = @ID_DIRECCION
  SET NOCOUNT OFF
END

