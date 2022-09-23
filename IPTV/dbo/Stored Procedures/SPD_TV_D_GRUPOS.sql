-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPD_TV_D_GRUPOS
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	DELETE FROM TV_D_GRUPO
	WHERE ID_GRUPO = @ID_GRUPO
	SET NOCOUNT OFF
END
