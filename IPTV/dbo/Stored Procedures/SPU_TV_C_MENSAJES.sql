
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_C_MENSAJES
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_C_MENSAJES]
    @ID_MENSAJE INT
    ,@NOMBRE NVARCHAR(50)
    ,@DESCRIPCION VARCHAR(MAX)
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@ID_ESTATUS INT
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_C_MENSAJES SET
    NOMBRE = @NOMBRE
    ,DESCRIPCION = @DESCRIPCION
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,ID_ESTATUS = @ID_ESTATUS
    ,USUARIO = @USUARIO
  WHERE
      ID_MENSAJE = @ID_MENSAJE
  SET NOCOUNT OFF
END

