-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  19/09/2018
-- Description:  Inserta registro en la tabla TV_R_CANAL_CONTENIDO
-- =============================================
CREATE PROCEDURE SPI_TV_R_CANAL_CONTENIDO
    @ID_CANAL INT
    ,@ID_CONTENIDO INT
    ,@ORDEN INT
    ,@FEC_INICIO DATETIME2
    ,@FEC_FIN DATETIME2
    ,@INICIO_HRS INT
    ,@INICIO_MIN INT
    ,@INICIO_SEG INT
    ,@FIN_HRS INT
    ,@FIN_MIN INT
    ,@FIN_SEG INT 
    ,@ID_ESTATUS INT
    --,@FEC_ALTA DATETIME2
    --,@FEC_MOD DATETIME2
    ,@USUARIO VARCHAR(30)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO TV_R_CANAL_CONTENIDO
  (
    ID_CANAL
    ,ID_CONTENIDO
    ,ORDEN
    ,FEC_INICIO
    ,FEC_FIN
    ,INICIO_HRS
    ,INICIO_MIN
    ,INICIO_SEG
    ,FIN_HRS
    ,FIN_MIN
    ,FIN_SEG
    ,ID_ESTATUS
    ,FEC_ALTA
    --,FEC_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_CANAL
    ,@ID_CONTENIDO
    ,@ORDEN
    ,@FEC_INICIO
    ,@FEC_FIN
    ,@INICIO_HRS
    ,@INICIO_MIN
    ,@INICIO_SEG
    ,@FIN_HRS
    ,@FIN_MIN
    ,@FIN_SEG
    ,@ID_ESTATUS
    ,GETDATE()
    --,@FEC_MOD
    ,@USUARIO
  )
  SELECT @@IDENTITY
  SET NOCOUNT OFF
END
