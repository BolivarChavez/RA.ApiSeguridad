using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class UsuarioFacultadRepository : IUsuarioFacultadRepository
    {
        readonly ApiSeguridadContext Context;

        public UsuarioFacultadRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(UsuarioFacultad facultad)
        {
            string sp_api = "EXEC api_ActualizaUsuarioFacultad @i_uf_usuario, @i_uf_transaccion, @i_uf_facultad, @i_uf_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uf_usuario", Value = facultad.uf_usuario},
                new SqlParameter { ParameterName = "@i_uf_transaccion", Value = facultad.uf_transaccion},
                new SqlParameter { ParameterName = "@i_uf_facultad", Value = facultad.uf_facultad},
                new SqlParameter { ParameterName = "@i_uf_estado", Value = facultad.uf_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = facultad.uf_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<UsuarioFacultad> Consulta(int usuario, int transaccion)
        {
            string sp_api = "EXEC api_ConsultaUsuarioFacultad @i_uf_usuario, @i_uf_transaccion";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uf_usuario", Value = usuario},
                new SqlParameter { ParameterName = "@i_uf_transaccion", Value = transaccion}
            };

            return Context.UsuarioFacultad.FromSqlRaw<UsuarioFacultad>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Eliminacion(UsuarioFacultad facultad)
        {
            string sp_api = "EXEC api_EliminaUsuarioFacultad @i_uf_usuario, @i_uf_transaccion, @i_uf_facultad, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uf_usuario", Value = facultad.uf_usuario},
                new SqlParameter { ParameterName = "@i_uf_transaccion", Value = facultad.uf_transaccion},
                new SqlParameter { ParameterName = "@i_uf_facultad", Value = facultad.uf_facultad},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(UsuarioFacultad facultad)
        {
            string sp_api = "EXEC api_IngresoUsuarioFacultad @i_uf_usuario, @i_uf_transaccion, @i_uf_facultad, @i_uf_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uf_usuario", Value = facultad.uf_usuario},
                new SqlParameter { ParameterName = "@i_uf_transaccion", Value = facultad.uf_transaccion},
                new SqlParameter { ParameterName = "@i_uf_facultad", Value = facultad.uf_facultad},
                new SqlParameter { ParameterName = "@i_uf_estado", Value = facultad.uf_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = facultad.uf_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
