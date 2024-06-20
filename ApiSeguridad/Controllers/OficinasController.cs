using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OficinasController : Controller
    {
        private readonly IOficinasRepository _repository;
        public OficinasController(IOficinasRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Insertar un nuevo registro de oficina en la tabla Oficinas 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// of_emoresa : Codigo de la empresa a la cual pertenece la oficina <br /> 
        /// of_codigo : Codigo de la oficina, cero (0) para nuevo registro <br /> 
        /// of_nombre : Nombre o descripcion de la oficina <br /> 
        /// of_pais : Nombre del Pais del domicilio de la oficina <br /> 
        /// of_provincia : Nombre de la Provincia del domicilio de la oficina <br /> 
        /// of_ciudad : Nombre de la Ciudad del domicilio de la oficina <br /> 
        /// of_direccion : Direccion completa de la oficina <br /> 
        /// of_telefono : Numeros de telefonos de contacto de la oficina <br /> 
        /// of_contacto : Nombre de persona de contacton en la oficina <br /> 
        /// of_email : Correos electronicos de contacto de la oficina <br /> 
        /// of_estado : Estado de la oficina [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />     
        /// Procedimiento almacenado : api_IngresoOficina
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Oficinas oficina)
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

        /// <summary>
        /// Actualizar un registro de oficina en la tabla Oficinas ya ingresado previamente 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// of_emoresa : Codigo de la empresa a la cual pertenece la oficina <br />                    
        /// of_codigo : Codigo de la oficina <br /> 
        /// of_nombre : Nombre o descripcion de la oficina<br /> 
        /// of_pais : Nombre del Pais del domicilio de la oficina <br /> 
        /// of_provincia : Nombre de la Provincia del domicilio de la oficina <br /> 
        /// of_ciudad : Nombre de la Ciudad del domicilio de la oficina <br /> 
        /// of_direccion : Direccion completa de la oficina <br /> 
        /// of_telefono : Numeros de telefonos de contacto de la oficina <br /> 
        /// of_contacto : Nombre de persona de contacton en la oficina <br /> 
        /// of_email : Correos electronicos de contacto de la oficina <br /> 
        /// of_estado : Estado de la oficina [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />     
        /// Procedimiento almacenado : api_ActualizaOficina
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Oficinas oficina)
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

        /// <summary>
        /// Consulta los registros de la tabla de oficinas
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// emoresa : Codigo de la empresa a la cual pertenece la oficina <br />                    
        /// codigo : Codigo de la oficina. Colocar cero (0) para consultar todas las oficinas <br /> 
        /// Procedimiento almacenado : api_ConsultaOficina
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{codigo}")]
        public IEnumerable<Oficinas> Get(int empresa, int codigo)
        {
            List<Oficinas> list_oficina;
            string JSONString = string.Empty;

            list_oficina = _repository.Consulta(empresa, codigo).ToList();
            return list_oficina;
        }
    }
}
