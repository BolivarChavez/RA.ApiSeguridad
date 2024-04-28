using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class FacultadesRepository : IFacultadesRepository
    {
        readonly ApiSeguridadContext Context;

        public FacultadesRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Facultades facultad)
        {
            string sp_api = "EXEC api_ActualizaFacultad @i_fa_codigo, @i_fa_descripcion, @i_fa_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_fa_codigo", Value = facultad.fa_codigo},
                new SqlParameter { ParameterName = "@i_fa_descripcion", Value = facultad.fa_descripcion},
                new SqlParameter { ParameterName = "@i_fa_estado", Value = facultad.fa_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = facultad.fa_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Facultades> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaFacultad @i_fa_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_fa_codigo", Value = codigo}
            };

            return Context.Facultades.FromSqlRaw<Facultades>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Facultades facultad)
        {
            string sp_api = "EXEC api_IngresoFacultad @i_fa_codigo, @i_fa_descripcion, @i_fa_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_fa_codigo", Value = facultad.fa_codigo},
                new SqlParameter { ParameterName = "@i_fa_descripcion", Value = facultad.fa_descripcion},
                new SqlParameter { ParameterName = "@i_fa_estado", Value = facultad.fa_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = facultad.fa_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
