-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 02/04/2020
-- Description:	Buscar registro por ID_MENSAJE
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO]
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT,
	@ID_REPRODUCTOR INT,
	@ID_MENSAJE INT,
	@ID_ESTATUS INT,
	@USUARIO NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
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

	--INSERT INTO TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
	--(
	--ID_MENSAJE,
	--ID_GRUPO,
	--ID_REPRODUCTOR,
	--ID_ESTATUS,
	--USUARIO,
	--FECHA_ALTA
	--) VALUES
	--(
	--@ID_MENSAJE,
	--@ID_GRUPO,
	--@ID_REPRODUCTOR,
	--@ID_ESTATUS,
	--@USUARIO,
	--GETDATE()
	--)
	SELECT @@IDENTITY
	SET NOCOUNT OFF
END
