
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_R_TABLA_CAMPO
-- =============================================
CREATE PROCEDURE SPU_TV_R_TABLA_CAMPO
    @ID_TABLA_CAMPO INT
    ,@ID_TABLA INT
    ,@ID_CAMPO INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO NVARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_R_TABLA_CAMPO SET
    ID_TABLA = @ID_TABLA
    ,ID_CAMPO = @ID_CAMPO
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
    ID_TABLA_CAMPO = @ID_TABLA_CAMPO
  SET NOCOUNT OFF
END
