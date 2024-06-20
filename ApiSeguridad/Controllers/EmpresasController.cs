using AuditSeguridad.Entidades.Interfaces;
using AuditSeguridad.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiSeguridad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpresasController : Controller
    {
        private readonly IEmpresasRepository _repository;
        public EmpresasController(IEmpresasRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Insertar un nuevo registro de empresa en la tabla Empresas
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// em_codigo : Codigo de la empresa, se ingresa 0 (cero) <br />
        /// em_nombre : Nombre o razon social de la empresa <br />
        /// em_pais : Nombre del Pais del domicilio de la empresa <br />
        /// em_provincia : Nombre de la Provincia del domicilio de la empresa <br />
        /// em_ciudad : Nombre de la Ciudad del domicilio de la empresa <br />
        /// em_direccion : Direccion completa de la empresa <br />
        /// em_telefono : Numeros de telefonos de contacto de la empresa <br />
        /// em_contacto : Nombre de persona de contacto en la empresa <br />
        /// em_email : Correos electronicos de contacto de la emrpesa <br />
        /// em_estado : Estado de la empresa [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_IngresoEmpresa
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Empresas empresa)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(empresa).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString; 
        }

        /// <summary>
        /// Actualizar un registro existente de empresa en la tabla Empresas
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// em_codigo : Codigo de la empresa <br />
        /// em_nombre : Nombre o razon social de la empresa <br />
        /// em_pais : Nombre del Pais del domicilio de la empresa <br />
        /// em_provincia : Nombre de la Provincia del domicilio de la empresa <br />
        /// em_ciudad : Nombre de la Ciudad del domicilio de la empresa <br />
        /// em_direccion : Direccion completa de la empresa <br />
        /// em_telefono : Numeros de telefonos de contacto de la empresa <br />
        /// em_contacto : Nombre de persona de contacto en la empresa <br />
        /// em_email : Correos electronicos de contacto de la emrpesa <br />
        /// em_estado : Estado de la empresa [A] Activa, [I] Inactiva, [X] Eliminada <br /><br />
        /// Procedimiento almacenado : api_ActualizaEmpresa
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Empresas empresa)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(empresa).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros de la tabla de empresas 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo de empresa, para consultar todas las empresas se coloca cero (0) <br /><br />
        /// Procedimiento almacenado : api_ConsultaEmpresa
        /// </remarks> 
        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<Empresas> Get(int codigo)
        {
            List<Empresas> list_empresa;
            string JSONString = string.Empty;

            list_empresa = _repository.Consulta(codigo).ToList();
            return list_empresa;
        }
    }
}
