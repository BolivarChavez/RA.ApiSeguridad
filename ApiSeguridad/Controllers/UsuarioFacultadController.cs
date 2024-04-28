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
