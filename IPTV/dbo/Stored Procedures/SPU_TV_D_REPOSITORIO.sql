
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Actualiza los campos de un registro en especifico de la tabla TV_D_REPOSITORIO
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_REPOSITORIO]
    @ID_REPOSITORIO INT
    ,@DESCRIPCION VARCHAR(50)
    ,@RUTA_ALOJAMIENTO VARCHAR(150)
    ,@EXTENSION VARCHAR(10)
    ,@DURACION TIME
    ,@ID_ESTATUS INT
  --  ,@FEC_ALTA DATETIME
  --  ,@FEC_MOD DATETIME
    ,@USUARIO VARCHAR(30)
    ,@ID_TIPO_CONTENIDO INT
AS
BEGIN
  SET NOCOUNT ON
  UPDATE TV_D_REPOSITORIO SET
    DESCRIPCION = @DESCRIPCION
    ,RUTA_ALOJAMIENTO = @RUTA_ALOJAMIENTO
    ,EXTENSION = @EXTENSION
    ,DURACION = @DURACION
    ,ID_ESTATUS = @ID_ESTATUS
  --  ,FEC_ALTA = @FEC_ALTA
  ,FEC_ALTA = GETDATE()
   -- ,FEC_MOD = @FEC_MOD
    ,USUARIO = @USUARIO
    ,ID_TIPO_CONTENIDO = @ID_TIPO_CONTENIDO
  WHERE
      ID_REPOSITORIO = @ID_REPOSITORIO
  SET NOCOUNT OFF
END

