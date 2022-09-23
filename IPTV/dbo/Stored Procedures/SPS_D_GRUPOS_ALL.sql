-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPS_D_GRUPOS_ALL]
                       @Busqueda NVARCHAR(150),
	 @Pagina INT,
	 @RegistrosPorPagina INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT
	G.ID_GRUPO,
	G.NOMBRE,
	G.DESCRIPCION,
	G.CANTIDAD_REPRODUCTORES,
	G.FECHA_ALTA,
	G.FECHA_MOD,
	G.USUARIO,
	G.ID_ESTATUS,
	G.ID_TEMPLATE,
	T.NOMBRE AS TEMPLATE_NOMBRE
	 FROM TV_D_GRUPOS G
	 INNER JOIN TV_D_TEMPLATES T ON G.ID_TEMPLATE = T.ID_TEMPLATE
    	 WHERE(
                        G.NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN G.NOMBRE ELSE '%' + @Busqueda +'%' END AND
                        G.DESCRIPCION LIKE CASE WHEN @Busqueda = '0' THEN G.DESCRIPCION ELSE '%' + @Busqueda +'%' END)
                       ORDER BY ID_GRUPO DESC
  OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
  FETCH NEXT @RegistrosPorPagina ROWS ONLY 
	  SET NOCOUNT OFF
END
