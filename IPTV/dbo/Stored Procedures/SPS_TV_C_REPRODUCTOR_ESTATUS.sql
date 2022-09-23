-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_C_REPRODUCTOR_ESTATUS]
	-- Add the parameters for the stored procedure here
	@ID_ESTATUS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT *
	FROM TV_C_REPRODUCTOR 
	WHERE ID_ESTATUS =  @ID_ESTATUS;
	SET NOCOUNT OFF
END
