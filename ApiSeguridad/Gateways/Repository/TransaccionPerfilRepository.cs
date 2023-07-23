using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class TransaccionPerfilRepository : ITransaccionPerfilRepository
    {
        readonly ApiSeguridadContext Context;

        public TransaccionPerfilRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(TransaccionPerfil transaccion)
        {
            string sp_api = "EXEC api_ActualizaTransaccionPerfil @i_tp_perfil, @i_tp_transaccion, @i_tp_grupo_opcion, @i_tp_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tp_perfil", Value = transaccion.tp_perfil},
                new SqlParameter { ParameterName = "@i_tp_transaccion", Value = transaccion.tp_transaccion},
                new SqlParameter { ParameterName = "@i_tp_grupo_opcion", Value = transaccion.tp_grupo_opcion},
                new SqlParameter { ParameterName = "@i_tp_estado", Value = transaccion.tp_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = transaccion.tp_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<TransaccionPerfil> Consulta(int perfil)
        {
            string sp_api = "EXEC api_ConsultaTransaccionPerfil @i_tp_perfil";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tp_perfil", Value = perfil}
            };

            return Context.TransaccionPerfil.FromSqlRaw<TransaccionPerfil>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Eliminacion(TransaccionPerfil transaccion)
        {
            string sp_api = "EXEC api_EliminaTransaccionPerfil @i_tp_perfil, @i_tp_transaccion, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tp_perfil", Value = transaccion.tp_perfil},
                new SqlParameter { ParameterName = "@i_tp_transaccion", Value = transaccion.tp_transaccion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(TransaccionPerfil transaccion)
        {
            string sp_api = "EXEC api_IngresoTransaccionPerfil @i_tp_perfil, @i_tp_transaccion, @i_tp_grupo_opcion, @i_tp_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tp_perfil", Value = transaccion.tp_perfil},
                new SqlParameter { ParameterName = "@i_tp_transaccion", Value = transaccion.tp_transaccion},
                new SqlParameter { ParameterName = "@i_tp_grupo_opcion", Value = transaccion.tp_grupo_opcion},
                new SqlParameter { ParameterName = "@i_tp_estado", Value = transaccion.tp_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = transaccion.tp_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
