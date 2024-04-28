using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class PerfilesRepository : IPerfilesRepository
    {
        readonly ApiSeguridadContext Context;

        public PerfilesRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Perfiles perfil)
        {
            string sp_api = "EXEC api_ActualizaPerfil @i_pe_codigo, @i_pe_descripcion, @i_pe_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_pe_codigo", Value = perfil.pe_codigo},
                new SqlParameter { ParameterName = "@i_pe_descripcion", Value = perfil.pe_descripcion},
                new SqlParameter { ParameterName = "@i_pe_estado", Value = perfil.pe_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = perfil.pe_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Perfiles> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaPerfil @i_pe_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_pe_codigo", Value = codigo}
            };

            return Context.Perfiles.FromSqlRaw<Perfiles>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Perfiles perfil)
        {
            string sp_api = "EXEC api_IngresoPerfil @i_pe_codigo, @i_pe_descripcion, @i_pe_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_pe_codigo", Value = perfil.pe_codigo},
                new SqlParameter { ParameterName = "@i_pe_descripcion", Value = perfil.pe_descripcion},
                new SqlParameter { ParameterName = "@i_pe_estado", Value = perfil.pe_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = perfil.pe_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
