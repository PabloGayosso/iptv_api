
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_CAMPO
-- =============================================
CREATE PROCEDURE SPU_TV_D_CAMPO
    @ID_CAMPO INT
    ,@NOMBRE_CAMPO NVARCHAR(255)
    ,@ETIQUETA NVARCHAR(255)
    ,@ID_TIPO_DATO INT
    ,@TAMAÑO INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO NVARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_D_CAMPO SET
    NOMBRE_CAMPO = @NOMBRE_CAMPO
    ,ETIQUETA = @ETIQUETA
    ,ID_TIPO_DATO = @ID_TIPO_DATO
    ,TAMAÑO = @TAMAÑO
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,USUARIO = @USUARIO
  WHERE
    ID_CAMPO = @ID_CAMPO
  SET NOCOUNT OFF
END
