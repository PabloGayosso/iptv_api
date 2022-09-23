﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_C_REPRODUCTOR
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_REPRODUCTOR_All]
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
    ,TA.RUTA_REPOSITORIO
    ,TA.ID_ESTATUS
    ,TA.FEC_ALTA
    ,TA.FEC_MOD
    ,TA.USUARIO
    ,TB.ID_TEMPLATE
    ,TA.DIRECCION_MAC
    ,TA.RELOJ
  FROM TV_C_REPRODUCTOR TA
  LEFT JOIN TV_R_TEMPLATE_REPRODUCTOR TB ON TB.ID_REPRODUCTOR = TA.ID_REPRODUCTOR
  SET NOCOUNT OFF
END

