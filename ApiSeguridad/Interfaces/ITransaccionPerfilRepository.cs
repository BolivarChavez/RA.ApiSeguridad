using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface ITransaccionPerfilRepository
    {
        IEnumerable<Retorno> Ingreso(TransaccionPerfil transaccion);

        IEnumerable<Retorno> Actualizacion(TransaccionPerfil transaccion);

        IEnumerable<Retorno> Eliminacion(TransaccionPerfil transaccion);

        IEnumerable<TransaccionPerfil> Consulta(int perfil);
    }
}
