
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_REPOSITORIO_CONTENIDO]
  @ID_TIPO_CONTENIDO INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_REPOSITORIO
    ,DESCRIPCION
    ,RUTA_ALOJAMIENTO
    ,EXTENSION
    ,DURACION
    ,ID_ESTATUS
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
    ,ID_TIPO_CONTENIDO
  FROM TV_D_REPOSITORIO
  WHERE
    ID_TIPO_CONTENIDO = @ID_TIPO_CONTENIDO
    AND ID_ESTATUS = 3
  ORDER BY DESCRIPCION
  SET NOCOUNT OFF
END

