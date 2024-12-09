using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iptv.AccesoDatos.Models;
using Dapper;
using System.Data;
using System.Linq;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<RepositorioDLNA> ContultarCatalogoRepositorioNombreAsync(string NOMBRE)
        {
            try
            {
                var resultado = await conexion.QueryAsync<RepositorioDLNA>(TextoSql.Repositorio.CONSULTACATALOGOREPOSITORRIONOMBRE, param: new { NOMBRE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                RepositorioDLNA repositorio = new RepositorioDLNA();
                if (resultado.ToList().Count > 0)
                    repositorio = resultado.AsList()[0];
                return repositorio;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarCatalogoRepositorioAsync(int ID_REPOSITORIO, string NOMBRE)
        {
            try
            {
                var resultado = await conexion.ExecuteAsync(TextoSql.Repositorio.ELIMINARCATALOGOREPOSITIRIO, param: new { ID_REPOSITORIO, NOMBRE }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<RepositorioDLNA> ConsultaCatalogoRepositorioAsync(int ID_REPOSITORIO)
        {
            try
            {
                var resultado = await conexion.QueryAsync<RepositorioDLNA>(TextoSql.Repositorio.CONSULTACATALOGOREPOSITORIO, param: new { ID_REPOSITORIO }, commandType: CommandType.StoredProcedure);
                RepositorioDLNA repositorio = new RepositorioDLNA();
                if (resultado.ToList().Count > 0)
                    repositorio = resultado.AsList()[0];
                return repositorio;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> EliminarRepositorioAsync(int ID_REPOSITORIO)
        {
            try
            {
                var resultado = await conexion.ExecuteAsync(TextoSql.Repositorio.ELIMINAREPOSITORIO, param: new { ID_REPOSITORIO }, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<List<Repositorio>> ConsultaRepositorioContenidoAsync(int ID_TIPO_CONTENIDO)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Repositorio>(TextoSql.Repositorio.CONSULTAPORIDTIPOCONTENIDO, param: new { ID_TIPO_CONTENIDO }, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaRepositorioAsync(Repositorio repositorio)
        {
            try
            {
                var p = new
                {
                    RUTA_ALOJAMIENTO = repositorio.RUTA_ALOJAMIENTO,
                    DESCRIPCION = repositorio.DESCRIPCION,
                    USUARIO = repositorio.USUARIO,
                    ID_TIPO_CONTENIDO = repositorio.ID_TIPO_CONTENIDO,
                    EXTENSION = repositorio.EXTENSION,
                    repositorio.DURACION,
                    ID_ESTATUS = repositorio.ID_ESTATUS
                };
                var resultado = await conexion.ExecuteScalarAsync<int>(TextoSql.Repositorio.ALTAREPOSITORIO, p, commandType: CommandType.StoredProcedure, transaction: unitOfWork.Transaccion);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Repositorio>> ConsultaRepositoriosAsync(string Busqueda, int ID_TIPO_CONTENIDO, int Pagina, int RegistrosPagina)
        {
            try
            {
                var p = new
                {
                    Busqueda = Busqueda,
                    ID_TIPO_CONTENIDO = ID_TIPO_CONTENIDO,
                    Pagina = Pagina,
                    RegistrosPorPagina = RegistrosPagina
                };
                var resultado = await conexion.QueryAsync<Repositorio>(TextoSql.Repositorio.CONSULTAREPOSITORIO, p, commandType: CommandType.StoredProcedure);
                return resultado.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Repositorio> ConsultaRepositorioId(int ID_REPOSITORIO)
        {
            try
            {
                var resultado = await conexion.QueryAsync<Repositorio>(TextoSql.Repositorio.CONSULTAREPOSITORIOID, param: new { ID_REPOSITORIO }, commandType: CommandType.StoredProcedure);
                Repositorio repositorio = new Repositorio();
                if (resultado.ToList().Count > 0)
                    repositorio = resultado.AsList()[0];
                return repositorio;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ObtenerTotalRepositoriosAsync()
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.Repositorio.TOTALREPOSITORIOS);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarCanalConRelacionesAsync(int canalId)
        {
            try
            {
                // Eliminar relaciones en TV_R_CANAL_CONTENIDO
                await conexion.ExecuteAsync(
                    "DELETE FROM TV_R_CANAL_CONTENIDO WHERE ID_CANAL = @CanalId",
                    new { CanalId = canalId },
                    commandType: CommandType.Text,
                    transaction: unitOfWork.Transaccion
                );

                // Eliminar relaciones en TV_R_TEMPLATE_CANAL
                await conexion.ExecuteAsync(
                    "DELETE FROM TV_R_TEMPLATE_CANAL WHERE ID_CANAL = @CanalId",
                    new { CanalId = canalId },
                    commandType: CommandType.Text,
                    transaction: unitOfWork.Transaccion
                );

                // Llamar al procedimiento para eliminar el canal
                var resultado = await conexion.ExecuteAsync(
                    "EXEC SPD_TV_D_CANAL @ID_CANAL",
                    new { ID_CANAL = canalId },
                    commandType: CommandType.StoredProcedure,
                    transaction: unitOfWork.Transaccion
                );

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarTemplateConRelacionesAsync(int templateId)
{
    try
    {
        // Eliminar relaciones en TV_R_TEMPLATE_CANAL
        await conexion.ExecuteAsync(
            "DELETE FROM TV_R_TEMPLATE_CANAL WHERE ID_TEMPLATE = @TemplateId",
            new { TemplateId = templateId },
            commandType: CommandType.Text,
            transaction: unitOfWork.Transaccion
        );

        // Llamar al procedimiento existente para eliminar la plantilla
        var resultado = await conexion.ExecuteAsync(
            "EXEC SPD_TV_D_TEMPLATES @ID_TEMPLATE",
            new { ID_TEMPLATE = templateId },
            commandType: CommandType.StoredProcedure,
            transaction: unitOfWork.Transaccion
        );

        return resultado;
    }
    catch (Exception ex)
    {
        throw;
    }
}

    }
}
