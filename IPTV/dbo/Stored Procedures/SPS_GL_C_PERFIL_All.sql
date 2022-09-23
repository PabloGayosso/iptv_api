
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_PERFIL
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_PERFIL_All]
    @Busqueda NVARCHAR(150),
    @Pagina INT,
    @RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_PERFIL
      ,NOMBRE
      ,DESCRIPCION
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_PERFIL 
    WHERE (
    DESCRIPCION LIKE CASE WHEN @Busqueda = '0' THEN DESCRIPCION ELSE '%' + @Busqueda +'%' END
    OR NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN NOMBRE ELSE '%' + @Busqueda +'%' END)
    ORDER BY ID_PERFIL DESC
    OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

