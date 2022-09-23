
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_D_GRUPOS
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_REPRODUCTOR_BY_ID_GRUPO]
    @ID_GRUPO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT r.*, rg.*, g.* 
  FROM TV_C_REPRODUCTOR r
  LEFT JOIN TV_R_GRUPO_REPRODUCTOR rg
  ON r.ID_REPRODUCTOR = rg.ID_REPRODUCTOR
  LEFT JOIN TV_D_GRUPOS g
  ON rg.ID_GRUPO = g.ID_GRUPO
  WHERE g.ID_GRUPO =  @ID_GRUPO
    
  SET NOCOUNT OFF
END