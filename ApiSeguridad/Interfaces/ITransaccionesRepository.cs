using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface ITransaccionesRepository
    {
        IEnumerable<Retorno> Ingreso(Transacciones transaccion);

        IEnumerable<Retorno> Actualizacion(Transacciones transaccion);

        IEnumerable<Transacciones> Consulta(int codigo);
    }
}
