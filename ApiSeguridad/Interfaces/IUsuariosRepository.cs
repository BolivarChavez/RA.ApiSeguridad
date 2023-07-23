using AuditSeguridad.Entidades.Models;
using System.Collections.Generic;
using System.Data;

namespace AuditSeguridad.Entidades.Interfaces
{
    public interface IUsuariosRepository
    {
        IEnumerable<Retorno> Ingreso(Usuarios usuario);

        IEnumerable<Retorno> Actualizacion(Usuarios usuario);

        IEnumerable<Usuarios> Consulta(int codigo);

        IEnumerable<TransaccionesUsuario> ConsultaTransacciones(int usuario, int grupo);

        IEnumerable<UsuarioGrupoOpciones> ConsultaGrupoOpcion(int usuario);

        IEnumerable<Retorno> ProcesaLogin(LoginUsuario usuario);
    }
}
