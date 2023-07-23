using AuditSeguridad.Entidades.Models;
using System.Collections.Generic;
using System.Data;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface ITransaccionFacultadRepository
    {
        IEnumerable<Retorno> Ingreso(TransaccionFacultad transaccion);

        IEnumerable<Retorno> Actualizacion(TransaccionFacultad transaccion);

        IEnumerable<Retorno> Eliminacion(TransaccionFacultad transaccion);

        IEnumerable<TransaccionFacultad> Consulta(int transaccion);
    }
}
