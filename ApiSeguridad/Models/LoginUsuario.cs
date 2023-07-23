using Microsoft.EntityFrameworkCore;

namespace AuditSeguridad.Entidades.Models
{
    [Keyless]
    public class LoginUsuario
    {
        public string? usuario { get; set; }
        public string? password { get; set; }
    }
}
