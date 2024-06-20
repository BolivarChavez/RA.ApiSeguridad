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

        /// <summary>
        /// Ingresa la informacion de un nuevo usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// us_codigo : Codigo del usuario, para ingreso nuevo es cero (0) <br />
        /// us_nombre : Nombre completo del usuario <br />
        /// us_login : Nombre para registro de credenciales (login) <br />
        /// us_password : Contraseña cifrada del usuario <br />
        /// us_email : Correo electronico del usuario <br />
        /// us_ingresos : Numero de ingresos fallidos, en este caso se coloca cero (0) <br />
        /// us_ultimo_ingreso : Fecha del ultimo ingreso al sistema <br />
        /// us_estado : Estado del registro [A] Activo, [I] Inactivo, [X] Eliminado <br /><br />
        /// Procedimiento almacenado : api_IngresoUsuario
        /// </remarks>
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

        /// <summary>
        /// Actualiza la informacion de un usuario ingresado previamente
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// us_codigo : Codigo del usuario <br />
        /// us_nombre : Nombre completo del usuario <br />
        /// us_login : Nombre para registro de credenciales (login) <br />
        /// us_password : Contraseña cifrada del usuario <br />
        /// us_email : Correo electronico del usuario <br />
        /// us_ingresos : Numero de ingresos fallidos, en este caso se coloca cero (0) <br />
        /// us_ultimo_ingreso : Fecha del ultimo ingreso al sistema <br />
        /// us_estado : Estado del registro [A] Activo, [I] Inactivo, [X] Eliminado <br /><br />
        /// Procedimiento almacenado : api_ActualizaUsuario
        /// </remarks>
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

        /// <summary>
        /// Consulta informacion de los usuarios registrados
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo del usuario <br />
        /// usuario : Nombre de usuario (Login). Para consultar solo por codigo colocar (*) <br /><br />
        /// Procedimiento almacenado : api_ConsultaUsuario
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{codigo}/{usuario}")]
        public IEnumerable<Usuarios> Get(int codigo, string usuario)
        {
            List<Usuarios> list_usuario;
            string JSONString = string.Empty;

            list_usuario = _repository.Consulta(codigo, usuario).ToList();
            return list_usuario;
        }

        /// <summary>
        /// Consulta los grupos de opciones de las transacciones de los perfiles autorizados a un usuario
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// usuario : Codigo del usuario <br /><br />
        /// Procedimiento almacenado : api_ConsultaUsuarioGrupoOpciones
        /// </remarks>
        [HttpGet]
        [Route("ConsultaGrupoOpcion/{usuario}")]
        public IEnumerable<UsuarioGrupoOpciones> ConsultaGrupoOpcion(int usuario)
        {
            List<UsuarioGrupoOpciones> list_grupo;
            string JSONString = string.Empty;

            list_grupo = _repository.ConsultaGrupoOpcion(usuario).ToList();
            return list_grupo;
        }

        /// <summary>
        /// Consulta todas las transacciones autorizadas al usuario de acuerdo al perfil y al grupo de opciones
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// usuario : Codigo del usuario <br /><br />
        /// grupo : Codigo del grupo de opciones <br /><br />
        /// Procedimiento almacenado : api_ConsultaTransaccionesUsuario
        /// </remarks>
        [HttpGet]
        [Route("ConsultaTransacciones/{usuario}/{grupo}")]
        public IEnumerable<TransaccionesUsuario> ConsultaTransacciones(int usuario, int grupo)
        {
            List<TransaccionesUsuario> list_transaccion;
            string JSONString = string.Empty;

            list_transaccion = _repository.ConsultaTransacciones(usuario, grupo).ToList();
            return list_transaccion;
        }

        /// <summary>
        /// Procesa el ingreso del usuario al sistem. Validacion de credenciales (usuario y password)
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// usuario : Nombre del usuario (login) <br /><br />
        /// password : Contraseña del usuario cifrada <br /><br />
        /// Procedimiento almacenado : api_ProcesaLogin
        /// </remarks>
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
