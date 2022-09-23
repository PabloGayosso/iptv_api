
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_COLONIA
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_COLONIA_All]
  @ID_DELEG_MUNICIPIO INT
  ,@ID_ESTADO INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_COLONIA
    ,ID_DELEG_MUNICIPIO
    ,ID_ESTADO
    ,ID_TIPO_ASENTAMIENTO
    ,CODIGO_POSTAL
    ,DESC_COLONIA
    ,DESC_CIUDAD
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM GL_C_COLONIA
  WHERE
    ID_ESTADO = @ID_ESTADO
    AND ID_DELEG_MUNICIPIO = @ID_DELEG_MUNICIPIO
  ORDER BY DESC_COLONIA
  SET NOCOUNT OFF
END

