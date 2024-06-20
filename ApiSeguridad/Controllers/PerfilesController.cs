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

        /// <summary>
        /// Insertar un nuevo registro de perfil en la tabla de perfiles 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// pe_codigo : Codigo del perfil, cero (0) para nuevo perfil <br />
        /// pe_descripcion : Nombre o descripcion de la oficina <br />
        /// pe_estado : Estado del perfil [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />  
        /// Procedimiento almacenado : api_IngresoPerfil
        /// </remarks>
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

        /// <summary>
        /// Actualizar un registro de perfil previamente ingresado 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// pe_codigo : Codigo del perfil <br />
        /// pe_descripcion : Nombre o descripcion de la oficina <br />
        /// pe_estado : Estado del perfil [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />  
        /// Procedimiento almacenado : api_ActualizaPerfil
        /// </remarks>
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

        /// <summary>
        /// Consulta los perfiles registrados en la tabla de perfiles 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo del perfil, cero (0) para consultar todos los perfiles <br />
        /// Procedimiento almacenado : api_ConsultaPerfil
        /// </remarks>
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
