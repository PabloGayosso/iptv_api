using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using Dapper;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<int> BorrarTemplateCanalAsync(int ID_TEMPLATE)
        {
            try
            {
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Template.BORRATEMPLATECANAL, param: new { ID_TEMPLATE }, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaTemplateCanalAsync(int ID_TEMPLATE, int ID_ESTATUS, Canal canal)
        {
            try
            {
                var p = new
                {
                    ID_TEMPLATE = ID_TEMPLATE,
                    ID_CANAL = canal.ID_CANAL,
                    ID_ESTATUS = ID_ESTATUS,
                    ALTO = canal.ALTO,
                    ANCHO = canal.ANCHO,
                    POSICION_X = canal.POSICION_X,
                    POSICION_Y = canal.POSICION_Y,
                    ORDEN = canal.ORDEN,
                    USUARIO = canal.USUARIO
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Template.ALTATEMPLATECANAL, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ConsultaTotalTemplatesAsync()
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Template.TOTALTEMPLATES);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Template>> ConsultaTemplatesAsync(string Busqueda, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Busqueda = Busqueda,
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var respuesta = await conexion.QueryAsync<Template>(TextoSql.Template.CONSULTATEMPLATES, p, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Template>> ConsultaTemplatesCatalogoAsync()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<Template>(TextoSql.Template.CONSULTATEMPLATESCATALOGO, commandType: CommandType.StoredProcedure);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Template> ConsultaTemplateAsync(int ID_TEMPLATE)
        {
            try
            {
                Dictionary<int, Template> diccionarioTemplate = new Dictionary<int, Template>();
                Dictionary<int, TemplateCanal> diccionarioTemplateCanal = new Dictionary<int, TemplateCanal>();
                var resultado = await conexion.QueryAsync<Template>(TextoSql.Template.CONSULTATEMPLATECANAL,
                new[]{
                   typeof(Template),
                   typeof(TemplateCanal),
                   typeof(Canal)
                },
                respuesta =>
                {
                    Template template;
                    TemplateCanal templateCanal;
                    Canal canal;
                    if (!diccionarioTemplate.TryGetValue(((Template)respuesta[0]).ID_TEMPLATE, out template))
                    {
                        template = respuesta[0] as Template;
                        template.templateCanal = new List<TemplateCanal>();
                        diccionarioTemplate.Add(template.ID_TEMPLATE, template);
                    }
                    if (!diccionarioTemplateCanal.TryGetValue(((TemplateCanal)respuesta[1]).ID_CANAL_TEMPLATE, out templateCanal))
                    {
                        templateCanal = respuesta[1] as TemplateCanal;
                        template.templateCanal.Add(templateCanal);
                        templateCanal.canales = new List<Canal>();
                        diccionarioTemplateCanal.Add(templateCanal.ID_CANAL_TEMPLATE, templateCanal);
                    }
                    canal = respuesta[2] as Canal;
                    templateCanal.canales.Add(canal);
                    return template;
                },
                splitOn: "ID_CANAL_TEMPLATE,ID_CANAL"
                , param: new
                {
                    ID_TEMPLATE
                },
                transaction: unitOfWork.Transaccion
                );
                Template templatec = new Template();
                if (resultado.ToList().Count > 0)
                    templatec = resultado.AsList()[0];
                return templatec;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaTemplateAsync(Template template)
        {
            try
            {
                var p = new
                {
                    ALTO = template.ALTO,
                    ANCHO = template.ANCHO,
                    CANTIDAD_REGIONES = template.CANTIDAD_REGIONES,
                    NOMBRE = template.NOMBRE,
                    USUARIO = template.USUARIO,
                    ID_ESTATUS = template.ID_ESTATUS
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Template.ALTATEMPLATE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaTemplateAsync(int ID_TEMPLATE, Template template)
        {
            try
            {
                var p = new
                {
                    ID_TEMPLATE = ID_TEMPLATE,
                    ALTO = template.ALTO,
                    ANCHO = template.ANCHO,
                    CANTIDAD_REGIONES = template.CANTIDAD_REGIONES,
                    NOMBRE = template.NOMBRE,
                    USUARIO = template.USUARIO,
                    ID_ESTATUS = template.ID_ESTATUS
                };
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Template.ACTULIZATEMPLATE, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Template>> ConsultaTemplateDirecoAsync(string Busqueda, int Pagina, int RegistroPorPagina)
        {
            try
            {
                Dictionary<int, Template> diccionarioTemplate = new Dictionary<int, Template>();
                var resultado = await conexion.QueryAsync<Template>(TextoSql.Template.CONSULTATEMPLATESDIRECTO,
                new[]{
                   typeof(Template),
                   typeof(Canal),
                   typeof(Contenido)
                },
                respuesta =>
                {
                    Template template;
                    Canal canal;
                    Contenido contenido;
                    if (!diccionarioTemplate.TryGetValue(((Template)respuesta[0]).ID_TEMPLATE, out template))
                    {
                        template = respuesta[0] as Template;
                        template.canal = new List<Canal>();
                        canal = respuesta[1] as Canal;
                        canal.contenidos = new List<Contenido>();
                        template.canal.Add(canal);
                        contenido = respuesta[2] as Contenido;
                        canal.contenidos.Add(contenido);
                        diccionarioTemplate.Add(template.ID_TEMPLATE, template);
                    }
                    return template;
                },
                splitOn: "ID_CANAL,ID_CONTENIDO"
                , param: new
                {
                    Busqueda,
                    Pagina,
                   RegistroPorPagina
                }
                );
                List<Template> listaTempate = new List<Template>();
                if (resultado.ToList().Count > 0)
                    listaTempate = resultado.Distinct().ToList();
                return listaTempate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ConsultaTotalTemplateDirectoAync()
        {
            try
            {
                var rspuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Template.CONSULTATOTALTEMPLATEDIRECTO);
                return rspuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> actulizaPreview(PreviewTemplate template)
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Preview.ACTULIZAPREVIEW, template, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PreviewTemplate> consultaPreviewID()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<PreviewTemplate>(TextoSql.Preview.CONSULTAPREVIEWS, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                PreviewTemplate consulta = new PreviewTemplate();
                if (respuesta.ToList().Count > 0)
                    consulta = respuesta.AsList()[0];
                return consulta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> InsertaPreview(int ID_TEMPLATE)
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Preview.INSERTAPREVIEW, param: new { ID_TEMPLATE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Template> ConsultaTemplateReproductorAsync(int ID_TEMPLATE)
        {
            try
            {
                Dictionary<int, Template> diccionarioTemplate = new Dictionary<int, Template>();
                var resultado = await conexion.QueryAsync<Template>(TextoSql.Template.CONSULTATEMPLATEREPRODUCTORES,
                new[]{
                   typeof(Template),
                   typeof(Reproductor)
                },
                respuesta =>
                {
                    Template template;
                    Reproductor reproductor;
                    if (!diccionarioTemplate.TryGetValue(((Template)respuesta[0]).ID_TEMPLATE, out template))
                    {
                        template = respuesta[0] as Template;
                        template.Reproductores = new List<Reproductor>();
                        diccionarioTemplate.Add(template.ID_TEMPLATE, template);
                    }
                    reproductor = respuesta[1] as Reproductor;
                    template.Reproductores.Add(reproductor);
                    return template;
                },
                splitOn: "ID_REPRODUCTOR"
                , param: new
                {
                    ID_TEMPLATE
                },
                transaction: unitOfWork.Transaccion
                );
                Template templatec = new Template();
                if (resultado.ToList().Count > 0)
                    templatec = resultado.AsList()[0];
                return templatec;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
