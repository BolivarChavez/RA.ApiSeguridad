using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransaccionesController : Controller
    {
        private readonly ITransaccionesRepository _repository;
        public TransaccionesController(ITransaccionesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Insertar un nuevo registro de transaccion en la tabla Transacciones 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tr_codigo : Codigo de la transaccion, cero (0) para nueva transaccion <br />
        /// tr_descripcion : Nombre o descripcion de la transaccion <br />
        /// tr_descripcion_larga : Descripcion mas detallada <br />
        /// tr_tipo : Tipo de transaccion [A] Acceso a opcion, [P] Permiso de uso <br />
        /// tr_programa : Nombre del programa asociado a la transaccionn <br />
        /// tr_estado: Estado de la transaccion [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_IngresoTransaccion
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Transacciones transaccion)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(transaccion).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualizar registro de transaccion en la tabla Transacciones 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// tr_codigo : Codigo de la transaccion <br />
        /// tr_descripcion : Nombre o descripcion de la transaccion <br />
        /// tr_descripcion_larga : Descripcion mas detallada <br />
        /// tr_tipo : Tipo de transaccion [A] Acceso a opcion, [P] Permiso de uso <br />
        /// tr_programa : Nombre del programa asociado a la transaccionn <br />
        /// tr_estado: Estado de la transaccion [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_ActualizaTransaccion
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Transacciones transaccion)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(transaccion).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta registros de transacciones ingresadas en la tabla Transacciones 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo de la transaccion. Para consultar todas las transacciones colocar cero (0) <br />
        /// Procedimiento almacenado : api_ConsultaTransaccion
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<Transacciones> Get(int codigo)
        {
            List<Transacciones> list_transaccion;
            string JSONString = string.Empty;

            list_transaccion = _repository.Consulta(codigo).ToList();
            return list_transaccion;
        }
    }
}
