
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_TEMPLATES_All]
    @Busqueda NVARCHAR(150),
    @Pagina INT,
    @RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_TEMPLATE
      ,ALTO
      ,ANCHO
      ,CANTIDAD_REGIONES
      ,FEC_ALTA
      ,FEC_MOD
      ,NOMBRE
      ,USUARIO
      ,ID_ESTATUS
        FROM TV_D_TEMPLATES
        WHERE(NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN NOMBRE ELSE '%' + @Busqueda +'%' END)
      ORDER BY  ID_TEMPLATE DESC
      OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
      FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

