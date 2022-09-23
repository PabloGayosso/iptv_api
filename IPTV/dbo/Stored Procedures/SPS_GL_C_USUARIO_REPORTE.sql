
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_C_USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_USUARIO_REPORTE]	
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      U.ID_USUARIO
      ,U.ID_PERSONA
      ,U.ID_SUCURSAL
      ,U.CLAVE_USUARIO
      ,U.CONTRASENA
      ,U.ID_PERFIL
      ,U.ID_ESTATUS
      ,U.FEC_ALTA
      ,U.FEC_MOD
      ,U.USUARIO
	  ,P.NOMBRE
	  ,P.APELLIDO_PATERNO
	  ,P.APELLIDO_MATERNO
	  ,PA.CLAVE AS Estatus
	  ,PE.DESCRIPCION AS Perfil
    FROM GL_C_USUARIO  U 
	LEFT JOIN GL_D_PERSONA  P ON U.ID_PERSONA = P.ID_PERSONA
	LEFT JOIN GL_C_PARAMETRO  PA ON U.ID_ESTATUS = PA.ID_PARAMETRO 
	LEFT JOIN GL_C_PERFIL PE ON PE.ID_PERFIL = U.ID_PERFIL
	ORDER BY U.ID_USUARIO
  SET NOCOUNT OFF
END

