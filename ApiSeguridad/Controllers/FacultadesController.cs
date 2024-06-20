using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacultadesController : Controller
    {
        private readonly IFacultadesRepository _repository;
        public FacultadesController(IFacultadesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Insertar un nuevo registro de facultad en la tabla Facultades 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// fa_codigo : Codigo de la facultad, se ingresa 0 (cero)  <br />
        /// fa_descripcion : Nombre o descripcion de la facultad <br />
        /// fa_estado : Estado de la facultad [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_IngresoFacultad
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Facultades facultad)
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

        /// <summary>
        /// Actualizar un registro de facultad previamente ingresado 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// fa_codigo : Codigo de la facultad  <br />
        /// fa_descripcion : Nombre o descripcion de la facultad <br />
        /// fa_estado : Estado de la facultad [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_ActualizaFacultad
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Facultades facultad)
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

        /// <summary>
        /// Consulta los registros de la tabla de facultades
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo de la facultad. Cero para consultar todas las facultades   <br />
        /// Procedimiento almacenado : api_ConsultaFacultad
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<Facultades> Get(int codigo)
        {
            List<Facultades> list_facultad;
            string JSONString = string.Empty;

            list_facultad = _repository.Consulta(codigo).ToList();
            return list_facultad;
        }
    }
}
