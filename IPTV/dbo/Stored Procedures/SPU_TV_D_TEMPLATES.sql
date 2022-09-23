
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_TEMPLATES]
    @ID_TEMPLATE INT
    ,@ALTO INT
    ,@ANCHO INT
    ,@CANTIDAD_REGIONES INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@NOMBRE VARCHAR(50)
    ,@USUARIO VARCHAR(50)
    ,@ID_ESTATUS INT
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_D_TEMPLATES SET
    ALTO = @ALTO
    ,ANCHO = @ANCHO
    ,CANTIDAD_REGIONES = @CANTIDAD_REGIONES
    --,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = GETDATE()
    ,NOMBRE = @NOMBRE
    ,USUARIO = @USUARIO
    ,ID_ESTATUS = @ID_ESTATUS
  WHERE
      ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END

