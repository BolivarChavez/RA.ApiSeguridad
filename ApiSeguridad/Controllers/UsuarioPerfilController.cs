using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioPerfilController : Controller
    {
        private readonly IUsuarioPerfilRepository _repository;
        public UsuarioPerfilController(IUsuarioPerfilRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] UsuarioPerfil perfil)
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
        public async Task<string> Actualizacion([FromBody] UsuarioPerfil perfil)
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
        public async Task<string> Eliminacion([FromBody] UsuarioPerfil perfil)
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
        [Route("Consulta")]
        public IEnumerable<UsuarioPerfil> Get(int usuario)
        {
            List<UsuarioPerfil> list_perfil;
            string JSONString = string.Empty;

            list_perfil = _repository.Consulta(usuario).ToList();
            return list_perfil;
        }
    }
}
