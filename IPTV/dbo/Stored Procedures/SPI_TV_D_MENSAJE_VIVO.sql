

-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  31/03/2020
-- Description:  Inserta registro en la tabla TV_D_MENSAJE_VIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_MENSAJE_VIVO]
    @ID_ESTATUS INT
    ,@DSC_MENSAJE TEXT
    ,@ES_REPETITIVO BIT
    ,@TIEMPO_REPETICION TIME
    --,@FECHA_ALTA DATETIME
    --,@FECHA_MOD DATETIME
    ,@USUARIO NVARCHAR(100)
    ,@ID_GRUPO INT
    ,@ID_REPRODUCTOR INT
AS
BEGIN
  SET NOCOUNT ON

  DECLARE @ID_MENSAJE INT

  INSERT INTO TV_D_MENSAJE_VIVO
  (
    ID_ESTATUS
    ,DSC_MENSAJE
    ,ES_REPETITIVO
    ,TIEMPO_REPETICION
    ,FECHA_ALTA
    --,FECHA_MOD
    ,USUARIO
  )
  VALUES
  (
    @ID_ESTATUS
    ,@DSC_MENSAJE
    ,@ES_REPETITIVO
    ,@TIEMPO_REPETICION
    ,GETDATE()
    --,@FECHA_MOD
    ,@USUARIO
  )
  SELECT @ID_MENSAJE = @@IDENTITY

  IF(@ID_GRUPO <> 0)
  BEGIN
    INSERT INTO TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO(
      ID_GRUPO
      ,ID_REPRODUCTOR
      ,ID_MENSAJE
      ,ID_ESTATUS
      ,FECHA_ALTA
      --,FECHA_MOD
      ,USUARIO
    )
    SELECT 
      ID_GRUPO
      ,ID_REPRODUCTOR
      ,@ID_MENSAJE
      ,@ID_ESTATUS
      ,GETDATE()
      --,
      ,@USUARIO
    FROM TV_R_GRUPO_REPRODUCTOR
    WHERE 
      ID_GRUPO = @ID_GRUPO
  END
  ELSE
  BEGIN
    INSERT INTO TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO(
      ID_REPRODUCTOR
      ,ID_MENSAJE
      ,ID_ESTATUS
      ,FECHA_ALTA
      --,FECHA_MOD
      ,USUARIO
    )
    VALUES(
      @ID_REPRODUCTOR
      ,@ID_MENSAJE
      ,@ID_ESTATUS
      ,GETDATE()
      --,@FECHA_MOD
      ,@USUARIO
    )
  END


  SET NOCOUNT OFF
END
