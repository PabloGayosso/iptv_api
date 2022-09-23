
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_RECOLECTOR_DATOS
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_RECOLECTOR_DATOS_REPRO]
    @ID_REPRODUCTOR INT
    ,@ID_RECOLECTOR INT
    ,@ID_TEMPLATE INT
    ,@ARCHIVO_XML TEXT
    ,@ACTUALIZACION INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@ID_ESTATUS INT
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_D_RECOLECTOR_DATOS SET
    ID_TEMPLATE = @ID_TEMPLATE
    ,ARCHIVO_XML = @ARCHIVO_XML
    --,FEC_ALTA = @FEC_ALTA
    ,ACTUALIZACION = @ACTUALIZACION
    ,FEC_MOD = GETDATE()
    ,ID_ESTATUS = @ID_ESTATUS
    ,USUARIO = @USUARIO
  WHERE
      ID_RECOLECTOR = @ID_RECOLECTOR

  UPDATE TV_C_REPRODUCTOR SET
    ACTUALIZACION = 1
  WHERE
    ID_REPRODUCTOR = @ID_REPRODUCTOR

  SET NOCOUNT OFF
END

