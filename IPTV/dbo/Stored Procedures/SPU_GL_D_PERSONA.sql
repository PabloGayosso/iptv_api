﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_PERSONA
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_PERSONA]
    @ID_PERSONA INT
    ,@CLAVE VARCHAR(50)
    ,@NOMBRE VARCHAR(100)
    ,@APELLIDO_PATERNO VARCHAR(100)
    ,@APELLIDO_MATERNO VARCHAR(100)
    ,@ID_ESTATUS INT
    --,@ID_PAIS INT
    --,@FECHA_NACIMIENTO DATETIME
    --,@ID_GENERO INT
    --,@ID_ESTADO_CIVIL INT
    --,@ID_ESCOLARIDAD INT
    --,@OCUPACION NVARCHAR(100)
    --,@RELIGION NVARCHAR(100)
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_PERSONA SET
    CLAVE = @CLAVE
    ,NOMBRE = @NOMBRE
    ,APELLIDO_PATERNO = @APELLIDO_PATERNO
    ,APELLIDO_MATERNO = @APELLIDO_MATERNO
    ,ID_ESTATUS = @ID_ESTATUS
    --,ID_PAIS = @ID_PAIS
    --,FECHA_NACIMIENTO = @FECHA_NACIMIENTO
    --,ID_GENERO = @ID_GENERO
    --,ID_ESTADO_CIVIL = @ID_ESTADO_CIVIL
    --,ID_ESCOLARIDAD = @ID_ESCOLARIDAD
    --,OCUPACION = @OCUPACION
    --,RELIGION = @RELIGION
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()--@FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_PERSONA = @ID_PERSONA
  SET NOCOUNT OFF
END

