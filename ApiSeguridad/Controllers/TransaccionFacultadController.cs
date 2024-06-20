using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransaccionFacultadController : Controller
    {
        private readonly ITransaccionFacultadRepository _repository;
        public TransaccionFacultadController(ITransaccionFacultadRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingreso de una facultad relacionada a una transaccion 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tf_transaccion : Codigo de la transaccion <br />
        /// tf_facultad : Codigo de la facultad <br />
        /// tf_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_IngresoTransaccionFacultad
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] TransaccionFacultad facultad)
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
        /// Actualiza el estado de una facultad ya asociada a una transaccion 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tf_transaccion : Codigo de la transaccion <br />
        /// tf_facultad : Codigo de la facultad <br />
        /// tf_estado : Estado del registro [A] Activo, [I] Inactivo <br /><br />
        /// Procedimiento almacenado : api_ActualizaTransaccionFacultad
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] TransaccionFacultad facultad)
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
        /// Elimina una facultad asociada a una transaccion 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tf_transaccion : Codigo de la transaccion <br />
        /// tf_facultad : Codigo de la facultad <br />
        /// Procedimiento almacenado : api_EliminaTransaccionFacultad
        /// </remarks>
        [HttpPost]
        [Route("Eliminacion")]
        public async Task<string> Eliminacion([FromBody] TransaccionFacultad facultad)
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
        /// Consulta las facultades asociadas a una transaccion 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// transaccion : Codigo de la transaccion <br />
        /// Procedimiento almacenado : api_ConsultaTransaccionFacultad
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{transaccion}")]
        public IEnumerable<TransaccionFacultad> Get(int transaccion)
        {
            List<TransaccionFacultad> list_facultad;
            string JSONString = string.Empty;

            list_facultad = _repository.Consulta(transaccion).ToList();
            return list_facultad;
        }
    }
}
