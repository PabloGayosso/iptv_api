-- =============================================
-- Author:		Luis Fernando Angeles Escamilla
-- Create date: 2020-04-16
-- Description:	Store Procedure que consulta el stream de video dado por un reproductor
-- =============================================
CREATE PROCEDURE SPS_TV_D_CONTENIDO_REPRODUCTOR
	@ID_REPRODUCTOR INT
AS
BEGIN
	SET NOCOUNT ON;

  SELECT
    TA.ID_REPRODUCTOR
    ,TA.ID_TEMPLATE
    ,TB.ID_CANAL
    ,TC.ID_CONTENIDO
    ,TD.RUTA
  FROM TV_R_TEMPLATE_REPRODUCTOR  TA
  LEFT JOIN TV_R_TEMPLATE_CANAL TB ON TB.ID_TEMPLATE = TA.ID_TEMPLATE
  LEFT JOIN TV_R_CANAL_CONTENIDO TC ON TC.ID_CANAL = TB.ID_CANAL
  LEFT JOIN TV_D_CONTENIDO TD ON TD.ID_CONTENIDO = TC.ID_CONTENIDO
  WHERE
    TD.ID_TIPO_CANAL = 18
    AND TA.ID_REPRODUCTOR = @ID_REPRODUCTOR
END
