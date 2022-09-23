
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_REPOSITORIO_All]
                      @Busqueda NVARCHAR(150),
                      @ID_TIPO_CONTENIDO INT,
	@Pagina INT,
	@RegistrosPorPagina INT 
AS
BEGIN
  SET NOCOUNT ON
    SELECT r.*,
    CAST(
         CASE
         WHEN c.ID_CONTENIDO IS NOT NULL
            THEN 1
         ELSE 0
         END AS bit) as enUso
    FROM TV_D_REPOSITORIO r
    LEFT JOIN TV_D_CONTENIDO c
    ON r.ID_REPOSITORIO = c.ID_REPOSITORIO
    WHERE(
    r.RUTA_ALOJAMIENTO LIKE CASE WHEN @Busqueda = '0' THEN r.RUTA_ALOJAMIENTO ELSE '%' + @Busqueda +'%' END
    AND r.ID_TIPO_CONTENIDO = CASE WHEN @ID_TIPO_CONTENIDO = 0 THEN r.ID_TIPO_CONTENIDO ELSE  @ID_TIPO_CONTENIDO END)
  ORDER BY r.ID_REPOSITORIO
  OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
  FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

