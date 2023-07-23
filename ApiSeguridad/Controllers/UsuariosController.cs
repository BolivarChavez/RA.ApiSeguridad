using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepository _repository;
        public UsuariosController(IUsuariosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Usuarios usuario)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(usuario).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Usuarios usuario)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(usuario).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpGet]
        [Route("Consulta")]
        public IEnumerable<Usuarios> Get(int codigo)
        {
            List<Usuarios> list_usuario;
            string JSONString = string.Empty;

            list_usuario = _repository.Consulta(codigo).ToList();
            return list_usuario;
        }

        [HttpGet]
        [Route("ConsultaGrupoOpcion")]
        public IEnumerable<UsuarioGrupoOpciones> ConsultaGrupoOpcion(int usuario)
        {
            List<UsuarioGrupoOpciones> list_grupo;
            string JSONString = string.Empty;

            list_grupo = _repository.ConsultaGrupoOpcion(usuario).ToList();
            return list_grupo;
        }

        [HttpGet]
        [Route("ConsultaTransacciones")]
        public IEnumerable<TransaccionesUsuario> ConsultaTransacciones(int usuario, int grupo)
        {
            List<TransaccionesUsuario> list_transaccion;
            string JSONString = string.Empty;

            list_transaccion = _repository.ConsultaTransacciones(usuario, grupo).ToList();
            return list_transaccion;
        }

        [HttpPost]
        [Route("ProcesaLogin")]
        public async Task<string> ProcesaLogin([FromBody] LoginUsuario usuario)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.ProcesaLogin(usuario).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }
    }
}
