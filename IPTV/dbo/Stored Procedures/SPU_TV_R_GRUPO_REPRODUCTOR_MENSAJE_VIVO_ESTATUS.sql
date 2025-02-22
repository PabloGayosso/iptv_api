﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  06/04/2020
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO_ESTATUS]
    @ID_GRUPO_REPRODUCTOR_MENSAJE INT
    ,@ID_ESTATUS INT
    ,@USUARIO NVARCHAR(100)

AS
BEGIN
  SET NOCOUNT ON

  UPDATE TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO SET
    ID_ESTATUS = @ID_ESTATUS
    ,FECHA_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
    ID_GRUPO_REPRODUCTOR_MENSAJE = @ID_GRUPO_REPRODUCTOR_MENSAJE

  DECLARE
    @ID_MENSAJE_TRANSMITIDO INT
    ,@MENSAJES_TOTAL INT
    ,@MENSAJE_TRANSMITIDOS INT
  
  SELECT @ID_MENSAJE_TRANSMITIDO = ID_MENSAJE 
  FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
  WHERE
    ID_GRUPO_REPRODUCTOR_MENSAJE = @ID_GRUPO_REPRODUCTOR_MENSAJE

  

  SELECT @MENSAJES_TOTAL = COUNT(ID_MENSAJE) 
  FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
  WHERE
    ID_MENSAJE = @ID_MENSAJE_TRANSMITIDO

  SELECT @MENSAJE_TRANSMITIDOS = COUNT(ID_MENSAJE) 
  FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
  WHERE
    ID_MENSAJE = @ID_MENSAJE_TRANSMITIDO
    AND ID_ESTATUS = 4

 -- SELECT 
 --   @ID_MENSAJE_TRANSMITIDO AS ID_MENSAJE
	--,@MENSAJES_TOTAL AS MENSAJE_TOTAL
	--,@MENSAJE_TRANSMITIDOS AS REPRODUCIDOS

  IF(@MENSAJES_TOTAL = @MENSAJE_TRANSMITIDOS)
  BEGIN
    UPDATE TV_D_MENSAJE_VIVO SET
      ID_ESTATUS = @ID_ESTATUS
      ,FECHA_MOD = GETDATE()
      ,USUARIO = @USUARIO
    WHERE
      ID_MENSAJE = @ID_MENSAJE_TRANSMITIDO
  END

  SET NOCOUNT OFF
END
