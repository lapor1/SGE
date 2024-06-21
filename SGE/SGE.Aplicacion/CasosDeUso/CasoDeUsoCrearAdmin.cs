using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Servicios;
using System.Data.Common;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoCrearAdmin(IUsuarioRepositorio repoU)
{
    public void Ejecutar(Usuario? admin)
    {
        List<Permiso> permisosAdmin = new List<Permiso>();

        foreach (Permiso p in Enum.GetValues(typeof(Permiso)))
        {
            permisosAdmin.Add(p);
        }

        var servicioHash = new ServicioHash();

        if (admin == null){
            admin = new Usuario() {
                Id = 1,
                Nombre = "Admin",
                Apellido = "Admin",
                CorreoElectronico = "Admin@gmail.com",
                Contraseña = servicioHash.HashPassword("1234"),
                ListaPermisos = permisosAdmin
            };
        }
        else {
            admin.Id = 1;
            admin.ListaPermisos = permisosAdmin;
        }
        

        repoU.AgregarUsuarioAlta(admin);
    }
}
