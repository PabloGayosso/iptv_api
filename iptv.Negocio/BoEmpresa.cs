using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.Negocio.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace iptv.Negocio
{
    public class BoEmpresa : IBoEmpresa
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoEmpresa(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }

    }
}
