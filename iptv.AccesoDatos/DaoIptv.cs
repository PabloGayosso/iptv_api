using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        IUnitOfWork unitOfWork = null;
        IDbConnection conexion = null;
        IDbTransaction transacion = null;

        public DaoIptv(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("El párametro unitofwork no puede ser nulo", nameof(unitOfWork));
            conexion = unitOfWork.Conexion;
            transacion = unitOfWork.Transaccion;
        }
    }
}
