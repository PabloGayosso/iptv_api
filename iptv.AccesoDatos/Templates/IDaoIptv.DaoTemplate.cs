using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos.Templates
{
    public partial interface IDaoIptv
    {
        Task<List<Template>> ConsultaTemplatesAsync(int Pagina, int RegistrosPagina);
        Task<List<Template>> ConsultaTemplatesCatalogoAsync();
        Task<Template> ConsultaTemplateAsync(int ID_TEMPLATE);
        Task<int> AltaTemplateAsync(Template template);
        Task<int> ActulizaTemplateAsync(int ID_TEMPLATE, Template template);
        Task<int> ConsultaTotalTemplatesAsync();
        Task<List<Template>> ConsultaTemplateDirecoAsync(int Pagina, int RegistroPorPagina);
        Task<int> ConsultaTotalTemplateDirectoAync();
        Task<int> AltaTemplateCanalAsync(int ID_TEMPLATE, int ID_ESTATUS, Canal canal);
        Task<int> BorrarTemplateCanalAsync(int ID_TEMPLATE);
        Task<int> actulizaPreview(PreviewTemplate template);
        Task<PreviewTemplate> consultaPreviewID();
        Task<int> InsertaPreview(int ID_TEMPLATE);
    }
}
