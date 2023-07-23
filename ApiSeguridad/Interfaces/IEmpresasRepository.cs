using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IEmpresasRepository
    {
        IEnumerable<Retorno> Ingreso(Empresas empresa);

        IEnumerable<Retorno> Actualizacion(Empresas empresa);

        IEnumerable<Empresas> Consulta(int codigo);
    }
}
