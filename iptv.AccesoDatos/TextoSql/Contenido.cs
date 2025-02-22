﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Contenido
    {
        public const string ACTULIZACONTENIDOCANAL = @"[SPU_TV_D_CONTENIDO_CANAL]";
        public const string ELIMINARCONTENIDO = @"[SPD_TV_D_CONTENIDO]";
        public const string CONSULTACONTENIDOS = @"[SPS_TV_D_CONTENIDO_All]";
        public const string CONSULTACONTENIDO = @"[SPS_TV_D_CONTENIDO]";
        public const string CONSULTACONTENIDOCANAL = @"[SPS_TV_R_CANAL_CONTENIDO_ID_CANAL]";
        public const string CONSULTATOTALCONTENIDOS = @"SELECT COUNT(ID_CONTENIDO) FROM TV_D_CONTENIDO";
        public const string ALTACONTENIDOMULTIMEDIA = @"[SPI_TV_D_CONTENIDO_MULTIMEDIA]";
        public const string ALTACONTENIDOSTREAM = @"[SPI_TV_D_CONTENIDO_STREAM]";
        public const string ALTACONTENIDOTEXTO = @"[SPI_TV_D_CONTENIDO_TEXTO]";
        public const string ALTACONTENIDOTABLA = @"[SPI_TV_D_CONTENIDO_TABLA]";
        public const string ACTULIZACONTENIDOMULTIMEDIA = @"[SPU_TV_D_CONTENIDO_MULTIMEDIA]";
        public const string ACTULIZACONTENIDOSTREAM = @"[SPU_TV_D_CONTENIDO_STREAM]";
        public const string ACTULIZACONTENIDOTEXTO = @"[SPU_TV_D_CONTENIDO_TEXTO]";
        public const string ACTULIZACONTENIDOTABLA = @"[SPU_TV_D_CONTENIDO_TABLA]";
        public const string CONSULTACONTENIDOACTIVO = @"
        SELECT * FROM TV_D_CONTENIDO 
        WHERE ID_ESTATUS = @ID_ESTATUS 
        AND ID_TIPO_CANAL = @ID_TIPO_CANAL    
        ";
        public const string CONSULTACONTENIDOACTIVONOASIGNADO = @"
        SELECT * FROM TV_D_CONTENIDO CO
        WHERE CO.ID_ESTATUS = @ID_ESTATUS 
        AND CO.ID_TIPO_CANAL = @ID_TIPO_CANAL
        AND CO.ID_CONTENIDO NOT IN(
        SELECT CC.ID_CONTENIDO
        FROM TV_R_CANAL_CONTENIDO CC 
        WHERE cc.ID_CANAL=@ID_CANAL)
        ";
        public const string CONSULTACONTENIDOMENSAJEACTIVO = @"
        SELECT c.*, m.* FROM TV_D_CONTENIDO c
        INNER JOIN TV_C_MENSAJES m
        ON m.ID_MENSAJE = c.ID_MENSAJE
        WHERE c.ID_ESTATUS = @ID_ESTATUS 
        AND c.ID_TIPO_CANAL =  @ID_TIPO_CANAL 
        ";
        public const string CONSULTACONTENIDOMENSAJEACTIVONOASIGNADO = @"
        SELECT c.*, m.* FROM TV_D_CONTENIDO c
        INNER JOIN TV_C_MENSAJES m
        ON m.ID_MENSAJE = c.ID_MENSAJE
        WHERE c.ID_ESTATUS = @ID_ESTATUS 
        AND c.ID_TIPO_CANAL =  @ID_TIPO_CANAL 
        AND c.ID_CONTENIDO NOT IN (
        SELECT CC.ID_CONTENIDO FROM TV_R_CANAL_CONTENIDO CC
        WHERE ID_CANAL=@ID_CANAL)
        ";
        public const string CONSULTACONTENIDOTABLAASIGNADO = @"
        SELECT c.*, m.* FROM TV_D_CONTENIDO c
        INNER JOIN TV_D_TABLA m
        ON m.ID_TABLA = c.ID_TABLA
        WHERE c.ID_ESTATUS = @ID_ESTATUS 
        AND c.ID_TIPO_CANAL =  @ID_TIPO_CANAL 
        ";
        public const string CONSULTACONTENIDOTABLANOASIGNADO = @"
        SELECT c.*, m.* FROM TV_D_CONTENIDO c
        INNER JOIN TV_D_TABLA m
        ON m.ID_TABLA = c.ID_TABLA
        WHERE c.ID_ESTATUS = @ID_ESTATUS 
        AND c.ID_TIPO_CANAL =  @ID_TIPO_CANAL 
        AND c.ID_CONTENIDO NOT IN (
        SELECT CC.ID_CONTENIDO FROM TV_R_CANAL_CONTENIDO CC
        WHERE ID_CANAL=@ID_CANAL)
        ";
        public const string CONSULTACONTENIDOREPOSITORIOACTIVO = @"
        SELECT c.*, r.* FROM TV_D_CONTENIDO c
        INNER JOIN TV_D_REPOSITORIO r
        ON r.ID_REPOSITORIO = c.ID_REPOSITORIO
        WHERE c.ID_ESTATUS = @ID_ESTATUS
        AND c.ID_TIPO_CANAL = @ID_TIPO_CANAL 
        ";
        public const string CONSULTACONTENIDOREPOSITORIOACTIVONOASIGNADO = @"
        SELECT c.*, r.* FROM TV_D_CONTENIDO c
        INNER JOIN TV_D_REPOSITORIO r
        ON r.ID_REPOSITORIO = c.ID_REPOSITORIO
        WHERE c.ID_ESTATUS = @ID_ESTATUS
        AND c.ID_TIPO_CANAL = @ID_TIPO_CANAL 
        AND C.ID_CONTENIDO NOT IN (
        SELECT CC.ID_CONTENIDO FROM TV_R_CANAL_CONTENIDO CC
        WHERE ID_CANAL=@ID_CANAL)
        ";
        public const string CONSULTACONTENIDOSPORIDCANAL = @"
        SELECT c.*, TC.RUTA_ALOJAMIENTO AS RUTA_ONLINE, CONVERT(varchar, RP.DURACION,24) AS DURACION, 
        convert(varchar, cc.FEC_FIN, 103) +' '+ convert(varchar, cc.FEC_FIN, 8) as FEC_FIN, 
        convert(varchar, cc.FEC_INICIO, 103) +' '+ convert(varchar, cc.FEC_INICIO, 8) as FEC_INICIO,
        cc.INICIO_SEG,
        cc.INICIO_MIN, cc.INICIO_HRS, cc.FIN_SEG, cc.FIN_MIN, cc.FIN_HRS
        FROM TV_D_CONTENIDO c
        LEFT JOIN TV_R_CANAL_CONTENIDO cc
        ON c.ID_CONTENIDO = cc.ID_CONTENIDO
        LEFT JOIN TV_D_REPOSITORIO RP
        ON c.ID_REPOSITORIO = RP.ID_REPOSITORIO
        LEFT JOIN TV_C_REPOSITORIO TC 
        ON RP.DESCRIPCION = TC.NOMBRE
        WHERE cc.ID_CANAL = @ID_CANAL
        ";
    public const string LIMPIARREPOSITORIODLNA = @"TRUNCATE TABLE TV_C_REPOSITORIO";
    }
}
