-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Inserta registro en la tabla TV_C_BITACORA_MOVIMIENTOS
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_C_BITACORA_MOVIMIENTOS]
    @ID_BITACORA INT
    ,@ID_REPRODUCTOR INT
    ,@ID_TEMPLATE INT
    ,@ID_REGION INT
    ,@ID_CANAL INT
    ,@ID_CONTENIDO INT
    ,@ID_ESTATUS INT
    ,@DESCRIPCION VARCHAR(MAX)
    ,@ID_USUARIO INT
    ,@FEC_ALTA DATETIME
    ,@OPERACION VARCHAR(50)
    ,@TABLA VARCHAR(50)
    ,@IP_MODIFICO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_C_BITACORA_MOVIMIENTOS
    (
      ID_BITACORA
      ,ID_REPRODUCTOR
      ,ID_TEMPLATE
      ,ID_REGION
      ,ID_CANAL
      ,ID_CONTENIDO
      ,ID_ESTATUS
      ,DESCRIPCION
      ,ID_USUARIO
      ,FEC_ALTA
      ,OPERACION
      ,TABLA
      ,IP_MODIFICO
    )
  VALUES
  (
    @ID_BITACORA
    ,@ID_REPRODUCTOR
    ,@ID_TEMPLATE
    ,@ID_REGION
    ,@ID_CANAL
    ,@ID_CONTENIDO
    ,@ID_ESTATUS
    ,@DESCRIPCION
    ,@ID_USUARIO
    ,@FEC_ALTA
    ,@OPERACION
    ,@TABLA
    ,@IP_MODIFICO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END

