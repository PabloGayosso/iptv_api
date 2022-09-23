
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_REPOSITORIO]
    @ID_REPOSITORIO INT
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
      ID_REPOSITORIO = @ID_REPOSITORIO
  SET NOCOUNT OFF
END

