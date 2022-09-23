using System;
using System.Collections.Generic;
using System.Text;

namespace iptv.AccesoDatos.Enum
{
    public enum CatEstatus
    {
        ACTIVO = 3,
        INACTIVO = 4
    }
    public enum CatSucursal
    {
        SUCURSAL = 5
    }
    public enum CatTipoContenido
    {
        VIDEOIMAGEN = 21,
        IMAGEN = 22,
        TEXTO = 23,
        MUSICA = 24,
        VIDEOVIVO = 25,
        TABLA = 67
    }
    public enum CatTipoCanal
    {
        VIDEOIMAGEN = 15,
        IMAGEN = 16,
        TEXTO = 17,
        MUSICA = 19,
        TVDIRECTO = 18,
        TABLA = 66
    }
}
