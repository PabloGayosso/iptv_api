
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_PERSONA
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_PERSONA_All]
	@Pagina INT,
	@RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT
    ID_PERSONA
    ,CLAVE
    ,NOMBRE
    ,APELLIDO_PATERNO
    ,APELLIDO_MATERNO
    ,ID_ESTATUS
    ,ID_PAIS
    ,FECHA_NACIMIENTO
    ,ID_GENERO
    ,ID_ESTADO_CIVIL
    ,ID_ESCOLARIDAD
    ,OCUPACION
    ,RELIGION
    ,FEC_ALTA
    ,FEC_MOD
    ,USUARIO
  FROM GL_D_PERSONA
  ORDER BY ID_PERSONA DESC
	OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

