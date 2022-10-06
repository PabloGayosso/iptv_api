USE [IPTV]
GO

-- =============================================
-- Author:		<Alberto Cruz>
-- Create date: <06/10/2022>
-- Description:	<selecciona un campo especifico de la tabla TV_D_CONTENIDO>
-- =============================================

CREATE PROCEDURE [dbo].[SPS_TV_D_CONTENIDO_RUTA_GUID]
 @RUTA_GUID VARCHAR(500)
  AS
BEGIN
  SET NOCOUNT ON
  SELECT NOMBRE
  FROM [IPTV].[dbo].[TV_D_CONTENIDO]
  WHERE RUTA like '%'+ @RUTA_GUID +'%'
  SET NOCOUNT OFF
END
GO