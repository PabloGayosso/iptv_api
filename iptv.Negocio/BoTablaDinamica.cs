using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos;
using iptv.Negocio.Utilidades;
using Newtonsoft.Json.Linq;

namespace iptv.Negocio
{
    public class BoTablaDinamica : IBoTablaDinamica
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoTablaDinamica(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
        public async Task<int> AltaTablaDinamica(string TablaDinamicaDto)
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    unitOfWork.Begin();
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    string USUARIO = "Admin";
                    string columName = "";
                    string columValue = "";
                    bool isFirst = true;
                    bool isFirstName = true;
                    List<string> values = new List<string>();
                    var tabla = TablaDinamicaDto.Split("{");
                    var columnas = tabla[1].Split(",");
                    JObject rss = JObject.Parse(TablaDinamicaDto);
                    var nombreTabla = (string)rss["nombreHoja"];
                    //var sobrescribri = (bool)rss[""]
                    if (!await daoIptv.ConsultaTablaNombreAsync(nombreTabla))
                    {
                        //if(sobrescribri)
                        var rows = (JArray)rss["rows"];
                        foreach (JObject content in rows.Children<JObject>())
                        {
                            foreach (JProperty prop in content.Properties())
                            {
                                if (isFirstName)
                                {
                                    string tempName = prop.Name.ToString();
                                    string tempValue = prop.Value.ToString();
                                    if (isFirst)
                                    {
                                        columName += tempName;
                                        columValue += tempValue;
                                        isFirst = false;
                                    }
                                    else
                                    {
                                        columName += "," + tempName;
                                        columValue += "|" + tempValue;
                                    }
                                }
                                else
                                {
                                    string tempValue = prop.Value.ToString();
                                    if (isFirst)
                                    {
                                        columValue += tempValue;
                                        isFirst = false;
                                    }
                                    else
                                        columValue += "|" + tempValue;
                                }
                            }
                            isFirstName = false;
                            isFirst = true;
                            values.Add(columValue);
                            columValue = "";
                        }
                        var respuesta = await daoIptv.CrearTablaASync(nombreTabla, columName, USUARIO);

                        foreach (string value in values)
                        {
                            await daoIptv.AltaDatosTablaAsync(respuesta, value);
                        }
                        unitOfWork.Commit();
                        return respuesta;
                    }
                    else
                        throw new ExcepcionIptv("Tabla existente");
                }
                catch (ExcepcionIptv)
                {
                    unitOfWork.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
        public async Task<List<TablaDTO>> CatalogoTablas()
        {
            using (NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Tabla> tabla = await daoIptv.ConsultaCatTabla();
                    List<TablaDTO> tablaDTO = _mapper.Map<List<TablaDTO>>(tabla);
                    return tablaDTO;
                }
                catch(ExcepcionIptv)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
        public async Task<ConsultaTablaDinamicaDTO> ObtnerTablas(int Pagina, int RegistroPorPagina)
        {
            using(NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    List<Tabla> tabla = await daoIptv.ConsultaTablasAsync(Pagina, RegistroPorPagina);
                    List<TablaDTO> tablaDTO = _mapper.Map<List<TablaDTO>>(tabla);
                    int total = await daoIptv.ConsultaTablasTotalAsync();
                    ConsultaTablaDinamicaDTO consulta = new ConsultaTablaDinamicaDTO()
                    {
                        ConsultaTabla = tablaDTO,
                        Total = total
                    };
                    return consulta;
                }
                catch (ExcepcionIptv)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public async Task<List<dynamic>> ObtenerTablaDinamicaIDTabla(int ID_TABLA)
        {
            using(NegocioSesion nSession = new NegocioSesion(configuration))
            {
                UnitOfWork unitOfWork = nSession.UnitOfWork;
                try
                {
                    DaoIptv daoIptv = new DaoIptv(unitOfWork);
                    var respuesta = await daoIptv.ConsultaTablaDinamicaAsync(ID_TABLA);
                    return respuesta;
                }
                catch(ExcepcionIptv)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
