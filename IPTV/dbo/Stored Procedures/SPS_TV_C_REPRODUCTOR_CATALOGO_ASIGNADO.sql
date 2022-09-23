
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_C_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].SPS_TV_C_REPRODUCTOR_CATALOGO_ASIGNADO
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    R.ID_REPRODUCTOR
    ,R.DESCRIPCION
	,R.IP_CLIENTE
  FROM TV_C_REPRODUCTOR R
  WHERE R.ID_ESTATUS = 3 AND R.ID_REPRODUCTOR NOT IN (SELECT GR.ID_REPRODUCTOR
								 FROM TV_R_GRUPO_REPRODUCTOR GR)
  
  SET NOCOUNT OFF
END

