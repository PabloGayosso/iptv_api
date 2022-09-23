-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPD_TV_R_TEMPLATE_REPRODUCTOR_ID_TEMPLATE
	-- Add the parameters for the stored procedure here
	@ID_TEMPLATE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	DELETE TV_R_TEMPLATE_CANAL
	WHERE ID_TEMPLATE = @ID_TEMPLATE;
	SET NOCOUNT OFF
END
