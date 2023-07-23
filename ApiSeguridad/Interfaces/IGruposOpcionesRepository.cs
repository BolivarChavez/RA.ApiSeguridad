using AuditSeguridad.Entidades.Models;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IGruposOpcionesRepository
    {
        IEnumerable<Retorno> Ingreso(GruposOpciones grupo);

        IEnumerable<Retorno> Actualizacion(GruposOpciones grupo);

        IEnumerable<GruposOpciones> Consulta(int codigo);
    }
}
