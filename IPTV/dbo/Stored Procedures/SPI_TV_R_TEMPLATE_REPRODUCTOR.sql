-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  27/09/2018
-- Description:  Inserta registro en la tabla TV_R_TEMPLATE_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_R_TEMPLATE_REPRODUCTOR]
  @ID_REPRODUCTOR INT
  ,@ID_TEMPLATE INT
  ,@ID_ESTATUS INT
  --,@FECHA_ALTA DATETIME2
  --,@FECHA_MOD DATETIME2
  ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_R_TEMPLATE_REPRODUCTOR
  (
    ID_REPRODUCTOR
    ,ID_TEMPLATE
    ,ID_ESTATUS
    ,FECHA_ALTA
    --,FECHA_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_REPRODUCTOR
    ,@ID_TEMPLATE
    ,@ID_ESTATUS
    ,GETDATE()
    --,@FECHA_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY

  UPDATE TV_C_REPRODUCTOR SET
    ACTUALIZACION = 1
  WHERE
    ID_REPRODUCTOR = @ID_REPRODUCTOR

  SET NOCOUNT OFF
END
