
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  29/08/2019
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_CAMPO
-- =============================================
CREATE PROCEDURE SPU_TV_D_ENVIO
    @ID_ENVIO INT,
    @VELOCIDAD VARCHAR(50),
    @PORCENTAJE INT,
    @TAM_DESCARGADO VARCHAR(150)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_D_ENVIO SET
    VELOCIDAD = @VELOCIDAD,
    PORCENTAJE= @PORCENTAJE,
    TAM_DESCARGADO = @TAM_DESCARGADO
  WHERE
    ID_ENVIO = @ID_ENVIO
  SET NOCOUNT OFF
END
