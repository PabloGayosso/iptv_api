
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_DIRECCION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_DIRECCION_PERSONA]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    TA.ID_DIRECCION
    ,TA.ID_TIPO_DIRECCION
    ,TA.ID_PAIS
    ,TA.ID_ESTADO
    ,TA.ID_DELEG_MUNICIPIO
    ,TA.ID_COLONIA
    ,TA.CODIGO_POSTAL
    ,TA.CIUDAD
    ,TA.CALLE
    ,TA.NUMERO_EXTERIOR
    ,TA.NUMERO_INTERIOR
    ,TA.ID_ESTATUS
    ,TA.FEC_ALTA
    ,TA.FEC_MOD
    ,TA.USUARIO
    ,TB.ID_PERSONA
  FROM GL_D_DIRECCION TA
  LEFT JOIN GL_R_PERSONA_DIRECCION TB1 ON TB1.ID_DIRECCION = TA.ID_DIRECCION
  LEFT JOIN GL_D_PERSONA TB ON TB.ID_PERSONA = TB1.ID_PERSONA
  SET NOCOUNT OFF
END

