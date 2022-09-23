
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_TEMPLATES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_ENVIOS_H_ALL]
	@Pagina INT,
    @RegistrosPorPagina INT,
	@Fec_Ini DATETIME,
	@Fec_Fin DATETIME
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_ENVIO
      ,NOMBRE_CONTENIDO
      ,REPRODUCTOR
      ,USUARIO
      ,FEC_ENVIO
      ,FEC_ALTA
	  ,ESTATUS
        FROM TV_D_ENVIO_HISTORICO
        WHERE FEC_ALTA >= @Fec_Ini+'00:00:00:000' AND FEC_ALTA < @Fec_Fin+'23:23:59'
      ORDER BY  FEC_ALTA DESC
      OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
      FETCH NEXT @RegistrosPorPagina ROWS ONLY 
  SET NOCOUNT OFF
END
