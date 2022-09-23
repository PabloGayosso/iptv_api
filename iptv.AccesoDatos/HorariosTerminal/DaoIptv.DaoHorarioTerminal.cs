using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Linq;
using iptv.AccesoDatos.Models;

namespace iptv.AccesoDatos
{
    public partial class DaoIptv : IDaoIptv
    {
        public async Task<int> AltaHorarioTerminal(HorarioTerminal horariosTerminal)
        {
            try
            {
                var respuesta = await conexion.ExecuteScalarAsync<int>(TextoSql.HorarioTerminal.ALTAHORARIO, horariosTerminal, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> ActulizaHorarioTerminal(HorarioTerminal horariosTerminal)
        {
            try
            {
                var respuesta = await conexion.ExecuteAsync(TextoSql.HorarioTerminal.ACTULIZAHORARIO, horariosTerminal, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AltaGrupoHorario(int ID_HORARIO, int ID_GRUPO, string USUARIO)
        {
            try
            {
                var respuesta = await conexion.ExecuteAsync(TextoSql.HorarioTerminal.ALTAHORARIOGRUPO, param: new { ID_GRUPO, ID_HORARIO, USUARIO }, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> EliminarHorarioGrupo(int ID_GRUPO)
        {
            try
            {
                var respuesta = await conexion.ExecuteAsync(TextoSql.HorarioTerminal.ELIMINARHORARIOGRUPO, param: new { ID_GRUPO }, transaction: unitOfWork.Transaccion);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<HorarioTerminal> ConsultaHorariosGrupos(int ID_GRUPO)
        {
            try
            {
                Dictionary<int, HorarioTerminal> diccionarioHorario = new Dictionary<int, HorarioTerminal>();
                var resultado = await conexion.QueryAsync<HorarioTerminal>(TextoSql.HorarioTerminal.CONSULTAHORARIOGRUPO,
                new[]{
                   typeof(HorarioTerminal),
                   typeof(Grupo)
                },
                respuesta =>
                {
                    HorarioTerminal horario;
                    Grupo grupo;
                    if (!diccionarioHorario.TryGetValue(((HorarioTerminal)respuesta[0]).IdTvHorarioTerminal, out horario))
                    {
                        horario = respuesta[0] as HorarioTerminal;
                        horario.grupo = new Grupo();
                        diccionarioHorario.Add(horario.IdTvHorarioTerminal, horario);
                    }
                    grupo = respuesta[1] as Grupo;
                    horario.grupo = grupo;
                    return horario;
                },
                splitOn: "ID_GRUPO"
                , param: new
                {
                    ID_GRUPO
                }
                );
                HorarioTerminal horarioTerminal = new HorarioTerminal();
                if (resultado.ToList().Count > 0)
                    horarioTerminal = resultado.AsList()[0];
                return horarioTerminal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<HorarioTerminal>> ConsultaHorariosTerminal()
        {
            try
            {
                var respuesta = await conexion.QueryAsync<HorarioTerminal>(TextoSql.HorarioTerminal.CONSULTAHORARIOS);
                return respuesta.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
