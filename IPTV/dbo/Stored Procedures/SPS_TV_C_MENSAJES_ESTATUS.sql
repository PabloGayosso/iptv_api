
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla TV_C_MENSAJES
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_MENSAJES_ESTATUS]
    @ID_ESTATUS INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
    ID_MENSAJE
    ,NOMBRE
    ,DESCRIPCION
    ,FEC_ALTA
    ,FEC_MOD
    ,ID_ESTATUS
    ,USUARIO
  FROM TV_C_MENSAJES
    WHERE
      ID_ESTATUS = @ID_ESTATUS
  SET NOCOUNT OFF
END

