
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_CANAL
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_R_CANAL_CONTENIDO_DIRECTO]
    @ID_CANAL_CONTENIDO INT
    ,@ID_CONTENIDO INT
    ,@USUARIO VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
 UPDATE TV_R_CANAL_CONTENIDO SET
    ID_CONTENIDO  =@ID_CONTENIDO
    ,FEC_MOD = GETDATE()
    ,USUARIO =@USUARIO
WHERE ID_CANAL_CONTENIDO = @ID_CANAL_CONTENIDO
  SET NOCOUNT OFF
END

