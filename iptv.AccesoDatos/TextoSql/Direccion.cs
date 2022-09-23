using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace iptv.AccesoDatos.TextoSql
{
    public static class Direccion
    {
        public const string CONSULTADIRECCIONES = @"[SPS_GL_D_DIRECCION_All]";
        public const string CONSULTADIRECCION = @"[SPS_GL_D_DIRECCION]";
        public const string ALTADIRECCION = @"[SPI_GL_D_DIRECCION]";
        public const string ACTULIZADIRECCION = @"[SPU_GL_D_DIRECCION]";
        public const string OBTENERTOTALDIRECCIONES = @"SELECT COUNT(ID_DIRECCION) FROM GL_D_DIRECCION";
        public const string OBTENERDIRECCIONESPERSNA = @"
                SELECT d.*, dp.*, p.*, pa.*, e.*, deg.*, c.* FROM GL_D_DIRECCION d
            INNER JOIN GL_R_PERSONA_DIRECCION dp
            ON d.ID_DIRECCION = dp.ID_DIRECCION 
            INNER JOIN GL_D_PERSONA p
            ON dp.ID_PERSONA = p.ID_PERSONA
            INNER JOIN GL_C_PAIS pa
            ON pa.ID_PAIS = d.ID_PAIS 
            INNER JOIN GL_C_ESTADO e
            on e.ID_ESTADO = d.ID_ESTADO
            INNER JOIN GL_C_DELEG_MUNICIPIO deg
            ON deg.ID_ESTADO = d.ID_ESTADO AND
            deg.ID_DELEG_MUNICIPIO = d.ID_DELEG_MUNICIPIO
            INNER JOIN GL_C_COLONIA c
            ON c.ID_COLONIA = d.ID_COLONIA AND 
            c.ID_DELEG_MUNICIPIO = d.ID_DELEG_MUNICIPIO AND
            c.ID_ESTADO = d.ID_ESTADO
            ORDER BY d.ID_DIRECCION DESC
            OFFSET ((@Pagina-1) * @RegistrosPorPagina) ROWS
            FETCH NEXT @RegistrosPorPagina ROWS ONLY 
        ";
        public const string CONSULTADIRECCIONPERSONAIDDIRECCION = @"
            SELECT d.*, dp.*, p.*, pa.*, e.*, deg.*, c.* FROM GL_D_DIRECCION d
            INNER JOIN GL_R_PERSONA_DIRECCION dp
            ON d.ID_DIRECCION = dp.ID_DIRECCION 
            INNER JOIN GL_D_PERSONA p
            ON dp.ID_PERSONA = p.ID_PERSONA
            INNER JOIN GL_C_PAIS pa
            ON pa.ID_PAIS = d.ID_PAIS 
            INNER JOIN GL_C_ESTADO e
            on e.ID_ESTADO = d.ID_ESTADO
            INNER JOIN GL_C_DELEG_MUNICIPIO deg
            ON deg.ID_ESTADO = d.ID_ESTADO AND
            deg.ID_DELEG_MUNICIPIO = d.ID_DELEG_MUNICIPIO
            INNER JOIN GL_C_COLONIA c
            ON c.ID_COLONIA = d.ID_COLONIA AND 
            c.ID_DELEG_MUNICIPIO = d.ID_DELEG_MUNICIPIO AND
            c.ID_ESTADO = d.ID_ESTADO
            WHERE d.ID_DIRECCION = @ID_DIRECCION
        ";
        public const string ALTAPERSONADIRECCION = @"[SPI_GL_R_PERSONA_DIRECCION]";
        public const string BORRARDIRECCIONESPERSNA = @"[SPD_GL_R_PERSONA_DIRECCION_DIRECCION]";
    }
}
