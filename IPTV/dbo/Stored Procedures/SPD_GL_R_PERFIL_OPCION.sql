
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  16/08/2018
-- Description:  Elimina un registro en especifico de la tabla GL_R_PERFIL_OPCION
-- =============================================
CREATE PROCEDURE [dbo].[SPD_GL_R_PERFIL_OPCION]
   @ID_PERFIL INT
AS
BEGIN
  SET NOCOUNT ON
  DELETE FROM GL_R_PERFIL_OPCION
  WHERE
     ID_PERFIL =  @ID_PERFIL
  SET NOCOUNT OFF
END

