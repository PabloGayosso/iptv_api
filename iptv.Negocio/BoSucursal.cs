using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;
using iptv.AccesoDatos;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace iptv.Negocio
{
    public class BoSucursal : IBoSucursal
    {
        IConfiguration configuration;
        IMapper _mapper;
        public BoSucursal(IConfiguration configuration, IMapper _mapper)
        {
            this.configuration = configuration;
            this._mapper = _mapper;
        }
    }
}
