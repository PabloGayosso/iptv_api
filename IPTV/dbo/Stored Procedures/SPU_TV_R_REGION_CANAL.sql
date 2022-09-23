
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  24/09/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_R_REGION_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_R_REGION_CANAL]
    @ID_CANAL_REGION INT
    ,@ID_REGION INT
    ,@ID_CANAL INT
    ,@ID_ESTATUS INT
    ,@ALTO INT
    ,@ANCHO INT
    ,@POSICION_X INT
    ,@POSICION_Y INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_R_REGION_CANAL SET
    ID_REGION = @ID_REGION
    ,ID_CANAL = @ID_CANAL
    ,ID_ESTATUS = @ID_ESTATUS
    ,ALTO = @ALTO
    ,ANCHO = @ANCHO
    ,POSICION_X = @POSICION_X
    ,POSICION_Y = @POSICION_Y
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
      ID_CANAL_REGION = @ID_CANAL_REGION
  SET NOCOUNT OFF
END
