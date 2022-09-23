
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_C_MENSAJES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_MENSAJES_All]
                      @Busqueda NVARCHAR(150),
	@Pagina INT,
	@RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_MENSAJE
    ,NOMBRE
    ,DESCRIPCION
    ,FEC_ALTA
    ,FEC_MOD
    ,ID_ESTATUS
    ,USUARIO
    FROM TV_C_MENSAJES 
    WHERE (
      NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN NOMBRE ELSE '%' + @Busqueda +'%' END
      )
    ORDER BY ID_MENSAJE DESC
    OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

