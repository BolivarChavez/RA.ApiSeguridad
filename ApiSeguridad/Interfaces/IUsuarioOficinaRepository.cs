using AuditSeguridad.Entidades.Models;
using System.Collections.Generic;
using System.Data;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IUsuarioOficinaRepository
    {
        IEnumerable<Retorno> Ingreso(UsuarioOficina oficina);

        IEnumerable<Retorno> Actualizacion(UsuarioOficina oficina);

        IEnumerable<Retorno> Eliminacion(UsuarioOficina oficina);

        IEnumerable<UsuarioOficina> Consulta(int usuario, int empresa);
    }
}
