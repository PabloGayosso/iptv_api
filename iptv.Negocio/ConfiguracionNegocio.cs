using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace iptv.Negocio
{
    public static class ConfiguracionNegocio
    {
        public static IServiceCollection AddNegocioIptv(this IServiceCollection services)
        {
            services.AddScoped<IBoAuditoria, BoAuditoria>();
            services.AddScoped<IBoAutenticacion, BoAutenticacion>();
            services.AddScoped<IBoPerfil, BoPerfil>();
            services.AddScoped<IBoPersona, BoPersona>();
            services.AddScoped<IBoSucursal, BoSucursal>();
            services.AddScoped<IBoUsuario, BoUsuario>();
            services.AddScoped<IBoEmpresa, BoEmpresa>();
            services.AddScoped<IBoParametro, BoParametro>();
            services.AddScoped<IBoLicenciaActiva, BoLicenciaActiva>();
            services.AddScoped<IBoOpcion, BoOpcion>();
            services.AddScoped<IBoDireccion, BoDireccion>();
            services.AddScoped<IBoRepositorio, BoRepositorio>();
            services.AddScoped<IBoMensaje, BoMensaje>();
            services.AddScoped<IBoCanal, BoCanal>();
            services.AddScoped<IBoContenido, BoContenido>();
            services.AddScoped<IBoPais, BoPais>();
            services.AddScoped<IBoTemplate, BoTemplate>();
            services.AddScoped<IBoEstado, BoEstado>();
            services.AddScoped<IBoDelegacionMunicipio, BoDelegacionMunicipio>();
            services.AddScoped<IBoColonia, BoColonia>();
            services.AddScoped<IBoGrupo, BoGrupo>();
            services.AddScoped<IBoReproductor, BoReproductor>();
            services.AddScoped<IBoMensajeVivo, BoMensajeVivo>();
            services.AddScoped<IBoTablaDinamica, BoTablaDinamica>();
            services.AddScoped<IBoHorarioTerminal, BoHorarioTerminal>();
            services.AddScoped<IBoEnvios, BoEnvios>();
            return services;
        }
    }
}
