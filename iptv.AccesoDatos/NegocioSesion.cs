using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace iptv.AccesoDatos
{
    public sealed class NegocioSesion : IDisposable
    {
        IDbConnection _conexion = null;
        UnitOfWork _unitOfWork = null;

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _conexion.Dispose();
        }


        public NegocioSesion(IConfiguration configuracion)
        {
            _conexion = new SqlConnection(configuracion.GetConnectionString("ConexionStringIPTV"));
            _conexion.Open();
            _unitOfWork = new UnitOfWork(_conexion);
        }

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }
    }
    public sealed class UnitOfWork : IUnitOfWork
    {
        internal UnitOfWork(IDbConnection conexion)
        {
            _id = Guid.NewGuid();
            _conexion = conexion;
        }

        IDbConnection _conexion = null;
        IDbTransaction _transaction = null;
        Guid _id = Guid.Empty;

        IDbConnection IUnitOfWork.Conexion
        {
            get { return _conexion; }
        }
        IDbTransaction IUnitOfWork.Transaccion
        {
            get { return _transaction; }
        }
        Guid IUnitOfWork.Id
        {
            get { return _id; }
        }

        public void Begin()
        {
            _transaction = _conexion.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }
    }
}
