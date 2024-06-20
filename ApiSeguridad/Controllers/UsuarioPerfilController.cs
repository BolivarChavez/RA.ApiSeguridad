using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioPerfilController : Controller
    {
        private readonly IUsuarioPerfilRepository _repository;
        public UsuarioPerfilController(IUsuarioPerfilRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Asocia un perfil a un usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// up_perfil : Codigo del perfil <br />
        /// up_usuario : Codigo del usuario <br />
        /// up_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_IngresoUsuarioPerfil
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] UsuarioPerfil perfil)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(perfil).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza el estado del perfil asociado al usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// up_perfil : Codigo del perfil <br />
        /// up_usuario : Codigo del usuario <br />
        /// up_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_ActualizaUsuarioPerfil
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] UsuarioPerfil perfil)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(perfil).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Elimina un perfil previamente asignado a un usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// up_perfil : Codigo del perfil <br />
        /// up_usuario : Codigo del usuario <br />
        /// Procedimiento almacenado : api_EliminaUsuarioPerfil
        /// </remarks>
        [HttpPost]
        [Route("Eliminacion")]
        public async Task<string> Eliminacion([FromBody] UsuarioPerfil perfil)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Eliminacion(perfil).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los perfiles (de transacciones autorizadas) asociados a un usuario 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// usuario : Codigo del usuario <br />
        /// Procedimiento almacenado : api_ConsultaUsuarioPerfil
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{usuario}")]
        public IEnumerable<UsuarioPerfil> Get(int usuario)
        {
            List<UsuarioPerfil> list_perfil;
            string JSONString = string.Empty;

            list_perfil = _repository.Consulta(usuario).ToList();
            return list_perfil;
        }
    }
}
