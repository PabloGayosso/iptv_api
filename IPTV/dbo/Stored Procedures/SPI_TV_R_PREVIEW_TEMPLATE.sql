-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  20/01/2021
-- Description:  Inserta registro en la tabla TV_R_PREVIEW_TEMPLATE
-- =============================================
CREATE PROCEDURE SPI_TV_R_PREVIEW_TEMPLATE
    @ID_TEMPLATE INT
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_R_PREVIEW_TEMPLATE
  (
    ID_TEMPLATE
  )
  VALUES
  (
    @ID_TEMPLATE
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
GO