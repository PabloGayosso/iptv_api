using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using iptv.AccesoDatos.DTO;

namespace iptv.Negocio
{
    public interface IBoTemplate
    {
        Task<ConsultaTemplateDto> ConsultaTemplates(string Busqueda, int Pagina, int RegistrosPagina);
        Task<List<TemplateDto>> ConsultaTemplatesCatalogo();
        Task<TemplateDto> ConsultaTemplate(int ID_TEMPLATE);
        Task<int> AltaTemplate(AltaTemplateDto templateDto);
        Task<int> ActulizaTemplate(int ID_TEMPLATE, AltaTemplateDto templateDto);
        Task<int> EstatusTemplate(int ID_TEMPLATE, AltaTemplateDto templateDto);
        Task<ConsultaTemplateDto> ConsultaTemplateDicrecto(string Busqueda, int Pagina, int RegistroPorPagina);
        Task<int> GenerarXML(int ID_TEMPLATE, int ID_REPRODUCTOR, string ruta);
        Task<int> PreviewTemplate(int ID_TEMPLATE);
        Task EliminarTemplateAsync(int templateId);

    }
}
