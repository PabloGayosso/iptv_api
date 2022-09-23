
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_PERSONA
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_PERSONA_USUARIO_All]
	@Busqueda NVARCHAR(150),
                      @Pagina INT,
	@RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT
    P.ID_PERSONA
    ,P.CLAVE
    ,P.NOMBRE
    ,P.APELLIDO_PATERNO
    ,P.APELLIDO_MATERNO
    ,P.ID_ESTATUS
	,P.USUARIO
    ,U.CLAVE_USUARIO
	,U.CONTRASENA
	,U.ID_PERFIL
  FROM GL_D_PERSONA AS P
  LEFT JOIN GL_C_USUARIO AS U
  ON P.ID_PERSONA = U.ID_PERSONA
 WHERE (
    P.NOMBRE LIKE CASE WHEN @Busqueda = '0' THEN P.NOMBRE ELSE '%' + @Busqueda +'%' END
    OR P.CLAVE LIKE CASE WHEN @Busqueda = '0' THEN P.CLAVE ELSE '%' + @Busqueda +'%' END
    OR P.APELLIDO_PATERNO LIKE CASE WHEN @Busqueda = '0' THEN P.APELLIDO_PATERNO ELSE '%' + @Busqueda +'%' END
    OR U.CLAVE_USUARIO LIKE CASE WHEN @Busqueda = '0' THEN U.CLAVE_USUARIO ELSE '%' + @Busqueda +'%' END
    )
  ORDER BY P.ID_PERSONA DESC
	OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

