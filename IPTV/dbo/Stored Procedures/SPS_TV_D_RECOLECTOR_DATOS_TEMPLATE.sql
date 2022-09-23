﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_D_RECOLECTOR_DATOS
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_RECOLECTOR_DATOS_TEMPLATE]
    @ID_TEMPLATE INT
  AS
BEGIN
  SET NOCOUNT ON
SELECT 
    ID_RECOLECTOR
    ,ID_TEMPLATE
    ,ARCHIVO_XML
    ,FEC_ALTA
    ,FEC_MOD
    ,ID_ESTATUS
    ,USUARIO
  FROM TV_D_RECOLECTOR_DATOS
  WHERE
    ID_TEMPLATE = @ID_TEMPLATE
  SET NOCOUNT OFF
END

