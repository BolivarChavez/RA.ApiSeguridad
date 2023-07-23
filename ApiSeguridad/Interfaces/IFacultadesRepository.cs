using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IFacultadesRepository
    {
        IEnumerable<Retorno> Ingreso(Facultades facultad);

        IEnumerable<Retorno> Actualizacion(Facultades facultad);

        IEnumerable<Facultades> Consulta(int codigo);
    }
}
