using AuditSeguridad.Entidades.Models;
using System.Collections.Generic;
using System.Data;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IUsuarioPerfilRepository
    {
        IEnumerable<Retorno> Ingreso(UsuarioPerfil perfil);

        IEnumerable<Retorno> Actualizacion(UsuarioPerfil perfil);

        IEnumerable<Retorno> Eliminacion(UsuarioPerfil perfil);

        IEnumerable<UsuarioPerfil> Consulta(int usuario);
    }
}
