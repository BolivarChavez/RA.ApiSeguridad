using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class TransaccionesRepository : ITransaccionesRepository
    {
        readonly ApiSeguridadContext Context;

        public TransaccionesRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Transacciones transaccion)
        {
            string sp_api = "EXEC api_ActualizaTransaccion @i_tr_codigo, @i_tr_descripcion, @i_tr_tipo, @i_tr_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tr_codigo", Value = transaccion.tr_codigo},
                new SqlParameter { ParameterName = "@i_tr_descripcion", Value = transaccion.tr_descripcion},
                new SqlParameter { ParameterName = "@i_tr_tipo", Value = transaccion.tr_tipo},
                new SqlParameter { ParameterName = "@i_tr_estado", Value = transaccion.tr_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = transaccion.tr_usuario_ceacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Transacciones> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaTransaccion @i_tr_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tr_codigo", Value = codigo}
            };

            return Context.Transacciones.FromSqlRaw<Transacciones>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Transacciones transaccion)
        {
            string sp_api = "EXEC api_IngresoTransaccion @i_tr_codigo, @i_tr_descripcion, @i_tr_tipo, @i_tr_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tr_codigo", Value = transaccion.tr_codigo},
                new SqlParameter { ParameterName = "@i_tr_descripcion", Value = transaccion.tr_descripcion},
                new SqlParameter { ParameterName = "@i_tr_tipo", Value = transaccion.tr_tipo},
                new SqlParameter { ParameterName = "@i_tr_estado", Value = transaccion.tr_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = transaccion.tr_usuario_ceacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
