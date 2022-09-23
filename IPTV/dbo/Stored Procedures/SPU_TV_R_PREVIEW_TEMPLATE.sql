-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  20/01/2021
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_R_PREVIEW_TEMPLATE
-- =============================================
CREATE PROCEDURE SPU_TV_R_PREVIEW_TEMPLATE
    @ID_PREVIEW INT
    ,@ID_TEMPLATE INT
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_R_PREVIEW_TEMPLATE SET
    ID_TEMPLATE = @ID_TEMPLATE
  WHERE
    ID_PREVIEW = @ID_PREVIEW
  SET NOCOUNT OFF
END
GO