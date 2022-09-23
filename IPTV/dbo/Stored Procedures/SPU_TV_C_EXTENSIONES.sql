
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_C_EXTENSIONES
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_C_EXTENSIONES]
    @ID_EXTENSION INT
    ,@ID_TIPO_REPRODUCCION INT
    ,@DESCRIPCION VARCHAR(10)
    ,@ACTIVO BIT
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_C_EXTENSIONES SET
    ID_TIPO_REPRODUCCION = @ID_TIPO_REPRODUCCION
    ,DESCRIPCION = @DESCRIPCION
    ,ACTIVO = @ACTIVO
  WHERE
      ID_EXTENSION = @ID_EXTENSION
  SET NOCOUNT OFF
END

