-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_C_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_REPRODUCTOR_BY_MAC]
    @DIRECCION_MAC VARCHAR(25)
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    TA.ID_REPRODUCTOR
    ,TA.CANTIDAD_VIDEOS
    ,TA.DESCRIPCION
    ,TA.ID_TIPO_DISPOSITIVO
    ,TA.IP_CLIENTE
    ,TA.PUERTO_CLIENTE
    ,TA.ACTUALIZACION
    ,TA.RUTA_REPOSITORIO
    ,TA.ID_ESTATUS
    ,TA.DIRECCION_MAC
    ,TA.FEC_ALTA
    ,TA.FEC_MOD
    ,TA.USUARIO
  FROM TV_C_REPRODUCTOR TA
  WHERE
    TA.DIRECCION_MAC = @DIRECCION_MAC 
    
  SET NOCOUNT OFF
END