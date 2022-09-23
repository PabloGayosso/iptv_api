-- =============================================
-- Author:		Gerardo Gonzalez
-- Create date: 02/04/2020
-- Description:	Buscar registro por ID_MENSAJE_VIVO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_TV_D_MENSAJE_VIVO]
	-- Add the parameters for the stored procedure here
	@ID_MENSAJE INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT
    TA.ID_MENSAJE
    ,TA.ID_ESTATUS
    ,TA.DSC_MENSAJE
    ,TA.ES_REPETITIVO
    ,TA.TIEMPO_REPETICION
    ,TA.FECHA_ALTA
    ,TA.FECHA_MOD
    ,TA.USUARIO
    ,TA.COLOR_FONDO_BARRA_TEXTO
    ,TA.OPACIDAD_TEXTO
    ,TA.OPACIDAD_BARRA_TEXTO
    ,TA.TIPO_LETRA_TEXTO
    ,TA.TAMANIO_LETRA_TEXTO
    ,TA.COLOR_TEXTO
    ,TA.VELOCIDAD_TEXTO
    ,(
      SELECT TOP 1 ID_GRUPO
      FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
      WHERE ID_MENSAJE = TA.ID_MENSAJE
      GROUP BY ID_GRUPO
    ) ID_GRUPO
    ,(
      SELECT TOP 1
        CASE 
          WHEN ID_GRUPO IS NULL THEN ID_REPRODUCTOR
          ELSE NULL
        END ID_REPRODUCTOR
      FROM TV_R_GRUPO_REPRODUCTOR_MENSAJE_VIVO
      WHERE ID_MENSAJE = TA.ID_MENSAJE
    )ID_REPRODUCTOR
  FROM TV_D_MENSAJE_VIVO TA
	WHERE TA.ID_MENSAJE = @ID_MENSAJE
	SET NOCOUNT OFF
END
