using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioFacultadController : Controller
    {
        private readonly IUsuarioFacultadRepository _repository;
        public UsuarioFacultadController(IUsuarioFacultadRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Asocia una facultad a una transaccion relacionada a un perfil de usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// uf_usuario : Codigo del usuario <br />
        /// uf_transaccion : Codigo de la transacción <br />
        /// uf_facultad : Codigo de la facultad <br />
        /// uf_estado : Estado del registro [A] Activo, [I] Inactivo <br />
        /// Procedimiento almacenado : api_IngresoUsuarioFacultad
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] UsuarioFacultad facultad)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(facultad).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza el estado de la facultad asociada a una transaccion
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// uf_usuario : Codigo del usuario <br />
        /// uf_transaccion : Codigo de la transacción <br />
        /// uf_facultad : Codigo de la facultad <br />
        /// uf_estado : Estado del registro [A] Activo, [I] Inactivo <br />
        /// Procedimiento almacenado : api_ActualizaUsuarioFacultad
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] UsuarioFacultad facultad)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(facultad).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Elimina una facultad asociada a una transaccion de usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// uf_usuario : Codigo del usuario <br />
        /// uf_transaccion : Codigo de la transacción <br />
        /// uf_facultad : Codigo de la facultad <br />
        /// Procedimiento almacenado : api_EliminaUsuarioFacultad
        /// </remarks>
        [HttpPost]
        [Route("Eliminacion")]
        public async Task<string> Eliminacion([FromBody] UsuarioFacultad facultad)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Eliminacion(facultad).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta las facultades de una transaccion asociada a un usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// usuario : Codigo del usuario <br />
        /// transaccion : Codigo de la transacción <br />
        /// Procedimiento almacenado : api_ConsultaUsuarioFacultad
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{usuario}/{transaccion}")]
        public IEnumerable<UsuarioFacultad> Get(int usuario, int transaccion)
        {
            List<UsuarioFacultad> list_facultad;
            string JSONString = string.Empty;

            list_facultad = _repository.Consulta(usuario, transaccion).ToList();
            return list_facultad;
        }
    }
}
