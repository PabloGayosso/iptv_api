
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_USUARIO_All]	
	 @Pagina INT,
	 @RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_USUARIO
      ,ID_PERSONA
      ,ID_SUCURSAL
      ,CLAVE_USUARIO
      ,CONTRASENA
      ,ID_PERFIL
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_USUARIO ORDER BY ID_USUARIO
    OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

