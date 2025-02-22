﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  23/05/2020
-- Description:  Inserta registro en la tabla GL_D_LICENCIA_ACTIVA
-- =============================================
CREATE PROCEDURE SPI_GL_D_LICENCIA_ACTIVA
    @ID_ENTIDAD INT
    ,@ID_SUCURSAL INT
    ,@ID_APLICACION_IST INT
    ,@ID_ESTATUS INT
    ,@LICENCIA NVARCHAR(MAX)
    ,@LICENCIA_ACTIVA NVARCHAR(MAX)
    ,@MAC_ADDRESS NVARCHAR(100)
    ,@SERIAL_NUMBER_BASE NVARCHAR(100)
    ,@SERIAL_NUMBER_BIOS NVARCHAR(100)
    --,@FECHA_ALTA DATETIME
    --,@FECHA_MOD DATETIME
    ,@USUARIO VARCHAR(100)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO GL_D_LICENCIA_ACTIVA
  (
    ID_ENTIDAD
    ,ID_SUCURSAL
    ,ID_APLICACION_IST
    ,ID_ESTATUS
    ,LICENCIA
    ,LICENCIA_ACTIVA
    ,MAC_ADDRESS
    ,SERIAL_NUMBER_BASE
    ,SERIAL_NUMBER_BIOS
    ,FECHA_ALTA
    --,FECHA_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_ENTIDAD
    ,@ID_SUCURSAL
    ,@ID_APLICACION_IST
    ,@ID_ESTATUS
    ,@LICENCIA
    ,@LICENCIA_ACTIVA
    ,@MAC_ADDRESS
    ,@SERIAL_NUMBER_BASE
    ,@SERIAL_NUMBER_BIOS
    ,GETDATE()
    --,@FECHA_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
