using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Canal
    {
        public const string CONSULTACANELS = @"[SPS_TV_D_CANAL_All]";
        public const string CONSULTACANAL = @"[SPS_TV_D_CANAL]";
        public const string CONSULTACANALCONTENIDO = @"[SPS_TV_R_CANAL_CONTENIDO_CANAL]";
        public const string CANALESTATUS = @"[SPS_TV_D_CANAL_All]";
        public const string TOTALCANALES = @"SELECT COUNT(ID_CANAL) FROM TV_D_CANAL";
        public const string ALTACANAL = @"[SPI_TV_D_CANAL]";
        public const string ALTACANAL_ = @"[SPI_TV_D_CANAL_]";
        public const string ALTACANALCONTENIDO = @"[SPI_TV_R_CANAL_CONTENIDO]";
        public const string ACTULIZACANAL = @"[SPU_TV_D_CANAL]";
        public const string ACTULIZACANAL_ = @"[SPU_TV_D_CANAL_]";
        public const string ELIMINACANALCONTENIDO = @"[SPD_TV_R_CANAL_CONTENIDO_ID_CANAL]";
        public const string CONSULTACANALESACTIVOS = @"
        SELECT ca.*, c.*, r.*, m.*, t.* FROM TV_D_CANAL ca
        LEFT JOIN TV_R_CANAL_CONTENIDO cc
        ON ca.ID_CANAL = cc.ID_CANAL
        LEFT JOIN TV_D_CONTENIDO c
        ON cc.ID_CONTENIDO = c.ID_CONTENIDO
        LEFT JOIN TV_D_REPOSITORIO r
        ON c.ID_REPOSITORIO = r.ID_REPOSITORIO
        LEFT JOIN TV_C_MENSAJES  m
        ON c.ID_MENSAJE = m.ID_MENSAJE
        LEFT JOIN TV_D_TABLA t
        ON c.ID_TABLA = t.ID_TABLA
        WHERE ca.ID_ESTATUS = @ID_ESTATUS
        ";
        public const string CAMBIODECONTENIDO = @"[SPU_TV_R_CANAL_CONTENIDO_DIRECTO]";
    }
}
