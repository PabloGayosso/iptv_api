-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 24/03/2020
-- Description: Metodo para alta de la relacion reproductor - grupo
-- =============================================
CREATE PROCEDURE SPI_TV_R_GRUPOS_REPRODUCTOR
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT,
	@ID_REPRODUCTOR INT,
	@USUARIO NVARCHAR(30),
	@ID_TEMPLATE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	INSERT INTO TV_R_GRUPO_REPRODUCTOR
	(
		ID_GRUPO,
		ID_REPRODUCTOR,
		USAURIO,
		FECHA_ALTA
	) VALUES 
	(
		@ID_GRUPO,
		@ID_REPRODUCTOR,
		@USUARIO,
		GETDATE()
	)
	SELECT @@IDENTITY

	UPDATE TV_R_TEMPLATE_REPRODUCTOR SET
	ID_TEMPLATE = @ID_TEMPLATE
	WHERE ID_REPRODUCTOR = @ID_REPRODUCTOR

	UPDATE TV_D_GRUPOS SET
	CANTIDAD_REPRODUCTORES = (SELECT COUNT(ID_GRUPO) FROM TV_R_GRUPO_REPRODUCTOR WHERE ID_GRUPO=@ID_GRUPO)
	WHERE ID_GRUPO = @ID_GRUPO
	
	SET NOCOUNT OFF
END
