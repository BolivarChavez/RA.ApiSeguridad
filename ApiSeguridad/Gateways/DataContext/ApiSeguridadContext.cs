using AuditSeguridad.Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridad.Gateways.DataContext
{
    public class ApiSeguridadContext : DbContext
    {
        public ApiSeguridadContext(DbContextOptions<ApiSeguridadContext> options) : base(options) { }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Facultades> Facultades { get; set; }
        public DbSet<GruposOpciones> GruposOpciones { get; set; }
        public DbSet<Oficinas> Oficinas { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<TransaccionFacultad> TransaccionFacultad { get; set; }
        public DbSet<TransaccionPerfil> TransaccionPerfil { get; set; }
        public DbSet<UsuarioFacultad> UsuarioFacultad { get; set; }
        public DbSet<UsuarioOficina> UsuarioOficina { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuarioGrupoOpciones> UsuarioGrupoOpciones { get; set; }
        public DbSet<TransaccionesUsuario> TransaccionesUsuario { get; set; }
        public DbSet<Retorno> Retorno { get; set; }
    }
}
