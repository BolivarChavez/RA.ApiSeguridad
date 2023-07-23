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
        /// Registra la informacion de una nueva empresa
        /// </summary>
        /// <remarks>
        /// <b>Codigos de operacion permitidos</b><br />
        /// A : Obtiene las divisiones, areas o departamentos relacionadas a una division o area de orden superior (vigentes)<br />
        /// Q : Obtiene toda la informacion relacionada a una division, area o departamento especifico<br />
        /// S : Obtiene las divisiones, areas o departamentos relacionadas a una division o area de orden superior (vigentes y no vigentes)<br />
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

        [HttpGet]
        [Route("Consulta")]
        public IEnumerable<Empresas> Get(int codigo)
        {
            List<Empresas> list_empresa;
            string JSONString = string.Empty;

            list_empresa = _repository.Consulta(codigo).ToList();
            return list_empresa;
        }
    }
}
