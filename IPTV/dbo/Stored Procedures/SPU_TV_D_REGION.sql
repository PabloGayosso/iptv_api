
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_REGION
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_REGION]
     @ID_REGION INT
    ,@ID_TEMPLATE INT
    ,@ID_ESTATUS INT
    ,@DESC_REGION VARCHAR(50)
    ,@ALTO INT
    ,@ANCHO INT
    ,@POSICION_X INT
    ,@POSICION_Y INT
    ,@CANTIDAD_CANALES INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
   UPDATE TV_D_REGION SET
    ID_TEMPLATE = @ID_TEMPLATE
    ,ID_ESTATUS = @ID_ESTATUS
    ,DESC_REGION = @DESC_REGION
    ,ALTO = @ALTO
    ,ANCHO = @ANCHO
    ,POSICION_X = @POSICION_X
    ,POSICION_Y = @POSICION_Y
    ,CANTIDAD_CANALES = @CANTIDAD_CANALES
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
      ID_REGION = @ID_REGION
  SET NOCOUNT OFF
END

