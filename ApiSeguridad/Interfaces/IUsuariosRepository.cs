using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IUsuariosRepository
    {
        IEnumerable<Retorno> Ingreso(Usuarios usuario);

        IEnumerable<Retorno> Actualizacion(Usuarios usuario);

        IEnumerable<Usuarios> Consulta(int codigo, string usuario);

        IEnumerable<TransaccionesUsuario> ConsultaTransacciones(int usuario, int grupo);

        IEnumerable<UsuarioGrupoOpciones> ConsultaGrupoOpcion(int usuario);

        IEnumerable<Retorno> ProcesaLogin(LoginUsuario usuario);
    }
}
