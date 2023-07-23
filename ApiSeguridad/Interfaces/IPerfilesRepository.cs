using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IPerfilesRepository
    {
        IEnumerable<Retorno> Ingreso(Perfiles perfil);

        IEnumerable<Retorno> Actualizacion(Perfiles perfil);

        IEnumerable<Perfiles> Consulta(int codigo);
    }
}
