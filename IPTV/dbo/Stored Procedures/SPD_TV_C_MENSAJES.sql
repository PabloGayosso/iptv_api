
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Elimina un registro en especifico de la tabla TV_C_MENSAJES
-- =============================================
CREATE PROCEDURE [dbo].[SPD_TV_C_MENSAJES]
    @ID_MENSAJE INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM  TV_C_MENSAJES
  WHERE ID_MENSAJE = @ID_MENSAJE
  SET NOCOUNT OFF
END

