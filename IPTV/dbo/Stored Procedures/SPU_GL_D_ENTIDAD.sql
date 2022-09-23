
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla GL_D_ENTIDAD
-- =============================================
CREATE PROCEDURE [dbo].[SPU_GL_D_ENTIDAD]
    @ID_ENTIDAD INT
    ,@CLAVE_IS VARCHAR(50)
    ,@RAZON_SOCIAL VARCHAR(250)
    ,@RFC VARCHAR(25)
    ,@ES_GRUPO BIT
    ,@ID_ESTATUS INT
    ,@FEC_ALTA DATETIME
    ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE GL_D_ENTIDAD SET
    CLAVE_IS = @CLAVE_IS
    ,RAZON_SOCIAL = @RAZON_SOCIAL
    ,RFC = @RFC
    ,ES_GRUPO = @ES_GRUPO
    ,ID_ESTATUS = @ID_ESTATUS
    ,FEC_ALTA = @FEC_ALTA
    ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
  WHERE
      ID_ENTIDAD = @ID_ENTIDAD
  SET NOCOUNT OFF
END

