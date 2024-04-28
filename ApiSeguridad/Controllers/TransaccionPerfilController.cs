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
