﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_LICENCIAMIENTO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_LICENCIAMIENTO]
    @ID_LICENCIAMIENTO INT
    ,@ID_ENTIDAD INT
    ,@ID_SUCURSAL INT
    ,@ID_APLICACION_IST INT
    ,@FECHA_ACTIVACION DATETIME
    ,@VIGENCIA INT
    ,@CONCURRENCIA INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_LICENCIAMIENTO SET
    ID_ENTIDAD = @ID_ENTIDAD
    ,ID_SUCURSAL = @ID_SUCURSAL
    ,ID_APLICACION_IST = @ID_APLICACION_IST
    ,FECHA_ACTIVACION = @FECHA_ACTIVACION
    ,VIGENCIA = @VIGENCIA
    ,CONCURRENCIA = @CONCURRENCIA
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_LICENCIAMIENTO = @ID_LICENCIAMIENTO
  SET NOCOUNT OFF
END

