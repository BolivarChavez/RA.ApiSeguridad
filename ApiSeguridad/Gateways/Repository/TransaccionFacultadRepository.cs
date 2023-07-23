using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class TransaccionFacultadRepository : ITransaccionFacultadRepository
    {
        readonly ApiSeguridadContext Context;

        public TransaccionFacultadRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(TransaccionFacultad transaccion)
        {
            string sp_api = "EXEC api_ActualizaTransaccionFacultad @i_tf_transaccion, @i_tf_facultad, @i_tf_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tf_transaccion", Value = transaccion.tf_transaccion},
                new SqlParameter { ParameterName = "@i_tf_facultad", Value = transaccion.tf_facultad},
                new SqlParameter { ParameterName = "@i_tf_estado", Value = transaccion.tf_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = transaccion.tf_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<TransaccionFacultad> Consulta(int transaccion)
        {
            string sp_api = "EXEC api_ConsultaTransaccionFacultad @i_tf_transaccion";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tf_transaccion", Value = transaccion}
            };

            return Context.TransaccionFacultad.FromSqlRaw<TransaccionFacultad>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Eliminacion(TransaccionFacultad transaccion)
        {
            string sp_api = "EXEC api_EliminaTransaccionFacultad @i_tf_transaccion, @i_tf_facultad, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tf_transaccion", Value = transaccion.tf_transaccion},
                new SqlParameter { ParameterName = "@i_tf_facultad", Value = transaccion.tf_facultad},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(TransaccionFacultad transaccion)
        {
            string sp_api = "EXEC api_IngresoTransaccionFacultad @i_tf_transaccion, @i_tf_facultad, @i_tf_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_tf_transaccion", Value = transaccion.tf_transaccion},
                new SqlParameter { ParameterName = "@i_tf_facultad", Value = transaccion.tf_facultad},
                new SqlParameter { ParameterName = "@i_tf_estado", Value = transaccion.tf_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = transaccion.tf_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
