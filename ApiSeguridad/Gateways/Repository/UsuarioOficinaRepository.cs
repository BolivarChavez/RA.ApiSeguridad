using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class UsuarioOficinaRepository : IUsuarioOficinaRepository
    {
        readonly ApiSeguridadContext Context;

        public UsuarioOficinaRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(UsuarioOficina oficina)
        {
            string sp_api = "EXEC api_ActualizaUsuarioOficina @i_uo_usuario, @i_uo_empresa, @i_uo_oficina, @i_uo_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uo_usuario", Value = oficina.uo_usuario},
                new SqlParameter { ParameterName = "@i_uo_empresa", Value = oficina.uo_empresa},
                new SqlParameter { ParameterName = "@i_uo_oficina", Value = oficina.uo_oficina},
                new SqlParameter { ParameterName = "@i_uo_estado", Value = oficina.uo_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = oficina.uo_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<UsuarioOficina> Consulta(int usuario, int empresa)
        {
            string sp_api = "EXEC api_ConsultaUsuarioOficina @i_uo_usuario, @i_uo_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uo_usuario", Value = usuario},
                new SqlParameter { ParameterName = "@i_uo_empresa", Value = empresa}
            };

            return Context.UsuarioOficina.FromSqlRaw<UsuarioOficina>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Eliminacion(UsuarioOficina oficina)
        {
            string sp_api = "EXEC api_EliminaUsuarioOficina @i_uo_usuario, @i_uo_empresa, @i_uo_oficina, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uo_usuario", Value = oficina.uo_usuario},
                new SqlParameter { ParameterName = "@i_uo_empresa", Value = oficina.uo_empresa},
                new SqlParameter { ParameterName = "@i_uo_oficina", Value = oficina.uo_oficina},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(UsuarioOficina oficina)
        {
            string sp_api = "EXEC api_IngresoUsuarioOficina @i_uo_usuario, @i_uo_empresa, @i_uo_oficina, @i_uo_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_uo_usuario", Value = oficina.uo_usuario},
                new SqlParameter { ParameterName = "@i_uo_empresa", Value = oficina.uo_empresa},
                new SqlParameter { ParameterName = "@i_uo_oficina", Value = oficina.uo_oficina},
                new SqlParameter { ParameterName = "@i_uo_estado", Value = oficina.uo_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = oficina.uo_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
