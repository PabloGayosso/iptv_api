
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_DIRECCION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_D_DIRECCION_All]
	@Pagina INT,
	@RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_DIRECCION
      ,ID_TIPO_DIRECCION
      ,ID_PAIS
      ,ID_ESTADO
      ,ID_DELEG_MUNICIPIO
      ,ID_COLONIA
      ,CODIGO_POSTAL
      ,CIUDAD
      ,CALLE
      ,NUMERO_EXTERIOR
      ,NUMERO_INTERIOR
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_D_DIRECCION ORDER BY ID_DIRECCION
	OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

