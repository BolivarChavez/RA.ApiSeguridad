using ApiSeguridad.Gateways.DataContext;
using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiSeguridad.Gateways.Repository
{
    public class UsuarioPerfilRepository : IUsuarioPerfilRepository
    {
        readonly ApiSeguridadContext Context;

        public UsuarioPerfilRepository(ApiSeguridadContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(UsuarioPerfil perfil)
        {
            string sp_api = "EXEC api_ActualizaUsuarioPerfil @i_up_perfil, @i_up_usuario, @i_up_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_up_perfil", Value = perfil.up_perfil},
                new SqlParameter { ParameterName = "@i_up_usuario", Value = perfil.up_usuario},
                new SqlParameter { ParameterName = "@i_up_estado", Value = perfil.up_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = perfil.up_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<UsuarioPerfil> Consulta(int usuario)
        {
            string sp_api = "EXEC api_ConsultaUsuarioPerfil @i_up_usuario";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_up_usuario", Value = usuario}            };

            return Context.UsuarioPerfil.FromSqlRaw<UsuarioPerfil>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Eliminacion(UsuarioPerfil perfil)
        {
            string sp_api = "EXEC api_EliminaUsuarioPerfil @i_up_perfil, @i_up_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_up_perfil", Value = perfil.up_perfil},
                new SqlParameter { ParameterName = "@i_up_usuario", Value = perfil.up_usuario},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(UsuarioPerfil perfil)
        {
            string sp_api = "EXEC api_IngresoUsuarioPerfil @i_up_perfil, @i_up_usuario, @i_up_estado, @i_usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_up_perfil", Value = perfil.up_perfil},
                new SqlParameter { ParameterName = "@i_up_usuario", Value = perfil.up_usuario},
                new SqlParameter { ParameterName = "@i_up_estado", Value = perfil.up_estado},
                new SqlParameter { ParameterName = "@i_usuario", Value = perfil.up_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
