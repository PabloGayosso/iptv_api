
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  23/05/2020
-- Description:  Selecciona un registro en especifico de la tabla GL_D_LICENCIA_ACTIVA
-- =============================================
CREATE PROCEDURE SPS_GL_D_LICENCIA_ACTIVA_LICENCIA
    @LICENCIA NVARCHAR(MAX)
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_LICENCIA_ACTIVA
    ,ID_ENTIDAD
    ,ID_SUCURSAL
    ,ID_APLICACION_IST
    ,ID_ESTATUS
    ,LICENCIA
    ,LICENCIA_ACTIVA
    ,MAC_ADDRESS
    ,SERIAL_NUMBER_BASE
    ,SERIAL_NUMBER_BIOS
    ,FECHA_ALTA
    ,FECHA_MOD
    ,USUARIO
  FROM GL_D_LICENCIA_ACTIVA
  WHERE
    LICENCIA = @LICENCIA
  SET NOCOUNT OFF
END
