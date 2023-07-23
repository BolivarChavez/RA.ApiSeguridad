using Microsoft.EntityFrameworkCore;

namespace AuditSeguridad.Entidades.Models
{
    [Keyless]
    public class UsuarioGrupoOpciones
    {
        public Int16 go_codigo { get; set; }
        public Int16 go_orden { get; set; }
        public string? go_descripcion { get; set; }
    }
}
