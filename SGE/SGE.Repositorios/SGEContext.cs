using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class SGEContext : DbContext
{
    #nullable disable
    //public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tramite> Tramites {get; set; }
    public DbSet<Expediente> Expedientes {get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }

    
}
