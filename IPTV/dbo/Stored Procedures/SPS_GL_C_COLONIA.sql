-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_COLONIA
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_COLONIA]
    @ID_COLONIA INT
    ,@ID_DELEG_MUNICIPIO INT
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
      ID_COLONIA = @ID_COLONIA AND
      ID_DELEG_MUNICIPIO = @ID_DELEG_MUNICIPIO AND
      ID_ESTADO = @ID_ESTADO
  SET NOCOUNT OFF
END

