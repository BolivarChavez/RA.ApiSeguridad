using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GruposOpcionesController : Controller
    {
        private readonly IGruposOpcionesRepository _repository;
        public GruposOpcionesController(IGruposOpcionesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Insertar un nuevo registro de grupos de opciones en la tabla GruposOpciones 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// go_codigo : Codigo del grupo de opciones, se ingresa 0 (cero) <br />
        /// go_orden : Orden de presentacion de los grupos de opciones <br />
        /// go_descripcion : Nombre o descripcion del grupo de opciones <br />
        /// go_estado : Estado del grupo de opciones [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_IngresoGrupoOpcion
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] GruposOpciones opcion)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(opcion).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualizar registro de grupos de opciones previamente ingresado 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// go_codigo : Codigo del grupo de opciones <br />
        /// go_orden : Orden de presentacion de los grupos de opciones <br />
        /// go_descripcion : Nombre o descripcion del grupo de opciones <br />
        /// go_estado : Estado del grupo de opciones [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_ActualizaGrupoOpcion
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] GruposOpciones opcion)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(opcion).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros de la tabla de grupos de opciones 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo del grupo de opciones. Para consultar todos ingresar cero (0) <br />
        /// Procedimiento almacenado : api_ConsultaGrupoOpcion
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<GruposOpciones> Get(int codigo)
        {
            List<GruposOpciones> list_opcion;
            string JSONString = string.Empty;

            list_opcion = _repository.Consulta(codigo).ToList();
            return list_opcion;
        }
    }
}
