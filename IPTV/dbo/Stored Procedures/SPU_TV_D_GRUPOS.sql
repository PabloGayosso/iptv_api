-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPU_TV_D_GRUPOS] 
	-- Add the parameters for the stored procedure here
	@ID_GRUPO INT,
	@NOMBRE NVARCHAR(30)
	,@DESCRIPCION TEXT
	,@ID_ESTATUS INT
	,@USUARIO NVARCHAR(30),
	@ID_TEMPLATE int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	UPDATE TV_D_GRUPOS SET
	NOMBRE = @NOMBRE,
	DESCRIPCION = @DESCRIPCION,
	ID_ESTATUS = @ID_ESTATUS,
	USUARIO = @USUARIO,
	FECHA_MOD = GETDATE(),
	ID_TEMPLATE = @ID_TEMPLATE
	WHERE 
	ID_GRUPO = @ID_GRUPO
	SET NOCOUNT OFF
END
