using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iptv.Negocio.Utilidades;
using iptv.AccesoDatos;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.Enum;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace iptv.Negocio
{
    public class BoLicenciaActiva : IBoLicenciaActiva
    {
        IConfiguration configuration;
        IMapper _mapper;
        CifradoDatos cifrado;
        public BoLicenciaActiva(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
            this.cifrado = new CifradoDatos(configuration);
        }
        public async Task<int> AltaLicenciaActiva(string cadenaLic)
        {
            using (NegocioSesion nSesion = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSesion.UnitOfWork;
                try
                {
                    int result = 0;
                    string licencia;
                    string[] stringSeparators = null;
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<LicenciaActiva> licencias = await daoIptv.ObtnerLicenciaActivaLicenciaAsync(cadenaLic);
                    switch (licencias.Count > 0)
                    {
                        case true:
                            foreach (LicenciaActiva licenciaItem in licencias)
                            {
                                if (licenciaItem.ID_ESTATUS != (int)CatEstatus.ACTIVO)
                                {
                                    await daoIptv.EliminarLicenciaActivaAsync();
                                    throw new ExcepcionIptv("¡Esta licencia ya fue registrada!");
                                }
                                else
                                {
                                    throw new ExcepcionIptv("¡Ya existe una licencia activa!");
                                }
                            }
                            break;
                        case false:
                            licencia = cifrado.DesencriptarLicencia(cadenaLic);
                            stringSeparators = new string[] { "||" };
                            string[] cont = licencia.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                            licencia += DateTime.Now.AddDays(Convert.ToInt32(cont[9])).Day.ToString("00");
                            licencia += "-" + DateTime.Now.AddDays(Convert.ToInt32(cont[9])).Month.ToString("00");
                            licencia += "-" + DateTime.Now.AddDays(Convert.ToInt32(cont[9])).Year.ToString("0000");
                            licencia += " 23:59:59||";
                            licencia = cifrado.EncriptarLicencia(licencia);
                            LicenciaActiva lic = new LicenciaActiva
                            {
                                USUARIO = "IPTV",
                                ID_APLICACION_IST = Convert.ToInt32(cont[7]),
                                ID_ENTIDAD = Convert.ToInt32(cont[3]),
                                ID_SUCURSAL = Convert.ToInt32(cont[5]),
                                ID_ESTATUS = (int)CatEstatus.ACTIVO,
                                LICENCIA = cadenaLic,
                                LICENCIA_ACTIVA = licencia,
                                MAC_ADDRESS = cifrado.Encriptar(cifrado.ObtenerDireccionMAC()),
                                SERIAL_NUMBER_BASE = cont[15],
                                SERIAL_NUMBER_BIOS = cont[17]
                            };
                            result = await daoIptv.AltaLicenciaActivaAsync(lic);
                            break;
                    }
                    unitOfWork.Commit();
                    return result;
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw ex;
                }
            }
        }
    }
}
