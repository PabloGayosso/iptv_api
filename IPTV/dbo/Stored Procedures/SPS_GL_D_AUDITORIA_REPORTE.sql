﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla GL_D_AUDITORIA
-- =============================================
CREATE PROCEDURE SPS_GL_D_AUDITORIA_REPORTE
   @FECHA_INIO DATETIME
   ,@FECHA_FINAL DATETIME
   ,@Pagina INT
   ,@RegistrosPorPagina INT
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    A.ID_AUDITORIA
    ,A.DSC_AUDITORIA
    ,A.ID_USUARIO
    ,A.FCH_ACCION
    ,A.DSC_ACCION
    ,A.FEC_ALTA
    ,A.FEC_MOD
    ,A.USUARIO
    ,A.ID_APLICACION
    ,A.ID_SUCURSAL
	,U.CLAVE_USUARIO
	,S.CLAVE
	,P.NOMBRE
	,P.APELLIDO_PATERNO
	,P.APELLIDO_MATERNO
  FROM GL_D_AUDITORIA AS A
    Left Join GL_C_USUARIO AS U ON U.ID_USUARIO=A.ID_USUARIO
	Left Join GL_C_SUCURSAL AS S ON S.ID_SUCURSAL =A.ID_SUCURSAL
	Left Join GL_D_PERSONA AS P ON P.ID_PERSONA =U.ID_PERSONA
  WHERE
    A.FCH_ACCION >= @FECHA_INIO AND A.FCH_ACCION < @FECHA_FINAL
	ORDER BY A.FEC_ALTA DESC
	OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
    FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END

