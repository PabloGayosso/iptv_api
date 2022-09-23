
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_R_TEMPLATE_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_R_TEMPLATE_CANAL]
    @ID_CANAL_TEMPLATE INT
    ,@ID_TEMPLATE INT
    ,@ID_CANAL INT
    ,@ID_ESTATUS INT
    ,@ALTO INT
    ,@ANCHO INT
    ,@POSICION_X INT
    ,@POSICION_Y INT
    ,@ORDEN INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  IF(@ID_CANAL <> 0) 
  BEGIN
    UPDATE TV_R_TEMPLATE_CANAL SET
      ID_TEMPLATE = @ID_TEMPLATE
      ,ID_CANAL = @ID_CANAL
      ,ID_ESTATUS = @ID_ESTATUS
      ,ALTO = @ALTO
      ,ANCHO = @ANCHO
      ,POSICION_X = @POSICION_X
      ,POSICION_Y = @POSICION_Y
      ,ORDEN = @ORDEN
      --,FEC_ALTA = @FEC_ALTA
      ,FEC_MOD = GETDATE()
      ,USUARIO = @USUARIO
    WHERE
      ID_CANAL_TEMPLATE = @ID_CANAL_TEMPLATE
  END
  ELSE
  BEGIN
    UPDATE TV_R_TEMPLATE_CANAL SET
      ID_TEMPLATE = @ID_TEMPLATE
      ,ID_ESTATUS = @ID_ESTATUS
      ,ALTO = @ALTO
      ,ANCHO = @ANCHO
      ,POSICION_X = @POSICION_X
      ,POSICION_Y = @POSICION_Y
      ,ORDEN = @ORDEN
      --,FEC_ALTA = @FEC_ALTA
      ,FEC_MOD = GETDATE()
      ,USUARIO = @USUARIO
    WHERE
      ID_CANAL_TEMPLATE = @ID_CANAL_TEMPLATE
  END
  SET NOCOUNT OFF
END
