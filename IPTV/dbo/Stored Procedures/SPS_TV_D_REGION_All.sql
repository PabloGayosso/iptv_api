﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona todos los registros de la tabla TV_D_REGION
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_REGION_All]
AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_REGION
    ,ID_TEMPLATE
    ,ALTO
    ,ANCHO
    ,DESC_REGION
    ,FEC_ALTA
    ,FEC_MOD
    ,POSICION_X
    ,POSICION_Y
    ,USUARIO
    ,ID_ESTATUS
  FROM TV_D_REGION
  SET NOCOUNT OFF
END

