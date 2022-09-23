
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_C_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].SPS_TV_C_REPRODUCTOR_CATALOGO
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_REPRODUCTOR
    ,DESCRIPCION
  FROM TV_C_REPRODUCTOR
  	WHERE ID_ESTATUS=3
  
  SET NOCOUNT OFF
END

