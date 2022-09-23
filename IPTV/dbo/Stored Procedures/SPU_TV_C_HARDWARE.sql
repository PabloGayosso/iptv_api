
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_C_HARDWARE
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_C_HARDWARE]
    @ID_HARDWARE INT
    ,@DESCRIPCION VARCHAR(500)
    ,@ID_ESTATUS INT
    ,@DETALLE VARCHAR(1000)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_C_HARDWARE SET
    DESCRIPCION = @DESCRIPCION
    ,ID_ESTATUS = @ID_ESTATUS
    ,DETALLE = @DETALLE
  WHERE
      ID_HARDWARE = @ID_HARDWARE
  SET NOCOUNT OFF
END

