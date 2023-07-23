using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridad.Gateways.Repository
{
    public class EmpresasRepository : IEmpresasRepository
    {
        readonly ApiSeguridadContext Context;

        public EmpresasRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Empresas empresa)
        {
            string sp_api = "EXEC api_ActualizaEmpresa @i_em_codigo, @i_em_nombre, @i_em_pais, @i_em_provincia, @i_em_ciudad, @i_em_direccion, @i_em_telefono, @i_em_contacto, @i_em_email, @i_em_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_em_codigo", Value = empresa.em_codigo},
                new SqlParameter { ParameterName = "@i_em_nombre", Value = empresa.em_nombre},
                new SqlParameter { ParameterName = "@i_em_pais", Value = empresa.em_pais},
                new SqlParameter { ParameterName = "@i_em_provincia", Value = empresa.em_provincia},
                new SqlParameter { ParameterName = "@i_em_ciudad", Value = empresa.em_ciudad},
                new SqlParameter { ParameterName = "@i_em_direccion", Value = empresa.em_direccion},
                new SqlParameter { ParameterName = "@i_em_telefono", Value = empresa.em_telefono},
                new SqlParameter { ParameterName = "@i_em_contacto", Value = empresa.em_contacto},
                new SqlParameter { ParameterName = "@i_em_email", Value = empresa.em_email},
                new SqlParameter { ParameterName = "@i_em_estado", Value = empresa.em_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = empresa.em_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Empresas> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaEmpresa @i_em_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_em_codigo", Value = codigo}
            };

            return Context.Empresas.FromSqlRaw<Empresas>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Empresas empresa)
        {
            string sp_api = "EXEC api_IngresoEmpresa @i_em_codigo, @i_em_nombre, @i_em_pais, @i_em_provincia, @i_em_ciudad, @i_em_direccion, @i_em_telefono, @i_em_contacto, @i_em_email, @i_em_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_em_codigo", Value = empresa.em_codigo},
                new SqlParameter { ParameterName = "@i_em_nombre", Value = empresa.em_nombre},
                new SqlParameter { ParameterName = "@i_em_pais", Value = empresa.em_pais},
                new SqlParameter { ParameterName = "@i_em_provincia", Value = empresa.em_provincia},
                new SqlParameter { ParameterName = "@i_em_ciudad", Value = empresa.em_ciudad},
                new SqlParameter { ParameterName = "@i_em_direccion", Value = empresa.em_direccion},
                new SqlParameter { ParameterName = "@i_em_telefono", Value = empresa.em_telefono},
                new SqlParameter { ParameterName = "@i_em_contacto", Value = empresa.em_contacto},
                new SqlParameter { ParameterName = "@i_em_email", Value = empresa.em_email},
                new SqlParameter { ParameterName = "@i_em_estado", Value = empresa.em_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = empresa.em_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
