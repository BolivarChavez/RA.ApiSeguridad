using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerfilesController : Controller
    {
        private readonly IPerfilesRepository _repository;
        public PerfilesController(IPerfilesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Perfiles perfil)
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
        public async Task<string> Actualizacion([FromBody] Perfiles perfil)
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

        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<Perfiles> Get(int codigo)
        {
            List<Perfiles> list_perfil;
            string JSONString = string.Empty;

            list_perfil = _repository.Consulta(codigo).ToList();
            return list_perfil;
        }
    }
}
