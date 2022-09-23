﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_ESTACION_TRABAJO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_ESTACION_TRABAJO]
    @ID_ESTACION_TRABAJO INT
    ,@ID_SUCURSAL INT
    ,@CLAVE VARCHAR(150)
    ,@NOMBRE VARCHAR(250)
    ,@DIRECCION_IP VARCHAR(50)
    ,@DIRECCION_MAC VARCHAR(50)
    ,@ID_ESTATUS INT
    ,@ES_SERVIDOR BIT
    ,@ID_PERSONA INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_ESTACION_TRABAJO SET
    ID_SUCURSAL = @ID_SUCURSAL
    ,CLAVE = @CLAVE
    ,NOMBRE = @NOMBRE
    ,DIRECCION_IP = @DIRECCION_IP
    ,DIRECCION_MAC = @DIRECCION_MAC
    ,ID_ESTATUS = @ID_ESTATUS
    ,ES_SERVIDOR = @ES_SERVIDOR
    ,ID_PERSONA = @ID_PERSONA
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_ESTACION_TRABAJO = @ID_ESTACION_TRABAJO
  SET NOCOUNT OFF
END

