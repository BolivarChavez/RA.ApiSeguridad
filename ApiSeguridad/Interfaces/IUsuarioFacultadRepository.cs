using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IUsuarioFacultadRepository
    {
        IEnumerable<Retorno> Ingreso(UsuarioFacultad facultad);

        IEnumerable<Retorno> Actualizacion(UsuarioFacultad facultad);

        IEnumerable<Retorno> Eliminacion(UsuarioFacultad facultad);

        IEnumerable<UsuarioFacultad> Consulta(int usuario, int transaccion);
    }
}
