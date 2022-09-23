
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_CONTENIDO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_CONTENIDO_All]
    @Busqueda NVARCHAR(150),
    @Filtro INT,
    @Pagina INT,
    @RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
    SELECT C.*, CAST(
         CASE
         WHEN ca.ID_CONTENIDO IS NOT NULL
            THEN 1
         ELSE 0
         END AS bit) as enUso
         ,R.*
         ,TC.RUTA_ALOJAMIENTO AS rutaCatalogo
         , M.*
  FROM TV_D_CONTENIDO C
  LEFT JOIN TV_D_REPOSITORIO R
  ON C.ID_REPOSITORIO = R.ID_REPOSITORIO
  LEFT JOIN TV_C_MENSAJES M
  ON C.ID_MENSAJE = M.ID_MENSAJE
  LEFT JOIN TV_R_CANAL_CONTENIDO ca
  ON ca.ID_CONTENIDO = c.ID_CONTENIDO
 LEFT JOIN TV_C_REPOSITORIO TC
  ON R.RUTA_ALOJAMIENTO = TC.NOMBRE
  WHERE C.ID_CONTENIDO IN (
      SELECT C.ID_CONTENIDO
  FROM TV_D_CONTENIDO C
  LEFT JOIN TV_D_REPOSITORIO R
  ON C.ID_REPOSITORIO = R.ID_REPOSITORIO
  LEFT JOIN TV_C_MENSAJES M
  ON C.ID_MENSAJE = M.ID_MENSAJE
  LEFT JOIN TV_C_REPOSITORIO TC
  ON R.RUTA_ALOJAMIENTO = TC.NOMBRE
  WHERE(
     C.NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN C.NOMBRE ELSE '%' + @Busqueda +'%' END
   AND C.ID_TIPO_CANAL = CASE WHEN @Filtro = 0 THEN C.ID_TIPO_CANAL ELSE  @Filtro  END)
  ORDER BY C.ID_CONTENIDO DESC
  OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
  FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  )
  ORDER BY C.ID_CONTENIDO DESC
  SET NOCOUNT OFF
END

