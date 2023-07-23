using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IOficinasRepository
    {
        IEnumerable<Retorno> Ingreso(Oficinas oficina);

        IEnumerable<Retorno> Actualizacion(Oficinas oficina);

        IEnumerable<Oficinas> Consulta(int empresa, int codigo);
    }
}
