using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class HorarioTerminal
    {
        public const string ALTAHORARIO = @"
        INSERT INTO [dbo].[TV_D_HORARIO_TERMINAL]
                   ([horaEncendio]
                   ,[horaApagado]
                   ,[idEstatus]
                   ,[fechaAlta]
                   ,[usuario])
             VALUES
                   (@horaEncendio
                   ,@horaApagado
                   ,@idEstatus
                   ,GETDATE()
                   ,@usuario)
	        SELECT @@IDENTITY";
        public const string ACTULIZAHORARIO = @"
        UPDATE [dbo].[TV_D_HORARIO_TERMINAL]
           SET [horaEncendio] = @horaEncendio
              ,[horaApagado] = @horaApagado
              ,[idEstatus] = @idEstatus
              ,[fechaModificacion] = GETDATE()
              ,[usuario] = @usuario
         WHERE IdTvHorarioTerminal = @IdTvHorarioTerminal
        ";
        public const string CONSULTAHORARIOS = @"
        
        SELECT * FROM TV_D_HORARIO_TERMINAL
        ";

        public const string ALTAHORARIOGRUPO = @"
        INSERT INTO [dbo].[TV_R_HORARIO_GRUPO]
           ([ID_HORARIO]
           ,[ID_GRUPO]
           ,[FECH_ALTA]
           ,[USUARIO])
         VALUES
               (@ID_HORARIO
               ,@ID_GRUPO
               ,GETDATE()
               ,@USUARIO)
        ";
        public const string ELIMINARHORARIOGRUPO = @"
        DELETE [dbo].[TV_R_HORARIO_GRUPO] WHERE ID_GRUPO = @ID_GRUPO;
        ";
        public const string CONSULTAHORARIOGRUPO = @"
        SELECT h.*, hg.*, g.* FROM TV_D_HORARIO_TERMINAL h
        INNER JOIN TV_R_HORARIO_GRUPO hg
        ON hg.ID_HORARIO = h.IdTvHorarioTerminal
        INNER JOIN TV_D_GRUPOS g
        ON hg.ID_GRUPO = g.ID_GRUPO WHERE g.ID_GRUPO = @ID_GRUPO
        ";
        
	}
}
