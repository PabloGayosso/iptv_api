-- =============================================
-- Author:		Ing. Luis FErnando Angeles Escamilla
-- Create date: 15-09-2020
-- Description:	Seleccionar los daots de una tabla construida dinamicamente
-- =============================================
CREATE PROCEDURE SPS_TV_D_TABLA_NOMBRE
    @NOMBRE NVARCHAR(250)
AS
BEGIN
   SET NOCOUNT ON
   SELECT NOMBRE
   FROM TV_D_TABLA
   WHERE NOMBRE = @NOMBRE
     SET NOCOUNT OFF

END
