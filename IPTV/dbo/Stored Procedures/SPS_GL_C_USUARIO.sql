﻿
-- =============================================
-- Author:       Ing. Luis Fernando Angeles Escamilla
-- Create date:  15/08/2018
-- Description:  Selecciona un registro en especifico de la tabla GL_C_USUARIO
-- =============================================
CREATE PROCEDURE [dbo].[SPS_GL_C_USUARIO]
    @ID_USUARIO INT
  AS
BEGIN
  SET NOCOUNT ON
  SELECT 
      ID_USUARIO
      ,ID_PERSONA
      ,ID_SUCURSAL
      ,CLAVE_USUARIO
      ,CONTRASENA
      ,ID_PERFIL
      ,ID_ESTATUS
      ,FEC_ALTA
      ,FEC_MOD
      ,USUARIO
    FROM GL_C_USUARIO
    WHERE
      ID_USUARIO = @ID_USUARIO
  SET NOCOUNT OFF
END

