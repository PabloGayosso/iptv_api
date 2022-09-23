
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_PARAMETRO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_PARAMETRO_CATALOGO]
  @PARAMETRO INT,
  @Pagina INT,
  @RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_PARAMETRO
    ,PARAMETRO
    ,CONSECUTIVO
    ,CLAVE
    ,DESCRIPCION
    ,PREDETERMINADO
    ,FACTOR
    ,ID_APLICACION_IST
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
	FROM GL_C_PARAMETRO
	WHERE
    PARAMETRO = @PARAMETRO
    AND CONSECUTIVO <> 0
	ORDER BY ID_PARAMETRO
	OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

