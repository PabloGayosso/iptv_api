-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPU_TV_R_TEMPLATE_REPRODUCTOR_ID_REPRODUCTOR
	-- Add the parameters for the stored procedure here
	@ID_REPRODUCTOR INT,
	@ID_TEMPLATE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

    -- Insert statements for procedure here
	UPDATE TV_R_TEMPLATE_REPRODUCTOR SET
	ID_TEMPLATE = ID_TEMPLATE
	WHERE ID_REPRODUCTOR = @ID_REPRODUCTOR
	SET NOCOUNT OFF
END
