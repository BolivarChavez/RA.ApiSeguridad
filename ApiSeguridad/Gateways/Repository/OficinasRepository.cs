using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class OficinasRepository : IOficinasRepository
    {
        readonly ApiSeguridadContext Context;

        public OficinasRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Oficinas oficina)
        {
            string sp_api = "EXEC api_ActualizaOficina @i_of_empresa, @i_of_codigo, @i_of_nombre, @i_of_pais, @i_of_provincia, @i_of_ciudad, @i_of_direccion, @i_of_telefono, @i_of_contacto, @i_of_email, @i_of_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_of_empresa", Value = oficina.of_empresa},
                new SqlParameter { ParameterName = "@i_of_codigo", Value = oficina.of_codigo},
                new SqlParameter { ParameterName = "@i_of_nombre", Value = oficina.of_nombre},
                new SqlParameter { ParameterName = "@i_of_pais", Value = oficina.of_pais},
                new SqlParameter { ParameterName = "@i_of_provincia", Value = oficina.of_provincia},
                new SqlParameter { ParameterName = "@i_of_ciudad", Value = oficina.of_ciudad},
                new SqlParameter { ParameterName = "@i_of_direccion", Value = oficina.of_direccion},
                new SqlParameter { ParameterName = "@i_of_telefono", Value = oficina.of_telefono},
                new SqlParameter { ParameterName = "@i_of_contacto", Value = oficina.of_contacto},
                new SqlParameter { ParameterName = "@i_of_email", Value = oficina.of_email},
                new SqlParameter { ParameterName = "@i_of_estado", Value = oficina.of_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = oficina.of_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Oficinas> Consulta(int empresa, int codigo)
        {
            string sp_api = "EXEC api_ConsultaOficina @i_of_empresa, @i_of_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_of_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_of_codigo", Value = codigo}
            };

            return Context.Oficinas.FromSqlRaw<Oficinas>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Oficinas oficina)
        {
            string sp_api = "EXEC api_IngresoOficina @i_of_empresa, @i_of_codigo, @i_of_nombre, @i_of_pais, @i_of_provincia, @i_of_ciudad, @i_of_direccion, @i_of_telefono, @i_of_contacto, @i_of_email, @i_of_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_of_empresa", Value = oficina.of_empresa},
                new SqlParameter { ParameterName = "@i_of_codigo", Value = oficina.of_codigo},
                new SqlParameter { ParameterName = "@i_of_nombre", Value = oficina.of_nombre},
                new SqlParameter { ParameterName = "@i_of_pais", Value = oficina.of_pais},
                new SqlParameter { ParameterName = "@i_of_provincia", Value = oficina.of_provincia},
                new SqlParameter { ParameterName = "@i_of_ciudad", Value = oficina.of_ciudad},
                new SqlParameter { ParameterName = "@i_of_direccion", Value = oficina.of_direccion},
                new SqlParameter { ParameterName = "@i_of_telefono", Value = oficina.of_telefono},
                new SqlParameter { ParameterName = "@i_of_contacto", Value = oficina.of_contacto},
                new SqlParameter { ParameterName = "@i_of_email", Value = oficina.of_email},
                new SqlParameter { ParameterName = "@i_of_estado", Value = oficina.of_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = oficina.of_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
