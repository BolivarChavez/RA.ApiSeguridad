using Microsoft.EntityFrameworkCore;

namespace AuditSeguridad.Entidades.Models
{
    [Keyless]
    public class Retorno
    {
        public int retorno { get; set; }
        public string? mensaje { get; set; }
        public string? descripcion { get; set; }
    }
}
