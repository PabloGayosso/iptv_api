-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 19-03-2020
-- Description: PR Alta Grupo
-- =============================================
CREATE PROCEDURE [dbo].[SPI_TV_D_GRUPOS] 
	-- Add the parameters for the stored procedure here
	@NOMBRE NVARCHAR(30),
	@DESCRIPCION TEXT,
	@CANTIDAD_REPRODUCTORES INT,
	@ID_ESTATUS INT,
	@USUARIO NVARCHAR(30),
	@ID_TEMPLATE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO TV_D_GRUPOS
	(
		NOMBRE,
		DESCRIPCION,
		CANTIDAD_REPRODUCTORES,
		ID_ESTATUS,
		FECHA_ALTA,
		USUARIO,
		ID_TEMPLATE
	)
	VALUES (
		@NOMBRE,
		@DESCRIPCION,
		@CANTIDAD_REPRODUCTORES,
		@ID_ESTATUS,
		GETDATE(),
		@USUARIO,
		@ID_TEMPLATE
	)

	 SELECT @@IDENTITY
  SET NOCOUNT OFF
END
