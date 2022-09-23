using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.AccesoDatos
{
    public class AutoMapperConfiguracion
    {
        public static MapperConfiguration Configuracion()
        {
            return new MapperConfiguration(
                m =>
                {
                    m.CreateMap<Auditoria, AuditoriaDto>().ReverseMap();
                    m.CreateMap<Auditoria, AltaAuditoriaDto>().ReverseMap();
                    m.CreateMap<Perfil, PerfilDto>().ReverseMap();
                    m.CreateMap<Perfil, AltaPerfilDto>().ReverseMap();
                    m.CreateMap<Perfil, AsignaPerfilOpcionDto>().ReverseMap();
                    m.CreateMap<Opcion, OpcionDto>().ReverseMap();
                    m.CreateMap<Parametro, ParametroDto>().ReverseMap();
                    m.CreateMap<Parametro, AltaParametroDto>().ReverseMap();
                    m.CreateMap<Usuario, UsuarioDto>().ReverseMap();
                    m.CreateMap<Usuario, AltaUsuarioDto>()
                     .ForMember(destino => destino.UsuarioRegistro, options => options.MapFrom(origen => origen.USUARIO))
                     .ReverseMap();
                    m.CreateMap<Persona, PersonaDto>().ReverseMap();
                    m.CreateMap<Persona, AltaPersonaDto>().ReverseMap();
                    m.CreateMap<Direccion, DireccionDto>().ReverseMap();
                    m.CreateMap<Direccion, AltaDireccionDto>().ReverseMap();
                    m.CreateMap<Repositorio, RepositorioDto>().ReverseMap();
                    m.CreateMap<Mensaje, MensajeDto>().ReverseMap();
                    m.CreateMap<Mensaje, AltaMensajeDto>().ReverseMap();
                    m.CreateMap<Canal, CanalDto>().ReverseMap();
                    m.CreateMap<Canal, AltaCanalDto>().ReverseMap();
                    m.CreateMap<Contenido, ContenidoDto>().ReverseMap();
                    m.CreateMap<Contenido, AltaContenidoDto>().ReverseMap();
                    m.CreateMap<Pais, PaisDto>().ReverseMap();
                    m.CreateMap<Template, TemplateDto>().ReverseMap();
                    m.CreateMap<Template, AltaTemplateDto>()
                    .ForMember(destino => destino.canales, options => options.MapFrom(origen => origen.canal))
                    .ReverseMap();
                    m.CreateMap<Template, ConsultaTemplateDto>().ReverseMap();
                    m.CreateMap<Pais, PaisDto>().ReverseMap();
                    m.CreateMap<Estado, EstadoDto>().ReverseMap();
                    m.CreateMap<DelegacionMunicipio, DelegacionMunicipioDto>().ReverseMap();
                    m.CreateMap<Colonia, ColoniaDto>().ReverseMap();
                    m.CreateMap<Grupo, AltaGrupoDto>().ReverseMap();
                    m.CreateMap<Grupo, GrupoDto>().ReverseMap();
                    m.CreateMap<Reproductor, ReproductorDto>().ReverseMap();
                    m.CreateMap<Reproductor, ConsultaReproductoresDto>().ReverseMap();
                    m.CreateMap<Reproductor, AltaReproductorDto>().ReverseMap();
                    m.CreateMap<MensajeVivo, MensajeVivoDto>().ReverseMap();
                    m.CreateMap<MensajeVivo, AltaMensajeVivoDto>().ReverseMap();
                    m.CreateMap<MensajeVivo, ConsultaMensajeVivoDto>().ReverseMap();
                    m.CreateMap<Recolector, AltaRecolectorDto>().ReverseMap();
                    m.CreateMap<Recolector, RecolectorDto>().ReverseMap();
                    m.CreateMap<TemplateCanal, TemplateCanalDto>().ReverseMap();
                    m.CreateMap<Tabla, TablaDTO>().ReverseMap();
                    m.CreateMap<PersonasUsuarios, PersonaUsuarioDto>().ReverseMap();
                    m.CreateMap<HorarioTerminal, AltaHorarioTerminalDto>().ReverseMap();
                    m.CreateMap<HorarioTerminal, HorarioTerminalDto>().ReverseMap();
                    m.CreateMap<Envios, EnviosDto>().ReverseMap();
                    m.CreateMap<Envios, Consulta_EnviosDto>().ReverseMap();
                    m.CreateMap<EnvioH, EnviosHDto>().ReverseMap();
                    m.CreateMap<EnvioH, Consulta_EnviosHDto>().ReverseMap();
                }
            );
        }
    }
}
