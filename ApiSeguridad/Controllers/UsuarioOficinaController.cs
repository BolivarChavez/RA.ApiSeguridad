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
