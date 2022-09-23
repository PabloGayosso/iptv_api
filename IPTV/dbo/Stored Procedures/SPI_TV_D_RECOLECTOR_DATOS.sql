-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_D_RECOLECTOR_DATOS
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_RECOLECTOR_DATOS]
    @ID_TEMPLATE INT
    ,@ARCHIVO_XML TEXT
    ,@ID_ESTATUS INT
    ,@ACTUALIZACION INT
    --,@FEC_ALTA DATETIME
    --,@FEC_MOD DATETIME
    ,@USUARIO NVARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_D_RECOLECTOR_DATOS
  (
    ID_TEMPLATE
    ,ARCHIVO_XML
    ,FEC_ALTA
    ,ACTUALIZACION
    --,FEC_MOD
    ,ID_ESTATUS
    ,USUARIO
  )
  VALUES
  (
    @ID_TEMPLATE
    ,@ARCHIVO_XML
    ,GETDATE()
    ,@ACTUALIZACION
    --,@FEC_MOD
    ,@ID_ESTATUS
    ,@USUARIO

  )
  SELECT @@IDENTITY

  UPDATE TV_C_REPRODUCTOR SET
    ACTUALIZACION = 1
  WHERE
    ID_REPRODUCTOR IN(
      SELECT ID_REPRODUCTOR
      FROM TV_R_TEMPLATE_REPRODUCTOR
      WHERE
        ID_TEMPLATE = @ID_TEMPLATE
    )

  SET NOCOUNT OFF
END

