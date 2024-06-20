using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioOficinaController : Controller
    {
        private readonly IUsuarioOficinaRepository _repository;
        public UsuarioOficinaController(IUsuarioOficinaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Asocia una oficina al usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// uo_usuario : Codigo del usuario <br />
        /// uo_empresa : Codigo de la empresa <br />
        /// uo_oficina : Codigo de la oficina <br />
        /// uo_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_IngresoUsuarioOficina
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] UsuarioOficina oficina)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(oficina).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza el estado de la oficina asociada al usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// uo_usuario : Codigo del usuario <br />
        /// uo_empresa : Codigo de la empresa <br />
        /// uo_oficina : Codigo de la oficina <br />
        /// uo_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_ActualizaUsuarioOficina
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] UsuarioOficina oficina)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(oficina).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Elimina una oficina previamente asignada a un usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// uo_usuario : Codigo del usuario <br />
        /// uo_empresa : Codigo de la empresa <br />
        /// uo_oficina : Codigo de la oficina <br />
        /// Procedimiento almacenado : api_EliminaUsuarioOficina
        /// </remarks>
        [HttpPost]
        [Route("Eliminacion")]
        public async Task<string> Eliminacion([FromBody] UsuarioOficina oficina)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Eliminacion(oficina).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta las oficinas a las que tienen acceso el usuario, una vez que se haya seleccionado
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// usuario : Codigo del usuario <br />
        /// empresa : Codigo de la empresa <br />
        /// Procedimiento almacenado : api_ConsultaUsuarioOficina
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{usuario}/{empresa}")]
        public IEnumerable<UsuarioOficina> Get(int usuario, int empresa)
        {
            List<UsuarioOficina> list_oficina;
            string JSONString = string.Empty;

            list_oficina = _repository.Consulta(usuario, empresa).ToList();
            return list_oficina;
        }
    }
}
