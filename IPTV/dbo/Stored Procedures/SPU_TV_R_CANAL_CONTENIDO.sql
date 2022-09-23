-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  19/09/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_R_CANAL_CONTENIDO
-- =============================================
CREATE PROCEDURE SPU_TV_R_CANAL_CONTENIDO
    @ID_CANAL INT
    ,@ID_CONTENIDO INT
    ,@ID_CONTENIDO_ANT INT
    ,@ORDEN INT
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_R_CANAL_CONTENIDO SET
    ID_CONTENIDO = @ID_CONTENIDO
    ,ORDEN = @ORDEN
    ,ID_ESTATUS = @ID_ESTATUS
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
      ID_CANAL = @ID_CANAL AND
      ID_CONTENIDO = @ID_CONTENIDO_ANT
  SET NOCOUNT OFF
END
