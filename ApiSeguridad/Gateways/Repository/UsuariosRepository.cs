using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        readonly ApiSeguridadContext Context;

        public UsuariosRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Usuarios usuario)
        {
            string sp_api = "EXEC api_ActualizaUsuario @i_us_codigo, @i_us_nombre, @i_us_login, @i_us_password, @i_us_email, @i_us_ingresos, @i_us_ultimo_ingreso, @i_us_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_us_codigo", Value = usuario.us_codigo},
                new SqlParameter { ParameterName = "@i_us_nombre", Value = usuario.us_nombre},
                new SqlParameter { ParameterName = "@i_us_login", Value = usuario.us_login},
                new SqlParameter { ParameterName = "@i_us_password", Value = usuario.us_password},
                new SqlParameter { ParameterName = "@i_us_email", Value = usuario.us_email},
                new SqlParameter { ParameterName = "@i_us_ingresos", Value = usuario.us_ingresos},
                new SqlParameter { ParameterName = "@i_us_ultimo_ingreso", Value = usuario.us_ultimo_ingreso},
                new SqlParameter { ParameterName = "@i_us_estado", Value = usuario.us_estado},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Usuarios> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaUsuario @i_us_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_us_codigo", Value = codigo}
            };

            return Context.Usuarios.FromSqlRaw<Usuarios>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<UsuarioGrupoOpciones> ConsultaGrupoOpcion(int usuario)
        {
            string sp_api = "EXEC api_ConsultaUsuarioGrupoOpciones @i_up_usuario";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_up_usuario", Value = usuario}
            };

            return Context.UsuarioGrupoOpciones.FromSqlRaw<UsuarioGrupoOpciones>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<TransaccionesUsuario> ConsultaTransacciones(int usuario, int grupo)
        {
            string sp_api = "EXEC api_ConsultaTransaccionesUsuario @i_up_usuario, @i_go_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_up_usuario", Value = usuario},
                new SqlParameter { ParameterName = "@i_go_codigo", Value = grupo}
            };

            return Context.TransaccionesUsuario.FromSqlRaw<TransaccionesUsuario>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Usuarios usuario)
        {
            string sp_api = "EXEC api_IngresoUsuario @i_us_codigo, @i_us_nombre, @i_us_login, @i_us_password, @i_us_email, @i_us_ingresos, @i_us_ultimo_ingreso, @i_us_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_us_codigo", Value = usuario.us_codigo},
                new SqlParameter { ParameterName = "@i_us_nombre", Value = usuario.us_nombre},
                new SqlParameter { ParameterName = "@i_us_login", Value = usuario.us_login},
                new SqlParameter { ParameterName = "@i_us_password", Value = usuario.us_password},
                new SqlParameter { ParameterName = "@i_us_email", Value = usuario.us_email},
                new SqlParameter { ParameterName = "@i_us_ingresos", Value = usuario.us_ingresos},
                new SqlParameter { ParameterName = "@i_us_ultimo_ingreso", Value = usuario.us_ultimo_ingreso},
                new SqlParameter { ParameterName = "@i_us_estado", Value = usuario.us_estado},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> ProcesaLogin(LoginUsuario usuario)
        {
            string sp_api = "EXEC api_ProcesaLogin @i_usuario, @i_password, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_usuario", Value = usuario.usuario},
                new SqlParameter { ParameterName = "@i_password", Value = usuario.password},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
