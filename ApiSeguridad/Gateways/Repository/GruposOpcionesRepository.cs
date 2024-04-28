using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class GruposOpcionesRepository : IGruposOpcionesRepository
    {
        readonly ApiSeguridadContext Context;

        public GruposOpcionesRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(GruposOpciones grupo)
        {
            string sp_api = "EXEC api_ActualizaGrupoOpcion @i_go_codigo, @i_go_orden, @i_go_descripcion, @i_go_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_go_codigo", Value = grupo.go_codigo},
                new SqlParameter { ParameterName = "@i_go_orden", Value = grupo.go_orden},
                new SqlParameter { ParameterName = "@i_go_descripcion", Value = grupo.go_descripcion},
                new SqlParameter { ParameterName = "@i_go_estado", Value = grupo.go_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = grupo.go_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<GruposOpciones> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaGrupoOpcion @i_go_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_go_codigo", Value = codigo}
            };

            return Context.GruposOpciones.FromSqlRaw<GruposOpciones>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(GruposOpciones grupo)
        {
            string sp_api = "EXEC api_IngresoGrupoOpcion @i_go_codigo, @i_go_orden, @i_go_descripcion, @i_go_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_go_codigo", Value = grupo.go_codigo},
                new SqlParameter { ParameterName = "@i_go_orden", Value = grupo.go_orden},
                new SqlParameter { ParameterName = "@i_go_descripcion", Value = grupo.go_descripcion},
                new SqlParameter { ParameterName = "@i_go_estado", Value = grupo.go_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = grupo.go_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
