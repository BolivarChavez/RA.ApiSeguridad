using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransaccionPerfilController : Controller
    {
        private readonly ITransaccionPerfilRepository _repository;
        public TransaccionPerfilController(ITransaccionPerfilRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Asocia una transaccion a un perfil
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tp_perfil : Codigo del perfil <br />
        /// tp_transaccion : Codigo de la transacción <br />
        /// tp_grupo_opcion : Codigo del grupo de opciones <br />
        /// tp_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_IngresoTransaccionPerfil
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] TransaccionPerfil perfil)
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
        /// Actualiza el estado y el grupo de opciones de una transaccion asociada a un perfil
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tp_perfil : Codigo del perfil <br />
        /// tp_transaccion : Codigo de la transacción <br />
        /// tp_grupo_opcion : Codigo del grupo de opciones <br />
        /// tp_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_ActualizaTransaccionPerfil
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] TransaccionPerfil perfil)
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
        /// Elimina transaccion previamente asignada a un perfil
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tp_perfil : Codigo del perfil <br />
        /// tp_transaccion : Codigo de la transacción <br />
        /// Procedimiento almacenado : api_EliminaTransaccionPerfil
        /// </remarks>
        [HttpPost]
        [Route("Eliminacion")]
        public async Task<string> Eliminacion([FromBody] TransaccionPerfil perfil)
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
        /// Consulta las transacciones asociadas a un perfil
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// perfil : Codigo del perfil <br />
        /// Procedimiento almacenado : api_ConsultaTransaccionPerfil
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{perfil}")]
        public IEnumerable<TransaccionPerfil> Get(int perfil)
        {
            List<TransaccionPerfil> list_transaccion;
            string JSONString = string.Empty;

            list_transaccion = _repository.Consulta(perfil).ToList();
            return list_transaccion;
        }
    }
}
