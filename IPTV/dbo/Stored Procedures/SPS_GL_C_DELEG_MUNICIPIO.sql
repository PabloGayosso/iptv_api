-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_DELEG_MUNICIPIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_DELEG_MUNICIPIO]
    @ID_DELEG_MUNICIPIO INT
    ,@ID_ESTADO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_DELEG_MUNICIPIO
      ,ID_ESTADO
      ,DSC_DELEG_MUNICIPIO
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_DELEG_MUNICIPIO
    WHERE
      ID_DELEG_MUNICIPIO = @ID_DELEG_MUNICIPIO AND
      ID_ESTADO = @ID_ESTADO
  SET NOCOUNT OFF
END

