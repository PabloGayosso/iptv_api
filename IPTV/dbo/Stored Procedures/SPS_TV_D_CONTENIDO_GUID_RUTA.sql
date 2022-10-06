-- =============================================
-- Author:		Luis Fernando Angeles Escamilla
-- Create date: 2020-04-16
-- Description:	Store Procedure que consulta el stream de video dado por un reproductor
-- =============================================
CREATE PROCEDURE SPS_TV_D_CONTENIDO_GUID_RUTA
	 @RUTA_GUID VARCHAR(150)
  AS
BEGIN
  SET NOCOUNT ON
  SELECT NOMBRE
  FROM TV_D_CONTENIDO
  WHERE RUTA like '%'+ @RUTA_GUID +'%'
  SET NOCOUNT OFF
END
GO