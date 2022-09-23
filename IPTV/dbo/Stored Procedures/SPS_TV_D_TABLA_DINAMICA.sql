-- =============================================
-- Author:		Ing. Luis FErnando Angeles Escamilla
-- Create date: 15-09-2020
-- Description:	Seleccionar los daots de una tabla construida dinamicamente
-- =============================================
CREATE PROCEDURE [SPS_TV_D_TABLA_DINAMICA]
	@ID_TABLA INT
AS
BEGIN
	SET NOCOUNT ON;
  DECLARE 
    @NOMBRE_TABLA_BD NVARCHAR(MAX)
    ,@SQL NVARCHAR(MAX)
    ,@COLUMNA_NOM NVARCHAR(MAX)
    ,@COLUMNA_DB NVARCHAR(MAX)
    ,@COLUMNAS NVARCHAR(MAX)
  
   --SET @ID_TABLA = 1012

   SELECT @NOMBRE_TABLA_BD = NOMBRE_BD
   FROM TV_D_TABLA
   WHERE ID_TABLA = @ID_TABLA

   SET @SQL = 'SELECT ';
   SET @COLUMNAS = '';

  DECLARE ProdInfo CURSOR FOR 
      SELECT TA.NOMBRE_BD ,TA.NOMBRE
      FROM TV_D_COLUMNA TA
      LEFT JOIN TV_R_COLUMNA_TABLA TB ON TB.ID_COLUMNA = TA.ID_COLUMNA
      WHERE TB.ID_TABLA = @ID_TABLA
    OPEN ProdInfo
      FETCH NEXT FROM ProdInfo INTO @COLUMNA_DB,@COLUMNA_NOM
      WHILE @@fetch_status = 0
      BEGIN
        PRINT @COLUMNA_NOM
        SET @COLUMNAS = @COLUMNAS + ' ,' + @COLUMNA_DB + ' AS [' + @COLUMNA_NOM + ']';
        FETCH NEXT FROM ProdInfo INTO @COLUMNA_DB,@COLUMNA_NOM;
      END
    CLOSE ProdInfo
  DEALLOCATE ProdInfo

  --PRINT @COLUMNAS;
  SET @SQL = @SQL + SUBSTRING(@COLUMNAS,3,LEN(@COLUMNAS)) + ' FROM ' + @NOMBRE_TABLA_BD;
  --PRINT @SQL;

  EXEC sys.[sp_executesql] @SQL;

END
