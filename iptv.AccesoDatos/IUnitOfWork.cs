using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace iptv.AccesoDatos
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IDbConnection Conexion { get; }
        IDbTransaction Transaccion { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
