using Microsoft.EntityFrameworkCore;

namespace AuditSeguridad.Entidades.Models
{
    [Keyless]
    public class TransaccionesUsuario
    {
        public int tr_codigo { get; set; }
        public string? tr_descripcion { get; set; }
    }
}
