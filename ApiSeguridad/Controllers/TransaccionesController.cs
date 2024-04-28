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
